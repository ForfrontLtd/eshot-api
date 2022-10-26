using Forfront.eshot.API.Exceptions;
using Forfront.eshot.API.Model;
using System.Dynamic;
using System.Text;
using System.Text.Json;

namespace Forfront.eshot.API.Helpers
{
    public class EshotInternalHttpClient
    {
        private readonly HttpClient _client;
        private static readonly JsonSerializerOptions _serializationOptions = ConfigureSerializationOptions();

        public EshotInternalHttpClient(string baseAddress, string apiKey, bool ignoreSslErrors = false)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
                throw new ArgumentNullException(nameof(baseAddress));
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey));

            HttpClientHandler clientHandler = new();

            if (ignoreSslErrors)
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            _client = new HttpClient(clientHandler) { BaseAddress = new Uri(baseAddress) };
            _client.DefaultRequestHeaders.Add("Authorization", $"Token {apiKey}");
        }

        public HttpClient Client
        {
            get
            {
                return _client;
            }
        }

        public T[] Get<T>(string relativeUrl, FieldFilter filter) where T : class, new()
        {
            string url = QueryStringBuilder.BuildUrl(
                relativeUrl,
                filter.GetODataSelectQueryStringParameter(),
                filter.GetODataExpandQueryStringParameter(),
                filter.GetODataFilterQueryStringParameter());

            if (filter.Take > 0)
                url = QueryStringBuilder.BuildUrl(url, $"$top={filter.Take}");
            if (filter.Skip > 0)
                url = QueryStringBuilder.BuildUrl(url, $"skip={filter.Skip}");

            HttpRequestMessage message = new(HttpMethod.Get, url);

            return SendAndReturnJsonArray<T>(message) ?? Array.Empty<T>();
        }

        public T[] Get<T>(string relativeUrl, int? subaccountId = null) where T : class, new()
        {
            string url = subaccountId.HasValue ?
                QueryStringBuilder.BuildUrl(relativeUrl, $"$filter=SubaccountID eq {subaccountId}") :
                QueryStringBuilder.BuildUrl(relativeUrl);

            HttpRequestMessage message = new(HttpMethod.Get, url);

            return SendAndReturnJsonArray<T>(message) ?? Array.Empty<T>();
        }

        public void Delete(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            HttpRequestMessage message = new(HttpMethod.Delete, url);

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return;

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public void Send(HttpRequestMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return;

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public JsonDocument SendAndReturnJson(HttpRequestMessage message)
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return JsonDocument.Parse(result);
            }

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public void Post(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            HttpRequestMessage message = new(HttpMethod.Post, url);

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return;

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public R PostJson<R, T>(string url, T input) where R : class, new()
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            HttpRequestMessage message = new(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json")
            };

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return GetJsonResult<R>(response) ?? new R();

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public void PostDictionaryJson(string url, IDictionary<string, object> input)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            HttpRequestMessage message = new(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json")
            };

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return;

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public void PostJson<T>(string url, T input)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            HttpRequestMessage message = new(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json")
            };

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return;

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public T PostFileAndReturnJson<T>(string url, byte[] bytes) where T : class, new()
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            HttpRequestMessage message = new(HttpMethod.Post, url)
            {
                Content = new ByteArrayContent(bytes)
            };

            return SendAndReturnJson<T>(message) ?? new T();
        }

        public T GetOne<T>(string url) where T : class, new()
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            HttpRequestMessage message = new(HttpMethod.Get, url);
            return SendAndReturnJson<T>(message) ?? new T();
        }

        public string GetAsString(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException(nameof(url));

            HttpRequestMessage message = new(HttpMethod.Get, url);

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
            {
                using var httpResponse = response;

                Stream responseStream = httpResponse.Content.ReadAsStream();

                if (responseStream == null)
                    return "";

                using var streamReader = new StreamReader(responseStream);

                return streamReader.ReadToEnd();
            }

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public T? SendAndReturnJson<T>(HttpRequestMessage message) where T : class, new()
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));

            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return GetJsonResult<T>(response);

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        public T[]? SendAndReturnJsonArray<T>(HttpRequestMessage message) where T : class, new()
        {
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            var response = _client.Send(message);

            if (response.IsSuccessStatusCode)
                return GetJsonResultAsArray<T>(response);

            ForfrontErrorResponse? errorResponse = GetJsonResult<ForfrontErrorResponse>(response);

            throw new RestApiException(response.StatusCode, errorResponse?.Error);
        }

        private TR[]? GetJsonResultAsArray<TR>(HttpResponseMessage response) where TR : class, new()
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            using var httpResponse = response;

            Stream responseStream = response.Content.ReadAsStream();

            if (responseStream == null)
                return default;

            using var streamReader = new StreamReader(responseStream);

            string result = streamReader.ReadToEnd();

            if (string.IsNullOrWhiteSpace(result))
                return default;

            if (result.IndexOf("@odata.context") > -1)
            {
                ODataArrayResult<TR> odataResult = JsonSerializer.Deserialize<ODataArrayResult<TR>>(result, _serializationOptions) ?? new();

                return odataResult.Value;
            }

            return JsonSerializer.Deserialize<TR[]>(result, _serializationOptions);
        }

        private TR? GetJsonResult<TR>(HttpResponseMessage response) where TR : class, new()
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            using var httpResponse = response;

            Stream responseStream = httpResponse.Content.ReadAsStream();

            if (responseStream == null)
                return default;

            using var streamReader = new StreamReader(responseStream);

            string result = streamReader.ReadToEnd();

            if (string.IsNullOrWhiteSpace(result))
                return default;

            if (result.IndexOf("\"@odata.context\"") > -1 && result.IndexOf("\"value\"") > -1)
            {
                ODataArrayResult<TR> odataResult = JsonSerializer.Deserialize<ODataArrayResult<TR>>(result, _serializationOptions) ?? new();

                return odataResult?.Value?.FirstOrDefault();
            }

            return JsonSerializer.Deserialize<TR>(result, _serializationOptions);
        }

        private static JsonSerializerOptions ConfigureSerializationOptions()
        {
            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonInt32Converter());
            return options;
        }
    }
}
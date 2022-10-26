using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// e-shot Users
    /// </summary>
    public class EshotUsers
    {
        private readonly EshotInternalHttpClient _client;

        public EshotUsers(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public User[] Get(FieldFilter filter)
        {
            return _client.Get<User>("Users", filter);
        }

        public User[] Get()
        {
            return Get(new FieldFilter());
        }

        public User WhoAmI()
        {
            return _client.GetOne<User>("WhoAmI");
        }

        public string OneTimeAppLoginUrl(int? subaccountId = null, string? returnUrl = null)
        {
            string url = "Identity/EshotLogin";
            if (subaccountId.HasValue)
                url = QueryStringBuilder.BuildUrl(url, $"SubaccountID={subaccountId.Value}");
            if (!string.IsNullOrWhiteSpace(returnUrl))
                url = QueryStringBuilder.BuildUrl(url, $"ReturnUrl={returnUrl}");
            return _client.GetAsString(url);
        }

        /// <summary>
        /// Call only allowed by an account admin
        /// </summary>
        /// <param name="id"></param>
        public void MakeAdmin(int id)
        {
            _client.Post($"Users({id})/MakeAdmin");
        }

        /// <summary>
        /// Call only allowed by an account admin
        /// </summary>
        /// <param name="id"></param>
        public void RemoveAdmin(int id)
        {
            _client.Post($"Users({id})/RemoveAdmin");
        }
    }
}
namespace Forfront.eshot.API.Helpers
{
    public static class QueryStringBuilder
    {
        public static string BuildUrl(string url, params string[] parameters)
        {
            foreach (var parameter in parameters)
            {
                string separater = url.IndexOf("?") > -1 ? "&" : "?";

                if (!string.IsNullOrWhiteSpace(parameter))
                    url += $"{separater}{parameter}";
            }

            return url;
        }
    }
}
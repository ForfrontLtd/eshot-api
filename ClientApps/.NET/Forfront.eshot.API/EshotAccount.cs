using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Each client has one account record
    /// </summary>
    public class EshotAccount
    {
        private readonly EshotInternalHttpClient _client;

        public EshotAccount(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Account Get()
        {
            return _client.GetOne<Account>("Accounts");
        }
    }
}
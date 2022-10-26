using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Sources represent where contacts were sourced from
    /// Currently you set up Sources via the https://console.e-shot.net application
    /// </summary>
    public class EshotSubaccounts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSubaccounts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Subaccount[] Get(FieldFilter filter)
        {
            return _client.Get<Subaccount>("Subaccounts", filter);
        }

        public Subaccount[] Get(int? id = null)
        {
            FieldFilter filter = new();
            if (id.HasValue)
                filter.AddEqualityComparison("ID", id.Value);
            return Get(filter);
        }
    }
}
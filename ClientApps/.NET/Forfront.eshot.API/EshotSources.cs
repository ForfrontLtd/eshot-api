using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Sources represent where contacts were sourced from
    /// Currently you set up Sources via the https://console.e-shot.net application
    /// </summary>
    public class EshotSources
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSources(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Source[] Get(FieldFilter filter)
        {
            return _client.Get<Source>("Sources", filter);
        }

        public Source[] Get(int subaccountId)
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("SubaccountID", subaccountId);
            return Get(filter);
        }

        public Id Save(Source source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return _client.PostJson<Id, Source>($"Sources", source);
        }
    }
}
using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Enables one to see a list of preferences configured for use within a subaccount
    /// You assign/unassign preferences to or from a subaccount via the https://console.e-shot.net application
    /// </summary>
    public class EshotSubaccountChannelPreferenceMappings
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSubaccountChannelPreferenceMappings(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public SubaccountChannelPreferenceMapping[] Get(FieldFilter filter)
        {
            return _client.Get<SubaccountChannelPreferenceMapping>("SubaccountChannelPreferenceMappings", filter);
        }

        public SubaccountChannelPreferenceMapping[] Get(int subaccountId)
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("SubaccountID", subaccountId);
            filter.Expansions.Add("Preference");
            filter.Expansions.Add("Channel");
            return Get(filter);
        }
    }
}
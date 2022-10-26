using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Enables one to see a list of contact fields configured for use within a subaccount
    /// The custom field display names can be used in the /Contacts/Export query for custom fields only.
    /// (In the future we will enable all fields to map to the available $select field names)
    /// </summary>
    public class EshotSubaccountContactFieldMappings
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSubaccountContactFieldMappings(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public SubaccountContactFieldMapping[] Get(FieldFilter filter)
        {
            return _client.Get<SubaccountContactFieldMapping>("SubaccountContactFieldMappings", filter);
        }

        public SubaccountContactFieldMapping[] Get(int subaccountId)
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("SubaccountID", subaccountId);
            return Get(filter);
        }

        public SubaccountContactFieldMapping[] GetCustomFields(int subaccountId)
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("SubaccountID", subaccountId);
            filter.AddEqualityComparison("IsCustomField", true);
            return Get(filter);
        }
    }
}
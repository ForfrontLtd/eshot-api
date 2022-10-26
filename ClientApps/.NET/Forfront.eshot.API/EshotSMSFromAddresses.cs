using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// SMS from addresses
    /// </summary>
    public class EshotSMSFromAddresses
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSMSFromAddresses(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public SMSFromAddress[] Get(FieldFilter filter)
        {
            return _client.Get<SMSFromAddress>("SMSFromAddresses", filter);
        }

        public SMSFromAddress[] Get(int? subaccountId = null)
        {
            FieldFilter filter = new();
            if (subaccountId.HasValue)
                filter.AddEqualityComparison("SubaccountID", subaccountId.Value);
            return Get(filter);
        }
    }
}
using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Email from addresses
    /// </summary>
    public class EshotEmailFromAddresses
    {
        private readonly EshotInternalHttpClient _client;

        public EshotEmailFromAddresses(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public EmailFromAddress[] Get(FieldFilter filter)
        {
            return _client.Get<EmailFromAddress>("EmailFromAddresses", filter);
        }

        public EmailFromAddress[] Get(int? subaccountId = null)
        {
            FieldFilter filter = new();
            if (subaccountId.HasValue)
                filter.AddEqualityComparison("SubaccountID", subaccountId.Value);
            return Get(filter);
        }
    }
}
using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Clicks represent where campaign send click interactions
    /// </summary>
    public class EshotSends
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSends(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public EmailSend[] GetEmailSends(FieldFilter filter)
        {
            filter.AddEqualityComparison("SendType", "Email");
            return _client.Get<EmailSend>("Sends", filter);
        }

        public SMSSend[] GetSMSSends(FieldFilter filter)
        {
            filter.AddEqualityComparison("SendType", "SMS");
            return _client.Get<SMSSend>("Sends", filter);
        }

        public Send[] Get(FieldFilter filter)
        {
            return _client.Get<Send>("Sends", filter);
        }

        public Send[] GetByCampaign(int campaignId, FieldFilter? filter = null)
        {
            filter ??= new FieldFilter();
            filter.AddEqualityComparison("CampaignID", campaignId);
            return _client.Get<Send>("Sends", filter);
        }
    }
}
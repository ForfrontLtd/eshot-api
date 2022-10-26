using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Clicks represent where campaign send click interactions
    /// </summary>
    public class EshotUnsubscribedContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotUnsubscribedContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public UnsubscribedContact[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<UnsubscribedContact>("UnsubscribedContacts", filter);
        }

        public UnsubscribedContact[] GetByCampaign(int campaignId)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            return Get(filter);
        }

        public UnsubscribedContact[] GetBySend(int sendId)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            return Get(filter);
        }
    }
}
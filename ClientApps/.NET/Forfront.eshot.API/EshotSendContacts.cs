using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Clicks represent where campaign send click interactions 
    /// </summary>
    public class EshotSendContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSendContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public SendContact[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<SendContact>("SendContacts", filter);
        }

        public SendContact[] GetByCampaign(int campaignId)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            return Get(filter);
        }

        public SendContact[] GetBySend(int sendId)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            return Get(filter);
        }
    }
}
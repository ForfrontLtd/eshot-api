using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Clicks represent where campaign send click interactions 
    /// </summary>
    public class EshotBouncedContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotBouncedContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public BouncedContact[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<BouncedContact>("BouncedContacts", filter);
        }

        public BouncedContact[] GetByCampaign(int campaignId)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            return Get(filter);
        }

        public BouncedContact[] GetBySend(int sendId)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            return Get(filter);
        }
    }
}
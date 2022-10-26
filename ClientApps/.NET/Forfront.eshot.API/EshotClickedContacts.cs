using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Clicks represent where campaign send click interactions 
    /// </summary>
    public class EshotClickedContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotClickedContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ClickedContact[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<ClickedContact>("ClickedContacts", filter);
        }

        public ClickedContact[] GetByCampaign(int campaignId)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            return Get(filter);
        }

        public ClickedContact[] GetBySend(int sendId)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            return Get(filter);
        }
    }
}
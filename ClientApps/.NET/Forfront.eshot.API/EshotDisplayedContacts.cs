using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Clicks represent where campaign send click interactions
    /// </summary>
    public class EshotDisplayedContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotDisplayedContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public DisplayedContact[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<DisplayedContact>("DisplayedContacts", filter);
        }

        public DisplayedContact[] GetByCampaign(int campaignId)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            return Get(filter);
        }

        public DisplayedContact[] GetBySend(int sendId)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            return Get(filter);
        }
    }
}
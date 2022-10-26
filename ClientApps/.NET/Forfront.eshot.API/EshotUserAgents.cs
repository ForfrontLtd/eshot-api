using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Visits 
    /// </summary>
    public class EshotUserAgents
    {
        private readonly EshotInternalHttpClient _client;

        public EshotUserAgents(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public UserAgent[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<UserAgent>("UserAgents", filter);
        }

        public UserAgent[] GetByCampaign(int campaignId)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            return Get(filter);
        }

        public UserAgent[] GetBySend(int sendId)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            return Get(filter);
        }
    }
}
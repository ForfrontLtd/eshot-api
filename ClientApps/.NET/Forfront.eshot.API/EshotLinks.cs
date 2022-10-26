using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Links represent links in a sent campaign
    /// </summary>
    public class EshotLinks
    {
        private readonly EshotInternalHttpClient _client;

        public EshotLinks(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Link[] Get(CampaignSendContactFilter filter)
        {
            return _client.Get<Link>("Links", filter);
        }

        public Link[] Get(int? id = null)
        {
            CampaignSendContactFilter filter = new();
            if (id.HasValue)
                filter.AddEqualityComparison("ID", id.Value);
            return Get(filter);
        }

        public Link[] GetByCampaign(int campaignId, bool includeClickedContacts = false)
        {
            CampaignSendContactFilter filter = new();
            filter.CampaignID = campaignId;
            if (includeClickedContacts)
                filter.Expansions.Add("ClickedContacts");
            return Get(filter);
        }

        public Link[] GetBySend(int sendId, bool includeClickedContacts = false)
        {
            CampaignSendContactFilter filter = new();
            filter.SendID = sendId;
            if (includeClickedContacts)
                filter.Expansions.Add("ClickedContacts");
            return Get(filter);
        }
    }
}
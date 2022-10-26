namespace Forfront.eshot.API.Model
{
    public class UnsubscribedContact
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public int ContactID { get; set; }

        public bool IsGlobalUnsubscribe { get; set; }

        public DateTimeOffset? UnsubscribeDate { get; set; }

        public int SendID { get; set; }

        public int CampaignID { get; set; }

        public long SendContactID { get; set; }

        public bool IsComplaint { get; set; }
    }
}
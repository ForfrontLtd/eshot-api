namespace Forfront.eshot.API.Model
{
    public class ClickedContact
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public int ContactID { get; set; }

        public DateTimeOffset ClickDate { get; set; }

        public int LinkID { get; set; }

        public int SendID { get; set; }

        public int CampaignID { get; set; }

        public long SendContactID { get; set; }

        public long? UserAgentID { get; set; }

        public string? FriendlyName { get; set; }

        public bool IsSuspectedBOT { get; set; }
    }
}
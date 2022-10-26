namespace Forfront.eshot.API.Model
{
    public class DisplayedContact
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public int ContactID { get; set; }

        public DateTimeOffset DisplayDate { get; set; }

        public string Format { get; set; } = "";

        public int SendID { get; set; }

        public int CampaignID { get; set; }

        public long SendContactID { get; set; }

        public long? UserAgentID { get; set; }

        public int? TimeInSecondsSpentReadingEmail { get; set; }

        public bool IsSuspectedBOT { get; set; }
    }
}
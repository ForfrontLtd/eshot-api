namespace Forfront.eshot.API.Model
{
    public class UserAgent
    {
        public long ID { get; set; }

        public int SubaccountID { get; set; }

        public int CampaignID { get; set; }

        public int SendID { get; set; }

        public int ContactID { get; set; }

        public long SendContactID { get; set; }

        public DateTimeOffset DisplayDate { get; set; }

        public string IPAddress { get; set; } = "";

        public string? ClientName { get; set; }

        public string? ClientType { get; set; }

        public string? ClientFamily { get; set; }

        public string? Device { get; set; }

        public string? OperatingSystemFamily { get; set; }

        public string? OperatingSystem { get; set; }

        public bool IsSuspectedBOT { get; set; }
    }
}
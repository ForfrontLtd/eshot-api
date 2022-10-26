using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class BouncedContact
    {
        public int ID { get; set; }

        public string? BounceReason { get; set; }

        public BounceType BounceTypeID { get; set; }

        public DateTimeOffset BounceDate { get; set; }

        public int SubaccountID { get; set; }

        public int ContactID { get; set; }

        public int SendID { get; set; }

        public int CampaignID { get; set; }

        public long SendContactID { get; set; }

        public string? ResponseText { get; set; }
    }
}
namespace Forfront.eshot.API.Model
{
    public class SendContact
    {
        public int ID { get; set; }

        public int ContactID { get; set; }

        public int SendID { get; set; }

        public int CampaignID { get; set; }

        public int SubaccountID { get; set; }

        public int? BouncedContactID { get; set; }

        public string? PublicIP { get; set; }
    }
}
namespace Forfront.eshot.API.Model
{
    public class Link
    {
        public int ID { get; set; }

        public int CampaignID { get; set; }

        public int SendID { get; set; }

        public string URL { get; set; } = "";

        public string? FriendlyName { get; set; }

        public string? ReceivedInMessageFormat { get; set; }

        public IList<ClickedContact>? ClickedContacts { get; set; }
    }
}
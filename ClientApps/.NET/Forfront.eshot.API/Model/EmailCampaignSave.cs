namespace Forfront.eshot.API.Model
{
    public class EmailCampaignSave
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string Name { get; set; } = "";

        public int MessageDesignID { get; set; }

        public ICollection<int>? GroupIDs { get; set; }

        public ICollection<int>? ChannelPreferenceMappingIDs { get; set; }

        public GoogleAnalytics? GoogleAnalytics { get; set; }

        public MessageDesignSettingsOverride? MessageDesignSettingsOverride { get; set; }
    }
}
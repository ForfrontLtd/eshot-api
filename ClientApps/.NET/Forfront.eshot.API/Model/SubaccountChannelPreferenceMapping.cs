namespace Forfront.eshot.API.Model
{
    public class SubaccountChannelPreferenceMapping
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public Preference? Preference { get; set; }

        public Channel? Channel { get; set; }
    }
}
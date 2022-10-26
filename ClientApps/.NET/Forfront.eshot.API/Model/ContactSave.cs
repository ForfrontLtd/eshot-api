namespace Forfront.eshot.API.Model
{
    public class ContactSave : ContactTemplatedSave
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        /// <summary>
        /// If not supplied when adding a contact, this will default to the "Website" source
        /// Indicating that the contact was sourced from your website, such as via a sign-up form
        /// </summary>
        public int SourceID { get; set; }

        /// <summary>
        /// If supplied will subscribe you to these groups (it will not unsubscribe the contacts from any existing groups)
        /// </summary>
        public ICollection<int>? GroupIDs { get; set; } = new List<int>();

        /// <summary>
        /// If supplied will subscribe you to these preference / channel mappings (it will not unsubscribe the contacts from any existing preference mappings)
        /// </summary>
        public ICollection<int>? ChannelPreferenceMappingIDs { get; set; } = new List<int>();
    }
}
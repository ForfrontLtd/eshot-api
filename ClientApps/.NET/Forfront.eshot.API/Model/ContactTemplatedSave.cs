namespace Forfront.eshot.API.Model
{
    public class ContactTemplatedSave
    {
        /// <summary>
        /// Email address is required unless this is a mobile contact in which case the MobileNumber field must have a value supplied
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// MobileNumber is required unless this is an Email contact in which case the Email field must have a value supplied
        /// </summary>
        public string? MobileNumber { get; set; }

        public string? Salutation { get; set; }

        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Telephone { get; set; }

        public string? URN { get; set; }

        public string? Company { get; set; }

        public ICollection<ContactCustomFieldSave> CustomFields { get; set; } = new List<ContactCustomFieldSave>();
    }
}
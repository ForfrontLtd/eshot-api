using Forfront.eshot.API.Interfaces;

namespace Forfront.eshot.API.Model
{
    public class ContactDetails : IContact
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string Email { get; set; } = "";

        public string? MobileNumber { get; set; }

        public int SourceID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
    }
}
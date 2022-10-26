namespace Forfront.eshot.API.Model
{
    public class User
    {
        public int ID { get; set; }

        public bool IsAccountAdministrator { get; set; }

        public bool IsActive { get; set; }

        public string Email { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateTimeOffset? DeletedDate { get; set; }

        public DateTimeOffset? LastLoggedInDate { get; set; }

        public UserAccount[]? UserAccounts { get; set; }
    }
}
namespace Forfront.eshot.API.Model
{
    public class UserAccount
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public int UserID { get; set; }

        public bool IsAdministrator { get; set; }

        public Subaccount? Subaccount { get; set; }

        public User? User { get; set; }
    }
}
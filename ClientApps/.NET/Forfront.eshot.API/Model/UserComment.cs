namespace Forfront.eshot.API.Model
{
    public class UserComment
    {
        public int ID { get; set; }

        public int? MessageDesignID { get; set; }

        public int UserID { get; set; }

        public int? ContactID { get; set; }

        public int? SubaccountID { get; set; }

        public string Comment { get; set; } = "";

        public DateTimeOffset CreatedDate { get; set; }

        public int? ParentUserCommentID { get; set; }

        public UserComment? Parent { get; set; }

        public User? User { get; set; }

        public MessageDesign? MessageDesign { get; set; }

        public ContactDetails? Contact { get; set; }

        public Subaccount? Subaccount { get; set; }
    }
}
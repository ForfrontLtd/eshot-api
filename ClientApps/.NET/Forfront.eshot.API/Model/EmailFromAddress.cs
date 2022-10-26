namespace Forfront.eshot.API.Model
{
    public class EmailFromAddress
    {
        public int ID { get; set; }

        public string Email { get; set; } = "";

        public int SubaccountID { get; set; }

        public DateTimeOffset? LastUsedInSendAt { get; set; }
    }
}
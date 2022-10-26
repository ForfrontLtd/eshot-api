namespace Forfront.eshot.API.Model
{
    public class SignedUpContact
    {
        public Guid ID { get; set; }

        public int ContactID { get; set; }

        public int SubaccountID { get; set; }

        public int SignUpFormID { get; set; }

        public long? UserAgentID { get; set; }

        public DateTimeOffset SignedUpDate { get; set; }

        public DateTimeOffset OptInDate { get; set; }

        public DateTimeOffset? DoubleOptInConfirmationDate { get; set; }
    }
}
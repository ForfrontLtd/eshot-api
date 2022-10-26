namespace Forfront.eshot.API.Model
{
    public class MessageDesignEmailSenderDetails
    {
        public string? FromName { get; set; }

        public string? ReplyEmail { get; set; }

        public int EmailFromAddressID { get; set; }

        public int? FromNameContactFieldMappingID { get; set; }

        public int? ReplyEmailContactFieldMappingID { get; set; }
    }
}
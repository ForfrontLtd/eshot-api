namespace Forfront.eshot.API.Model
{
    public class EmailSingleSendCampaign : Campaign
    {
        public DateTimeOffset? SendDate { get; set; }

        public string? FromEmail { get; set; }

        public string? FromName { get; set; }

        public string? ReplyEmail { get; set; }

        public string? SubjectLine { get; set; }
    }
}
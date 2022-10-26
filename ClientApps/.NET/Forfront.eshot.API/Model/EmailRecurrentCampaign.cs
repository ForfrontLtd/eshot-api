namespace Forfront.eshot.API.Model
{
    public class EmailRecurrentCampaign : Campaign
    {
        public string? CronExpression { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? NextDueDate { get; set; }

        public DateTimeOffset? LastRunDate { get; set; }

        public int? StatusChangedByUserID { get; set; }

        public DateTimeOffset? StatusChangedDate { get; set; }

        public string? FromEmail { get; set; }

        public string? FromName { get; set; }

        public string? ReplyEmail { get; set; }

        public bool IsActive { get; set; }

        public string? SubjectLine { get; set; }
    }
}
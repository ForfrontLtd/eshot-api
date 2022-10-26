namespace Forfront.eshot.API.Model
{
    public class AutomatedSeriesCampaign : Campaign
    {
        public int? GroupID { get; set; }

        public int StepCount { get; set; }

        public int? StatusChangedByUserID { get; set; }

        public DateTimeOffset? StatusChangedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
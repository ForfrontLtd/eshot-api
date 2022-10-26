namespace Forfront.eshot.API.Model
{
    public class SMSSingleSendCampaign : Campaign
    {
        public DateTimeOffset? SendDate { get; set; }

        public bool HasGoogleTracking { get; set; }

        public bool HasMonitoredLinks { get; set; }

        public bool IsShortCode { get; set; }

        public string? FromNumberFormattedAsE164 { get; set; }
    }
}
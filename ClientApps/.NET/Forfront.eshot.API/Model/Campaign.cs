using Forfront.eshot.API.Enums;
using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    // When .NET 7 released, uncomment the below
    //[JsonDerivedType(typeof(AutomatedSeriesCampaign))]
    //[JsonDerivedType(typeof(EmailDateDrivenCampaign))]
    //[JsonDerivedType(typeof(EmailRecurrentCampaign))]
    //[JsonDerivedType(typeof(EmailResendCampaign))]
    //[JsonDerivedType(typeof(EmailSingleSendCampaign))]
    //[JsonDerivedType(typeof(EmailSplitTestCampaign))]
    //[JsonDerivedType(typeof(SMSSingleSendCampaign))]
    public class Campaign
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string Name { get; set; } = "";

        /// <summary>
        /// Campaign Type
        /// </summary>
        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public string? Type { get; set; }

        public int? CreatedByUserID { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public int? ModifiedByUserID { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public DateTimeOffset? DeletedDate { get; set; }

        public DateTimeOffset? ReportDeletedDate { get; set; }

        public bool IsSetup { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public CampaignStatus Status { get; set; }

        public DateTimeOffset? FirstSendDate { get; set; }

        public DateTimeOffset? LastSendDate { get; set; }

        public int TotalSent { get; set; }

        public bool CanBeModified { get; set; }

        public bool CanBeReported { get; set; }
    }
}
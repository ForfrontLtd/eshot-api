using Forfront.eshot.API.Enums;
using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    // When .NET 7 released, uncomment the below
    //[JsonDerivedType(typeof(EmailSend))]
    //[JsonDerivedType(typeof(SMSSend))]
    public class Send
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public int SubaccountID { get; set; }

        public int CampaignID { get; set; }

        public byte SendTypeID { get; set; }

        public int? MessageDesignID { get; set; }

        public string? SendType { get; set; }

        public string? Status { get; set; }

        public string? SubStatus { get; set; }

        public DateTimeOffset? SendDate { get; set; }

        public DateTimeOffset? SendCompletedDate { get; set; }

        public bool IsOutbox { get; set; }

        public string? CampaignType { get; set; }

        public string? MessageType { get; set; }

        public int ContactCount { get; set; }

        public string? CreatedBy { get; set; }

        public int? CreatedByUserID { get; set; }

        public int? ConfirmedByUserID { get; set; }

        public bool IsArchived { get; set; }

        public long Sequence { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
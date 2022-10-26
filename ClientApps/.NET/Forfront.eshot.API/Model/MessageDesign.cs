using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class MessageDesign
    {
        public int ID { get; set; }

        public string Name { get; set; } = "";

        public MessageType MessageTypeID { get; set; }

        public SendType SendTypeID { get; set; }

        public int SubaccountID { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        public int? ModifiedByUserID { get; set; }

        public bool IsValid { get; set; }

        public int? ClonedMessageDesignID { get; set; }

        public bool HasMonitoredLinks { get; set; }

        public bool HasDynamicContent { get; set; }

        public Subaccount? Subaccount { get; set; }
    }
}
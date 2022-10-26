using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class SMSFromAddress
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string Number { get; set; } = "";

        public string? FriendlyName { get; set; }

        public SMSRegion SmsRegionID { get; set; }

        public bool IsShortCode { get; set; }
    }
}
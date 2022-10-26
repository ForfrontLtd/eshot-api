using System.Runtime.Serialization;

namespace Forfront.eshot.API.Enums
{
    public enum CampaignType
    {
        [EnumMember(Value = "Single Send")]
        SingleSend = 1,
        [EnumMember(Value = "Automated Series")]
        AutomatedSeries = 2,
        [EnumMember(Value = "Recurrent")]
        Recurrent = 3,
        [EnumMember(Value = "Resend")]
        Resend = 4,
        [EnumMember(Value = "Date Driven")]
        DateDriven = 5,
        [EnumMember(Value = "Split Test")]
        SplitTest = 6,
        [EnumMember(Value = "Single Send (SMS)")]
        SingleSendSMS = 7
    }
}
using System.Runtime.Serialization;

namespace Forfront.eshot.API.Enums
{
    public enum SplitTestSubstatus
    {
        [EnumMember(Value = "Creating")]
        Creating = 1,
        [EnumMember(Value = "Sending Splits")]
        SendingSplits = 2,
        [EnumMember(Value = "Waiting For Winner Selection")]
        WaitingForWinnerSelection = 3,
        [EnumMember(Value = "Sending Winner")]
        SendingWinner = 4,
        [EnumMember(Value = "Complete")]
        Complete = 5,
        [EnumMember(Value = "Cancelled")]
        Cancelled = 6
    }
}
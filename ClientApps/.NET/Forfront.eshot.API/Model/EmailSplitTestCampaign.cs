using Forfront.eshot.API.Enums;
using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    public class EmailSplitTestCampaign : Campaign
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SplitTestSubstatus Substatus { get; set; }

        public int TotalContacts { get; set; }

        public int TotalSplits { get; set; }
    }
}
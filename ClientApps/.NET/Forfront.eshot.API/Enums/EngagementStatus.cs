using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EngagementStatus
    {
        [Display(Name = "Unsubscribed")]
        Unsubscribed = 1,

        [Display(Name = "Hard bounced")]
        Hardbounced = 2,

        [Display(Name = "Slipping away")]
        SlippingAway = 3,

        [Display(Name = "Engaged")]
        Engaged = 4,

        [Display(Name = "Disengaged")]
        Disengaged = 5,

        [Display(Name = "Never sent")]
        NeverSent = 6
    }
}
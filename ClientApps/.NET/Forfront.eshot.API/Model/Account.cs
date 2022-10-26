using Forfront.eshot.API.Enums;
using System.Text.Json.Serialization;

namespace Forfront.eshot.API.Model
{
    /// <summary>
    /// This is just a subset of the fields, to see all available fields, you can get the definition from https://rest-api.e-shot.net?$metadata-extended
    /// (This is the same as $metadata, but includes a description detailing the purpose of each entity and their properties)
    /// </summary>
    public class Account
    {
        public int ID { get; set; }

        public string AccountNumber { get; set; } = "";

        public string CompanyName { get; set; } = "";

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AccountType AccountType { get; set; }

        public bool IsSharedContainer { get; set; }

        /// <summary>
        /// Max expiry date of all sub-accounts
        /// </summary>
        public DateTimeOffset? ExpiryDate { get; set; }

        public bool HasExpired { get; set; }

        public bool IsSuspended { get; set; }

        public int ContactsAllowance { get; set; }

        public int ContactsInUse { get; set; }

        public int ContactsRemaining { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public SendLimitMode SendLimitType { get; set; }

        public int? MonthlySendLimit { get; set; }

        public int? RemainingCredits { get; set; }

        public bool IsSalesforceIntegrationEnabled { get; set; }

        public bool IsMicrosoftDynamicsIntegrationEnabled { get; set; }

        public PlanType PlanType { get; set; }

        public bool HasDeliverabilityDashboard { get; set; }
    }
}
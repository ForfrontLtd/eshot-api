using Forfront.eshot.API.Interfaces;

namespace Forfront.eshot.RestApi.Console.Customised
{
    /// <summary>
    /// This class will be specific to each client as each client has their own set of custom fields
    /// Simply add each custom field to this class with the appropriate data type using the display name you setup for the custom field
    /// You can determine which custom fields you have defined in your subaccount either via the Contact Field Manager in the console application
    /// The field names below are all fields returned from the /Contacts/Export endpoint, excluding your custom fields (which you can add to).
    /// You can see all available fields (you only need to choose the ones you're interested in) that you can query by calling /Contacts/Export with no parameters specified
    /// </summary>
    public class Contact : IContact
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string Email { get; set; } = "";

        public string? MobileNumber { get; set; }

        public int SourceID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Company { get; set; }

        public string? Telephone { get; set; }

        public string? URN { get; set; }

        //public EngagementStatus EmailStatusID { get; set; }

        //public EngagementStatus MobileStatusID { get; set; }

        //public SMSRegion MobileRegion { get; set; }

        //public DateTimeOffset CreatedDate { get; set; }

        //public DateTimeOffset? ModifiedDate { get; set; }

        //public DateTimeOffset? EmailUnsubscribedDate { get; set; }

        //public DateTimeOffset? SmsUnsubscribedDate { get; set; }

        //public DateTimeOffset? EmailHardBounceDate { get; set; }

        //public DateTimeOffset? DoubleOptInConfirmationDate { get; set; }

        //public DateTimeOffset? LastSoftBouncedDate { get; set; }

        //public DateTimeOffset? LastSentDate { get; set; }

        //public DateTimeOffset? LastDisplayedDate { get; set; }

        //public DateTimeOffset? LastClickedDate { get; set; }

        // The below would assume that you have defined a custom field of type "String" with a display name of "MyCustomField"
        //public string? MyCustomField { get; set; }

        // The below would assume that you have defined a custom field of type "Number" with a display name of "MyOtherCustomField"
        //public int? MyOtherCustomField { get; set; }
    }
}
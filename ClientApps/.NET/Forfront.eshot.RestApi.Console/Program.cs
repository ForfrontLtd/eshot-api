using Forfront.eshot.API.Enums;
using Forfront.eshot.API.Exceptions;
using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;
using Forfront.eshot.RestApi.Console.Customised;
using System.Text.Json;

try
{
    Console.ForegroundColor = ConsoleColor.White;
    string? apiKey = null;
    while (apiKey == null)
    {
        Console.WriteLine("Please enter your API key and hit \"Enter\"");
        apiKey = Console.ReadLine();
    }

    // pre-requisites:
    // 1. You can obtain your API key from "Accounts settings" page accessible from the settings icon, and then clicking on the "Integrations" tab
    // 2. The examples below assume you have setup a custom field called "MyCustomField"
    EshotHttpClient client = new("https://rest-api.e-shot.net", apiKey);

    /*
        Find information about the user making the api request
     */
    var whoami = client.Users.WhoAmI();

    /*
        Find the Account available to the REST API key
     */
    var account = client.Account.Get();

    /*
        Find all Subaccounts available to the REST API key
     */
    var subaccounts = client.Subaccounts.Get();
    var subaccountId = subaccounts.Min(w => w.ID); // for demonstration purposes

    /*
        Find all Sources available in a subaccount
     */
    var sources = client.Sources.Get(subaccountId);
    var exampleSourceId = sources.First().ID; // for demonstration purposes

    /*
        Create a group "Demonstration 1"
     */
    var group = client.Groups.Save(new GroupSave { Name = "Demonstration 1", SubaccountID = subaccountId });

    /*
        Find the newly created group
     */
    var groupFilter = new FieldFilter();
    groupFilter.AddEqualityComparison("SubaccountID", subaccountId);
    groupFilter.AddEqualityComparison("Name", "Demonstration 1");
    var addedGroup = client.Groups.Get(groupFilter).Single();

    Console.WriteLine($"Found added group: {addedGroup.Name}");

    var exampleGroupId = addedGroup.ID;

    /*
        Create a templated import of group, source or preference mappings to use to import contacts into
     */
    var template = client.ContactImportTemplates.Save(new ContactImportTemplateSave
    {
        GroupID = exampleGroupId, // example for demonstration purposes
        SourceID = exampleSourceId, // example for demonstration purposes
        ImportActionType = ImportActionType.Repopulate,
        SubaccountID = subaccountId,
        Name = "Demonstration Import Template 1"
    });

    /*
        Import a CSV of contacts into a pre-defined import template (bulk imports are asynchronous)
     */
    TemplatedUpload templateUpload = client.ContactImports.ImportContactsUsingTemplateFromFile(template.id, @"C:\Temp\eshot.import.example.csv" /* change to be the path to your csv to import */);

    int attemptCount = 0;
    while (!string.IsNullOrWhiteSpace(templateUpload.Token))
    {
        var result = client.ContactImports.GetImportStatus(templateUpload.Token);

        switch (result.ImportStatusID)
        {
            case ImportStatus.Success:
                Console.ForegroundColor = ConsoleColor.Green;
                break;

            case ImportStatus.Error:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case ImportStatus.Waiting:
                if (attemptCount == 0)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }

        Console.WriteLine("");
        Console.WriteLine(JsonSerializer.Serialize(result));

        if (result.ImportStatusID != ImportStatus.Waiting || attemptCount > 10 /* very large files will take longer or if there is a large import queue */)
            break;

        Thread.Sleep(1000);

        attemptCount += 1;
    }

    /*
        Save an individual contact into a group using a templated import
     */
    var joeBlogs2Id = client.Contacts.TemplatedSave(template.id, new ContactTemplatedSave
    {
        Email = "joe.blogs.1@automatedtesting.forfront.net",
        CustomFields = { new ContactCustomFieldSave { DisplayName = "MyCustomField", FieldValue = "Hurrah!" } }
        // NOTE: make sure the display name matches the display name in the contact field manager for the fields marked as Custom Fields
    });

    /*
        Save an individual contact into a group without using a templated import
     */
    var joeBlogs3Id = client.Contacts.Save(new ContactSave
    {
        SubaccountID = subaccountId,
        SourceID = exampleSourceId,
        GroupIDs = new[] {group.id},
        Email = "joe.blogs.2@automatedtesting.forfront.net",
        CustomFields = { new ContactCustomFieldSave { DisplayName = "MyCustomField", FieldValue = "Hurrah!" } }
    });

    /*
        Find the contacts in the newly created group returning fields; ID, SubaccountID, Email, Firstname, Lastname, MyCustomField
     */
    ContactFilter filter = new();
    // NOTE if you don't specify the fields to return, all available fields will be returned which is a more expensive request than getting only the fields you are interested in
    //filter.SelectFields = new List<string>() { "ID", "Email", "Firstname", "Lastname", "SubaccountID, MyCustomField" };
    filter.SetSelectFieldsToPropertyNames<SlimContact>(); // The above commented out line does the same as this line
    filter.AddEqualityComparison("SubaccountID", subaccountId);
    filter.GroupID = exampleGroupId;
    var contacts = client.Contacts.Get<SlimContact>(filter); // You can configure the "Contact" class to include only the properties that you are interested in

    foreach (var contact in contacts)
    {
        Console.WriteLine($"Found contact: {contact.Email} in group: {addedGroup.Name}");
    }

    /*
        Delete the contact template previously added
     */
    client.ContactImportTemplates.Delete(template.id);

    Console.WriteLine($"Deleted the added contact import template");

    /*
        Delete the contacts previously added
     */
    foreach (var contact in contacts)
        client.Contacts.Delete(contact.ID);

    Console.WriteLine($"Deleted the added contacts");

    /*
        Delete the group previously added
        (if you don't delete the contacts, they will be deleted if they are only present in a single group - this functionality may change in the future so a group can be deleted without necessarily deleting the contacts)
     */
    client.Groups.Delete(addedGroup.ID);

    Console.WriteLine($"Deleted the added group");

    /*
        Find all active email from addresses
     */
    var emailFromAddresses = client.EmailFromAddresses.Get();

    /*
        Find all active SMS from addresses
     */
    var smsFromAddresses = client.SMSFromAddresses.Get();

    /*
        Find all contacts that have signed up from a sign up form
     */
    var signedUpContacts = client.SignedUpContacts.Get();

    /*
        Find Single Send campaigns
     */
    var campaigns = client.Campaigns.GetSingleSend();
    if (campaigns.Length > 0)
    {
        var campaignId = campaigns.Min(w => w.ID); // for demonstration purposes

        /*
            Find campaign sends
         */
        var sends = client.Sends.GetByCampaign(campaignId);

        /*
            Find contacts who bounced on links in the campaign
         */
        var bounced = client.BouncedContacts.GetByCampaign(campaignId);

        /*
            Find contacts who clicked on links in the campaign
         */
        var clicked = client.ClickedContacts.GetByCampaign(campaignId);

        /*
            Find contacts who displayed on links in the campaign
         */
        var displayed = client.DisplayedContacts.GetByCampaign(campaignId);

        /*
            Find contacts who unsubscribed on links in the campaign
         */
        var unsubscribed = client.UnsubscribedContacts.GetByCampaign(campaignId);

        /*
            Find contacts who were sent the campaign
         */
        var sendContacts = client.SendContacts.GetByCampaign(campaignId);

        /*
            Find links in the sent the campaign
         */
        var links = client.Links.GetByCampaign(campaignId);

        /*
            Find links in the sent the campaign
         */
        var userAgents = client.UserAgents.GetByCampaign(campaignId);
    }

    /* The following is an example call to create a campaign (if you specify the ID, it will update an existing campaign */
    /*
    var createdCampaignId = client.Campaigns.Save(new EmailCampaignSave
    {
        SubaccountID = 2,
        Name = "<campaign name goes here>",
        MessageDesignID = 1,
        GroupIDs = new[] { 123 },
        GoogleAnalytics = new GoogleAnalytics { },
        MessageDesignSettingsOverride = new MessageDesignSettingsOverride
        {
            EmailSenderDetails = new MessageDesignEmailSenderDetails
            {
                EmailFromAddressID = 1,
                FromName = "<from name goes here>",
                ReplyEmail = "<optional reply email goes here>",
            },
            SubjectLine = "<subject goes here>"
        }
    });
    */
}
catch (RestApiException ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(JsonSerializer.Serialize(ex.Details));
}

Console.ForegroundColor = ConsoleColor.White;
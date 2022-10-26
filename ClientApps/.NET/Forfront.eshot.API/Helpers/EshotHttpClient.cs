using Forfront.eshot.API.Model;

namespace Forfront.eshot.API.Helpers
{
    public class EshotHttpClient
    {
        private readonly EshotInternalHttpClient _client;
        private EshotAccount? _account = null;
        private EshotBouncedContacts? _bouncedContacts = null;
        private EshotCampaigns? _campaigns = null;
        private EshotClickedContacts? _clickedContacts = null;
        private EshotComments? _userComments = null;
        private EshotContactImports? _contactImports = null;
        private EshotContactImportTemplates? _contactImportTemplates = null;
        private EshotContacts? _contacts = null;
        private EshotDisplayedContacts? _displayedContacts = null;
        private EshotEmailFromAddresses? _emailFromAddresses = null;
        private EshotGroups? _groups = null;
        private EshotLinks? _links = null;
        private EshotSends? _sends = null;
        private EshotSendContacts? _sendContacts = null;
        private EshotSignedUpContacts? _signedUpContacts = null;
        private EshotSMSFromAddresses? _smsFromAddresses = null;
        private EshotSources? _sources = null;
        private EshotSubaccountChannelPreferenceMappings? _subaccountChannelPreferenceMappings = null;
        private EshotSubaccountContactFieldMappings? _subaccountContactFieldMappings = null;
        private EshotSubaccounts? _subaccounts = null;
        private EshotUnsubscribedContacts? _unsubscribedContacts = null;
        private EshotUserAgents? _userAgents = null;
        private EshotUsers? _users = null;

        /// <summary>
        ///
        /// </summary>
        /// <param name="baseAddress"></param>
        /// <param name="apiKey"></param>
        /// <param name="ignoreSslErrors">Only relevant if using self-cert local certificate. Not relevant in dev/uat or production environments</param>
        /// <exception cref="ArgumentNullException"></exception>
        public EshotHttpClient(string baseAddress, string apiKey, bool ignoreSslErrors = false)
        {
            _client = new EshotInternalHttpClient(baseAddress, apiKey, ignoreSslErrors);
        }

        public EshotAccount Account => _account ??= new EshotAccount(_client);
        public EshotClickedContacts ClickedContacts => _clickedContacts ??= new EshotClickedContacts(_client);
        public EshotDisplayedContacts DisplayedContacts => _displayedContacts ??= new EshotDisplayedContacts(_client);
        public EshotContactImports ContactImports => _contactImports ??= new EshotContactImports(_client);
        public EshotContactImportTemplates ContactImportTemplates => _contactImportTemplates ??= new EshotContactImportTemplates(_client);
        public EshotContacts Contacts => _contacts ??= new EshotContacts(_client);
        public EshotEmailFromAddresses EmailFromAddresses => _emailFromAddresses ??= new EshotEmailFromAddresses(_client);
        public EshotGroups Groups => _groups ??= new EshotGroups(_client);
        public EshotLinks Links => _links ??= new EshotLinks(_client);
        public EshotSends Sends => _sends ??= new EshotSends(_client);
        public EshotSendContacts SendContacts => _sendContacts ??= new EshotSendContacts(_client);
        public EshotSignedUpContacts SignedUpContacts => _signedUpContacts ??= new EshotSignedUpContacts(_client);
        public EshotSMSFromAddresses SMSFromAddresses => _smsFromAddresses ??= new EshotSMSFromAddresses(_client);
        public EshotSources Sources => _sources ??= new EshotSources(_client);
        public EshotSubaccountChannelPreferenceMappings SubaccountChannelPreferenceMappings => _subaccountChannelPreferenceMappings ??= new EshotSubaccountChannelPreferenceMappings(_client);
        public EshotSubaccountContactFieldMappings SubaccountContactFieldMappings => _subaccountContactFieldMappings ??= new EshotSubaccountContactFieldMappings(_client);
        public EshotSubaccounts Subaccounts => _subaccounts ??= new EshotSubaccounts(_client);
        public EshotUsers Users => _users ??= new EshotUsers(_client);
        public EshotComments UserComments => _userComments ??= new EshotComments(_client);
        public EshotCampaigns Campaigns => _campaigns??= new EshotCampaigns(_client);
        public EshotBouncedContacts BouncedContacts => _bouncedContacts ??= new EshotBouncedContacts(_client);
        public EshotUnsubscribedContacts UnsubscribedContacts => _unsubscribedContacts ??= new EshotUnsubscribedContacts(_client);
        public EshotUserAgents UserAgents => _userAgents ??= new EshotUserAgents(_client);
    }
}
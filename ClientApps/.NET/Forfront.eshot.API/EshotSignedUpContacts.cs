using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Contacts that have signed-up to group or preference via a sign up form
    /// </summary>
    public class EshotSignedUpContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotSignedUpContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public SignedUpContact[] Get()
        {
            return Get(new FieldFilter());
        }

        public SignedUpContact[] Get(FieldFilter filter)
        {
            return _client.Get<SignedUpContact>("SignedUpContacts", filter);
        }

        public SignedUpContact[] GetByContact(int id)
        {
            CampaignSendContactFilter filter = new();
            filter.AddEqualityComparison("ContactID", id);
            return Get(filter);
        }
    }
}
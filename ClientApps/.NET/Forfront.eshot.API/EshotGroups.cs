using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;
using System.Dynamic;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Groups provide a mechanism to group contacts together for simpler targeting / analysis
    /// Groups retrieval, save and delete operations
    /// </summary>
    public class EshotGroups
    {
        private readonly EshotInternalHttpClient _client;

        public EshotGroups(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Group[] Get(FieldFilter filter)
        {
            return _client.Get<Group>("Groups", filter);
        }

        public Group[] Get(int subaccountId)
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("SubaccountID", subaccountId);
            return Get(filter);
        }

        public Id Save(GroupSave group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            return _client.PostJson<Id, GroupSave>($"Groups", group);
        }

        public void UpdateContactFieldValues(int groupId, ContactFieldsUpdate contactFieldsUpdate)
        {
            if (contactFieldsUpdate == null)
                throw new ArgumentNullException(nameof(contactFieldsUpdate));

            _client.PostJson($"Groups({groupId})/Contacts/Update", contactFieldsUpdate);
        }

        public void AddContact(int groupId, int contactId)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;

            expando.Add("@odata.id", $"{_client.Client.BaseAddress}/Contacts({contactId})");

            _client.PostDictionaryJson($"Groups({groupId})/Contacts/$ref", expando);
        }

        public void RemoveContact(int groupId, int contactId)
        {
            _client.Delete($"Groups({groupId})/Contacts/$ref?$id={contactId}");
        }

        public void EmailUnsubscribeAll(int groupId)
        {
            _client.Post($"Groups({groupId})/UnsubscribeEmail");
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            _client.Delete($"Groups({id})");
        }
    }
}
using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Interfaces;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Contacts retrieval and single save operations
    /// </summary>
    public class EshotContacts
    {
        private readonly EshotInternalHttpClient _client;

        public EshotContacts(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <summary>
        /// Use this if you are regularly saving contacts to the same group / preferences
        /// </summary>
        /// <param name="id">ContactImportTemplateID</param>
        /// <param name="contact"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Id TemplatedSave(int id, ContactTemplatedSave contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            return _client.PostJson<Id, ContactTemplatedSave>($"Contacts/TemplatedSave({id})", contact);
        }

        /// <summary>
        /// With this method you can choose which groups and preference mappings you with to save a contact to as part of the request body
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Id Save(ContactSave contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            return _client.PostJson<Id, ContactSave>($"Contacts", contact);
        }

        public T[] Get<T>(ContactFilter filter) where T : class, IContact, new()
        {
            return _client.Get<T>("Contacts/Export", filter);
        }

        public T[] Get<T>(int subaccountId) where T : class, IContact, new()
        {
            ContactFilter filter = new();
            filter.SubaccountID = subaccountId;
            return Get<T>(filter);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            _client.Delete($"Contacts({id})");
        }
    }
}
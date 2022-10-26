using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Interfaces;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Represents user comments and can apply to a Design or Contact
    /// </summary>
    public class EshotComments
    {
        private readonly EshotInternalHttpClient _client;

        public EshotComments(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public UserComment[] Get<T>(FieldFilter filter) where T : class, IContact
        {
            return _client.Get<UserComment>("UserComments", filter);
        }

        public UserComment[] GetDesignComments<T>(int designId) where T : class, IContact
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("MessageDesignID", designId);
            return Get<T>(new FieldFilter());
        }

        public UserComment[] GetContactComments<T>(int contactId) where T : class, IContact
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("ContactID", contactId);
            return Get<T>(new FieldFilter());
        }

        public UserComment[] GetUserComments<T>(int userId) where T : class, IContact
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("UserID", userId);
            return Get<T>(new FieldFilter());
        }

        public Id Create(UserCommentSave comment)
        {
            return _client.PostJson<Id, UserCommentSave>($"UserComments/Create", comment);
        }

        /// <summary>
        /// Call only allowed by an account admin
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _client.Delete($"UserComments({id})");
        }
    }
}
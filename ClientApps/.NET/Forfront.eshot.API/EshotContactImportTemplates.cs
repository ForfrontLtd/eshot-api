using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Used to template contact import - bulk or single save operations by stipulating the groups and preferences the contacts are to be subscribed to
    /// </summary>
    public class EshotContactImportTemplates
    {
        private readonly EshotInternalHttpClient _client;

        public EshotContactImportTemplates(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ContactImportTemplate[] Get(FieldFilter filter)
        {
            return _client.Get<ContactImportTemplate>("ContactImportTemplates", filter);
        }

        public ContactImportTemplate[] Get(int subaccountId)
        {
            FieldFilter filter = new();
            filter.AddEqualityComparison("SubaccountID", subaccountId);
            filter.Expansions.Add("ContactImportTemplateChannelPreferenceMappings");
            return Get(filter);
        }

        public Id Save(ContactImportTemplateSave template)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template));

            return _client.PostJson<Id, ContactImportTemplateSave>($"ContactImportTemplates", template);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            _client.Delete($"ContactImportTemplates({id})");
        }
    }
}
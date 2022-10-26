using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// Bulk import activities...
    /// </summary>
    public class EshotContactImports
    {
        private readonly EshotInternalHttpClient _client;

        public EshotContactImports(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public ContactImport GetImportStatus(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));
            return _client.GetOne<ContactImport>($"ContactImports('{token}')");
        }

        public TemplatedUpload ImportContactsUsingTemplateFromFile(int contactImportTemplateId, string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));
            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);
            return ImportContactsUsingTemplateFromFile(contactImportTemplateId, File.ReadAllBytes(filePath));
        }

        public TemplatedUpload ImportContactsUsingTemplateFromFile(int contactImportTemplateId, byte[] bytes)
        {
            if (contactImportTemplateId <= 0)
                throw new ArgumentOutOfRangeException(nameof(contactImportTemplateId));
            return _client.PostFileAndReturnJson<TemplatedUpload>($"ContactImports/TemplatedUpload({contactImportTemplateId})", bytes);
        }
    }
}
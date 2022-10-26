using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class ContactImport
    {
        public string Token { get; set; } = "";

        public int SubaccountID { get; set; }

        public int? ContactsImported { get; set; }

        public int? ContactsReceived { get; set; }

        public ImportStatus ImportStatusID { get; set; }

        public ImportType ImportTypeID { get; set; }

        public bool IsPartiallyImport { get; set; }

        public bool ExceedsLimit { get; set; }

        public bool HasInvalidHeader { get; set; }

        public bool HasInvalidData { get; set; }

        public bool HasImportedContacts { get; set; }

        public bool ErrorProcessingFile { get; set; }

        public DateTimeOffset StartedDate { get; set; }

        public DateTimeOffset? CompletedDate { get; set; }

        public string? AdditionalInfo { get; set; }

        public string? ErrorFileName { get; set; }

        public string? ErrorFileUrl { get; set; }
    }
}
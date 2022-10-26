using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class ContactImportTemplate
    {
        public int ID { get; set; }

        public string Name { get; set; } = "";

        public int SubaccountID { get; set; }

        public int GroupID { get; set; }

        public int SourceID { get; set; }

        public ImportActionType ImportActionType { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public ICollection<ContactImportTemplateChannelPreferenceMapping>? ContactImportTemplateChannelPreferenceMappings { get; set; }
    }
}
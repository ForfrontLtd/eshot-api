using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class ContactImportTemplateSave
    {
        public int ID { get; set; }

        public string Name { get; set; } = "";

        public int SubaccountID { get; set; }

        public int GroupID { get; set; }

        public int SourceID { get; set; }

        public ImportActionType ImportActionType { get; set; }

        public IList<ContactImportTemplateChannelPreferenceMappingSave>? ChannelPreferenceMappings { get; set; }
    }
}
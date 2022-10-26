using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class ContactCustomFieldUpdate
    {
        public TextOperator TextOperation { get; set; }

        public string? DisplayName { get; set; }

        public string? FieldValue { get; set; }
    }
}
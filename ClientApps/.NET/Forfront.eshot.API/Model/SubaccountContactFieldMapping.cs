using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Model
{
    public class SubaccountContactFieldMapping
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string DisplayName { get; set; } = "";

        public int? FieldLength { get; set; }

        public byte? DecimalPlaces { get; set; }

        public bool IsCustomField { get; set; }

        public CustomFieldDataType ContactFieldDataTypeID { get; set; }

        public int? PicklistID { get; set; }
    }
}
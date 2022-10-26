namespace Forfront.eshot.API.Model
{
    public class ContactFieldsUpdate
    {
        public int SubaccountID { get; set; }

        public ICollection<ContactCustomFieldUpdate>? CustomFields { get; set; }
    }
}
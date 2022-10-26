namespace Forfront.eshot.API.Model
{
    public class GroupSave
    {
        public int ID { get; set; }

        public int SubaccountID { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";
    }
}
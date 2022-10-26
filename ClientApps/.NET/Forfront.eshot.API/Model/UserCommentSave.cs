namespace Forfront.eshot.API.Model
{
    public class UserCommentSave
    {
        public int? MessageDesignID { get; set; }

        public int? ContactID { get; set; }

        public string Comment { get; set; } = "";

        public int? ParentUserCommentID { get; set; }
    }
}
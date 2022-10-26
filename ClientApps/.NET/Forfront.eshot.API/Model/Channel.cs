namespace Forfront.eshot.API.Model
{
    /// <summary>
    /// E.g. Email or SMS. Most likely you don't need to concern yourself with this
    /// </summary>
    public class Channel
    {
        public int ID { get; set; }

        public string Name { get; set; } = "";
    }
}
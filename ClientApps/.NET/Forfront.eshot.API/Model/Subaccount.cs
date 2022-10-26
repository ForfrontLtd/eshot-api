namespace Forfront.eshot.API.Model
{
    /// <summary>
    /// This is just a subset of the fields, to see all available fields, you can get the definition from https://rest-api.e-shot.net?$metadata-extended 
    /// (This is the same as $metadata, but includes a description detailing the purpose of each entity and their properties)
    /// </summary>
    public class Subaccount
    {
        public int ID { get; set; }

        public string Name { get; set; } = "";

        public string FriendlyName { get; set; } = "";

        public DateTimeOffset ExpiryDate { get; set; }
    }
}
namespace Forfront.eshot.API.Helpers
{
    public class ContactFilter : FieldFilter
    {
        public int? SubaccountID { get; set; }

        public int? PreferenceID { get; set; }

        public int? GroupID { get; set; }

        public override string GetODataFilterQueryStringParameter()
        {
            if (SubaccountID.HasValue)
                AddEqualityComparison("SubaccountID", SubaccountID.Value);

            string filter = base.GetODataFilterQueryStringParameter();

            if (string.IsNullOrWhiteSpace(filter) && GroupID == null && SubaccountID == null && PreferenceID == null)
                return "";

            const string ODataFilterCommand = "$filter=";
            const string AndOperator = " AND ";

            if (GroupID.HasValue && GroupID > 0)
            {
                string prepend = filter.Length == 0 ? ODataFilterCommand : AndOperator;
                filter += $"{prepend}Groups/any(g:g/ID eq {GroupID})";
            }

            if (PreferenceID.HasValue && PreferenceID > 0)
            {
                string prepend = filter.Length == 0 ? ODataFilterCommand : AndOperator;
                filter += $"{prepend}Preferences/any(p:p/ID eq {PreferenceID})";
            }

            if (filter.EndsWith(AndOperator))
                filter = filter.Substring(0, filter.Length - 5);

            return filter;
        }
    }
}
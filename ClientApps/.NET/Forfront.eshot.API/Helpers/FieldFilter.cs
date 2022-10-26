using System.Reflection;

namespace Forfront.eshot.API.Helpers
{
    public class FieldFilter
    {
        private readonly IList<FieldComparisonBase> _comparisons = new List<FieldComparisonBase>();

        /// <summary>
        /// Used in paging
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Used in paging or to limit the number of rows returned by the query
        /// </summary>
        public int? Take { get; set; }

        public IList<string> SelectFields = new List<string>();

        public IList<string> Expansions = new List<string>();

        public void SetSelectFieldsToPropertyNames<T>() where T : class
        {
            SelectFields.Clear();

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach (var property in properties)
                SelectFields.Add(property.Name);
        }

        public void AddEqualityComparison(string fieldName, DateTime value)
        {
            string comparisonValue = $"'{value:yyyy-MM-dd}'";
            if (!_comparisons.Any(w => w.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase) && w.Value == comparisonValue))
                _comparisons.Add(new FieldEqualsComparison { FieldName = fieldName, Value = comparisonValue });
        }

        public void AddEqualityComparison(string fieldName, string value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            string comparisonValue = $"'{value}'";
            if (!_comparisons.Any(w => w.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase) && w.Value == comparisonValue))
                _comparisons.Add(new FieldEqualsComparison { FieldName = fieldName, Value = comparisonValue });
        }

        public void AddEqualityComparison(string fieldName, bool value)
        {
            string comparisonValue = value.ToString().ToLower();
            if (!_comparisons.Any(w => w.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase) && w.Value == comparisonValue))
                _comparisons.Add(new FieldEqualsComparison { FieldName = fieldName, Value = comparisonValue });
        }

        public void AddEqualityComparison(string fieldName, long value)
        {
            string comparisonValue = value.ToString();
            if (!_comparisons.Any(w => w.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase) && w.Value == comparisonValue))
                _comparisons.Add(new FieldEqualsComparison { FieldName = fieldName, Value = comparisonValue });
        }

        public void AddEqualityComparison(string fieldName, decimal value)
        {
            string comparisonValue = value.ToString();
            if (!_comparisons.Any(w => w.FieldName.Equals(fieldName, StringComparison.OrdinalIgnoreCase) && w.Value == comparisonValue))
                _comparisons.Add(new FieldEqualsComparison { FieldName = fieldName, Value = comparisonValue });
        }

        public string GetODataExpandQueryStringParameter()
        {
            string expand = "$expand=";

            foreach (var name in Expansions)
            {
                expand += $"{name.Trim()},";
            }

            if (expand.EndsWith(","))
                expand = expand.Substring(0, expand.Length - 1);

            if (expand.Length == 8)
                return "";

            return expand;
        }

        public string GetODataSelectQueryStringParameter()
        {
            string select = "$select=";

            foreach (var name in SelectFields)
            {
                select += $"{name.Trim()},";
            }

            if (select.EndsWith(","))
                select = select.Substring(0, select.Length - 1);

            if (select.Length == 8)
                return "";
            return select;
        }

        public virtual string GetODataFilterQueryStringParameter()
        {
            if (_comparisons == null)
                return "";

            const string ODataFilterCommand = "$filter=";
            const string AndOperator = " AND ";
            string filter = ODataFilterCommand;

            if (_comparisons != null)
            {
                foreach (FieldComparisonBase field in _comparisons)
                {
                    string @operator = "";

                    switch (field)
                    {
                        case FieldNotEqualsComparison:
                            @operator = "ne";
                            break;

                        case FieldEqualsComparison:
                            @operator = "eq";
                            break;

                        case FieldLessThanComparison:
                            @operator = "lt";
                            break;

                        case FieldGreaterThanComparison:
                            @operator = "gt";
                            break;
                    }

                    filter += $"{field.FieldName} {@operator} {field.Value}{AndOperator}";
                }
            }

            if (filter.EndsWith(AndOperator))
                filter = filter.Substring(0, filter.Length - 5);

            if (filter.Length == 8)
                return "";

            return filter;
        }
    }
}
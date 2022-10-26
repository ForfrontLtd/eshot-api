using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Helpers
{
    public class CampaignFilter : FieldFilter
    {
        public int? SubaccountID { get; set; }

        public int? CampaignID { get; set; }

        public CampaignType? CampaignType { get; set; }

        public override string GetODataFilterQueryStringParameter()
        {
            if (SubaccountID.HasValue)
                AddEqualityComparison("SubaccountID", SubaccountID.Value);
            if (CampaignID.HasValue)
                AddEqualityComparison("ID", CampaignID.Value);
            if (CampaignType.HasValue)
                AddEqualityComparison("CampaignTypeID", (int)CampaignType.Value);

            return base.GetODataFilterQueryStringParameter();
        }
    }
}
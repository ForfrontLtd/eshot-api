using Forfront.eshot.API.Enums;

namespace Forfront.eshot.API.Helpers
{
    public class CampaignSendContactFilter : FieldFilter
    {
        public int? SubaccountID { get; set; }

        public int? CampaignID { get; set; }

        public int? SendID { get; set; }

        public override string GetODataFilterQueryStringParameter()
        {
            if (SubaccountID.HasValue)
                AddEqualityComparison("SubaccountID", SubaccountID.Value);
            if (CampaignID.HasValue)
                AddEqualityComparison("CampaignID", CampaignID.Value);
            if (SendID.HasValue)
                AddEqualityComparison("SendID", SendID.Value);

            return base.GetODataFilterQueryStringParameter();
        }
    }
}
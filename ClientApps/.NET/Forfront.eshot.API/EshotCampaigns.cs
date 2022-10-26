using Forfront.eshot.API.Enums;
using Forfront.eshot.API.Helpers;
using Forfront.eshot.API.Model;

namespace Forfront.eshot.API
{
    /// <summary>
    /// e-shot Users
    /// </summary>
    public class EshotCampaigns
    {
        private readonly EshotInternalHttpClient _client;

        public EshotCampaigns(EshotInternalHttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public Campaign[] Get(CampaignFilter filter)
        {
            return _client.Get<Campaign>("Campaigns", filter);
        }

        public AutomatedSeriesCampaign[] GetAutomatedSeries(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.AutomatedSeries;
            return _client.Get<AutomatedSeriesCampaign>("Campaigns", filter);
        }

        public EmailDateDrivenCampaign[] GetDateDriven(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.DateDriven;
            return _client.Get<EmailDateDrivenCampaign>("Campaigns", filter);
        }

        public EmailRecurrentCampaign[] GetRecurrent(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.Recurrent;
            return _client.Get<EmailRecurrentCampaign>("Campaigns", filter);
        }

        public EmailResendCampaign[] GetResend(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.Resend;
            return _client.Get<EmailResendCampaign>("Campaigns", filter);
        }

        public EmailSingleSendCampaign[] GetSingleSend(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.SingleSend;
            return _client.Get<EmailSingleSendCampaign>("Campaigns", filter);
        }

        public SMSSingleSendCampaign[] GetSingleSendSMS(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.SingleSendSMS;
            return _client.Get<SMSSingleSendCampaign>("Campaigns", filter);
        }

        public EmailSplitTestCampaign[] GetSplitTest(CampaignFilter filter)
        {
            filter.CampaignType = CampaignType.SplitTest;
            return _client.Get<EmailSplitTestCampaign>("Campaigns", filter);
        }

        public AutomatedSeriesCampaign[] GetAutomatedSeries()
        {
            return GetAutomatedSeries(new CampaignFilter());
        }

        public EmailDateDrivenCampaign[] GetDateDriven()
        {
            return GetDateDriven(new CampaignFilter());
        }

        public EmailRecurrentCampaign[] GetRecurrent()
        {
            return GetRecurrent(new CampaignFilter());
        }

        public EmailResendCampaign[] GetResend()
        {
            return GetResend(new CampaignFilter());
        }

        public EmailSingleSendCampaign[] GetSingleSend()
        {
            return GetSingleSend(new CampaignFilter());
        }

        public SMSSingleSendCampaign[] GetSingleSendSMS()
        {
            return GetSingleSendSMS(new CampaignFilter());
        }

        public EmailSplitTestCampaign[] GetSplitTest()
        {
            return GetSplitTest(new CampaignFilter());
        }

        public Campaign[] Get()
        {
            return Get(new CampaignFilter());
        }

        public Id SaveEmailSingleSend(EmailCampaignSave save)
        {
            return _client.PostJson<Id, EmailCampaignSave>("Campaigns/EmailSingleSend", save);           
        }
    }
}
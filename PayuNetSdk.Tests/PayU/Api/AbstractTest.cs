namespace PayuNetSdk.Tests.PayU.Api
{
    using PayuNetSdk.PayU.Messages.Enums;

    public abstract class AbstractTest
    {
        protected string apiKey = "012345678901";
		protected string apiLogin = "012345678901";
		protected string merchantId = "1";
        protected Language Language = Language.en;
		protected bool isTest = false;
        protected string paymentsUrl = "https://stg.api.payulatam.com/payments-api/";
        protected string reportsUrl = "https://stg.api.payulatam.com/reports-api";
    }
}

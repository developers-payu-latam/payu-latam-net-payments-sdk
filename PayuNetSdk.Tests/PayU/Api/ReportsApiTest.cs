using System;
using System.Collections.Generic;
using NUnit.Framework;
using PayuNetSdk.PayU;
using PayuNetSdk.PayU.Api;
using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.Messages.Enums;
using RestSharp;
using RestSharp.Deserializers;
using FizzWare.NBuilder.Generators;

namespace PayuNetSdk.Tests.PayU.Api
{
    public class ReportsApiTest : AbstractTest
    {
        [Test]
        public void PingTest()
        {
            PayUReports.ApiKey = base.apiKey;
            PayUReports.ApiLogin = base.apiLogin;
            PayUReports.Language = Language.en;
            PayUReports.ReportsUrl = base.reportsUrl;

            PingReportResponse response = PayUReports.Instance.DoPing();

            Assert.NotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
        }

        [Test]
        public void GetOrderDetailTest() 
        {
            PayUReports.ApiKey = base.apiKey;
            PayUReports.ApiLogin = base.apiLogin;
            PayUReports.Language = Language.en;
            PayUReports.ReportsUrl = base.reportsUrl;
            PayUReports.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(PayUParameterName.ORDER_ID, Convert.ToString(6194290));

            OrderReportResponse orderResponse = PayUReports.Instance.GetOrderDetail(parameters);

        }

        [Test]
        public void GetOrderDetailByReferenceCodeTest()
        {
            PayUReports.ApiKey = base.apiKey;
            PayUReports.ApiLogin = base.apiLogin;
            PayUReports.Language = Language.en;
            PayUReports.ReportsUrl = base.reportsUrl;
            PayUReports.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(PayUParameterName.REFERENCE_CODE, "A1B2C3");

            OrderReportListResponse orderResponse = PayUReports.Instance.GetOrderDetailByReferenceCode(parameters);

        }

        [Test]
        public void GetTransactionResponse()
        {
            PayUReports.ApiKey = base.apiKey;
            PayUReports.ApiLogin = base.apiLogin;
            PayUReports.Language = Language.en;
            PayUReports.ReportsUrl = base.reportsUrl;
            PayUReports.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(PayUParameterName.TRANSACTION_ID, "5d90aef9-ac41-4217-843e-c1e3e070dcb2");

            TransactionReportResponse orderResponse = PayUReports.Instance.GetTransactionResponse(parameters);

        }

        [Test]
        public void DoAuthorizationTest()
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string nameOnCard = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            parameters.Add(PayUParameterName.PAYER_NAME, nameOnCard);

            parameters.Add(PayUParameterName.PAYER_CITY, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PAYER_STREET, GetRandom.NumericString(4));
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString()); // revisar validacion
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(10000);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);
        }
    }
}

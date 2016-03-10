using System;
using System.Collections.Generic;
using System.Globalization;
using FizzWare.NBuilder.Generators;
using NUnit.Framework;
using PayuNetSdk.PayU;
using PayuNetSdk.PayU.Api;
using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.Messages.Enums;
using PayuNetSdk.PayU.Model;
using PayuNetSdk.PayU.Model.Payments;
using PayuNetSdk.PayU.Model.Personal;
using PayuNetSdk.PayU.Util.DataStructures;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System.Text.RegularExpressions;
using System.Text;
using PayuNetSdk.PayU.Exceptions;

namespace PayuNetSdk.Tests.PayU.Api
{
    public class PaymentsApiTest : AbstractTest
    {
        /// <summary>
        /// Pings the test.
        /// </summary>
        [Test]
        public void PingTest()
        {
            
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl + "asdf";

            PingResponse response = PayUPayments.Instance.DoPing();

            

            Assert.NotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
        }

        [Test]
        public void PingInvalidCredentialsTest()
        {

            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin + "INVALID";
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl;

            PingResponse response = PayUPayments.Instance.DoPing();

            Assert.NotNull(response);
            Assert.AreEqual(ResponseCode.ERROR, response.ResponseCode);
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void PingInvalidUrlTest()
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl.Replace(".com", ".net");

            PayUPayments.Instance.DoPing();
        }

        //// AUTHORIZATION

        /// <summary>
        /// Does the authorization test.
        /// </summary>
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1,9).ToString()); // revisar validacion
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
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##") );

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "as");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);
        }

        /// <summary>
        /// Does the authorization invalid data credit card different to franchise test.
        /// </summary>
        [Test]
        public void DoAuthorizationInvalidDataCreditCardDifferentToFranchiseTest()
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

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "MASTERCARD");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.ERROR, paymentResponse.ResponseCode);
        }

        /// <summary>
        /// Does the authorization invalid date test.
        /// </summary>
        [Test]
        public void DoAuthorizationInvalidDateFormatTest()
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.es;
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

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "12/2015");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.ERROR, paymentResponse.ResponseCode);
        }

        /// <summary>
        /// Does the authorization missing parameter test.
        /// </summary>
        [Test]
        public void DoAuthorizationMissingParameterTest()
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

            //int accountId = 8; // Panamá
            //parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100);
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
            Assert.AreEqual(ResponseCode.ERROR, paymentResponse.ResponseCode);
        }

        /// <summary>
        /// Does the authorization missing parameter1 test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DoAuthorizationMissingParameter1Test()
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.es;
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

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            //parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

        }

        [Test]
        public void DoCaptureTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);

            // Capture

            IDictionary<string, string> captureParameters = new Dictionary<string, string>();

            captureParameters.Add(PayUParameterName.TRANSACTION_ID, paymentResponse.TransactionResponse.TransactionId);
            captureParameters.Add(PayUParameterName.ORDER_ID, paymentResponse.TransactionResponse.OrderId.ToString());

            PaymentResponse paymentResponseCapture = PayUPayments.Instance.DoCapture(captureParameters);

            Assert.IsNotNull(paymentResponseCapture);
        }

        [Test]
        public void DoCaptureInvalidOrderTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);

            // Capture

            IDictionary<string, string> captureParameters = new Dictionary<string, string>();

            captureParameters.Add(PayUParameterName.TRANSACTION_ID, paymentResponse.TransactionResponse.TransactionId);
            captureParameters.Add(PayUParameterName.ORDER_ID, (paymentResponse.TransactionResponse.OrderId + 100).ToString());

            PaymentResponse paymentResponseCapture = PayUPayments.Instance.DoCapture(captureParameters);

            Assert.IsNotNull(paymentResponseCapture);
        }

        [Test]
        public void DoCaptureTransactionIdEmptyTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);

            // Capture

            IDictionary<string, string> captureParameters = new Dictionary<string, string>();

            captureParameters.Add(PayUParameterName.TRANSACTION_ID, null);
            captureParameters.Add(PayUParameterName.ORDER_ID, (paymentResponse.TransactionResponse.OrderId).ToString());

            PaymentResponse paymentResponseCapture = PayUPayments.Instance.DoCapture(captureParameters);

            Assert.IsNotNull(paymentResponseCapture);
        }

        [Test]
        public void DoAuthorizationCaptureTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100.50);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            /*decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));*/

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Console.WriteLine(paymentResponse.MessageError);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationCaptureInvalidDataCreditCardDifferentToFranchiseTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100.50);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            /*decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));*/

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "MASTERCARD");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Console.WriteLine(paymentResponse.MessageError);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoVoidTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);

            // Void

            IDictionary<string, string> voidParameters = new Dictionary<string, string>();

            voidParameters.Add(PayUParameterName.TRANSACTION_ID, paymentResponse.TransactionResponse.TransactionId);
            voidParameters.Add(PayUParameterName.ORDER_ID, paymentResponse.TransactionResponse.OrderId.ToString());

            PaymentResponse voidPaymentResponse = PayUPayments.Instance.DoVoid(voidParameters);

            Assert.IsNotNull(voidPaymentResponse);
        }

        [Test]
        public void DoRefundTest()
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
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString());
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.PA.ToString()); //  GetRandom.Enumeration<PaymentCountry>();

            int accountId = 8; // Panamá
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            // Cookie of the current user session
            parameters.Add(PayUParameterName.COOKIE, "cookie_" + DateTime.Now.Ticks);

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            /*decimal transactionTaxValue = new decimal(16);
            parameters.Add(PayUParameterName.TAX_VALUE, transactionTaxValue.ToString("#.##"));

            decimal transactionReturnBase = new decimal(100);
            parameters.Add(PayUParameterName.TAX_RETURN_BASE, transactionReturnBase.ToString("#.##"));*/

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);

            // Refund

            IDictionary<string, string> refundParameters = new Dictionary<string, string>();

            refundParameters.Add(PayUParameterName.TRANSACTION_ID, paymentResponse.TransactionResponse.TransactionId);
            refundParameters.Add(PayUParameterName.ORDER_ID, paymentResponse.TransactionResponse.OrderId.ToString());

            PaymentResponse refundPaymentResponse = PayUPayments.Instance.DoRefund(refundParameters);

            Assert.IsNotNull(refundPaymentResponse);
        }

        [Test]
        public void GetPaymentMethodsTest() 
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            PaymentMethodsResponse response =  PayUPayments.Instance.GetPaymentMethods();

            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.PaymentMethods.Count, 1);
        }

        [Test]
        public void GetPseBanksTest()
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.CO.ToString());

            BankInfoResponse response = PayUPayments.Instance.GetPseBanks(parameters);

            Assert.IsNotNull(response);

        }

        [Test]
        public void DoAuthorizationCaptureWithBalotoTest()
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
            parameters.Add(PayUParameterName.PAYER_DNI, GetRandom.NumericString(5));

            int accountId = 1; // Colombia
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            parameters.Add(PayUParameterName.PAYMENT_METHOD, PaymentMethod.BALOTO.ToString());

            parameters.Add(PayUParameterName.EXPIRATION_DATE,
                String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now.AddDays(1))); // SortableDateTime Eg: '1982-06-13T14:45:00' 

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.PENDING, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.PENDING_TRANSACTION_CONFIRMATION, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationCaptureWithOxxoTest()
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
            parameters.Add(PayUParameterName.PAYER_DNI, GetRandom.NumericString(5));

            int accountId = 11; // Mexico
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            parameters.Add(PayUParameterName.PAYMENT_METHOD, PaymentMethod.OXXO.ToString());

            parameters.Add(PayUParameterName.EXPIRATION_DATE,
                String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now.AddDays(1))); // SortableDateTime Eg: '1982-06-13T14:45:00' 

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.PENDING, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.PENDING_TRANSACTION_CONFIRMATION, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationCaptureWithSevenElevenTest()
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
            parameters.Add(PayUParameterName.PAYER_DNI, GetRandom.NumericString(5));

            int accountId = 11; // Mexico
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            parameters.Add(PayUParameterName.PAYMENT_METHOD, PaymentMethod.SEVEN_ELEVEN.ToString());

            parameters.Add(PayUParameterName.EXPIRATION_DATE,
                String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now.AddDays(1))); // SortableDateTime Eg: '1982-06-13T14:45:00' 

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.PENDING, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.PENDING_TRANSACTION_CONFIRMATION, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationCaptureWithBoletoTest()
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
            parameters.Add(PayUParameterName.PAYER_DNI, "83661983000134");

            int accountId = 3; // Brasil
            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());
            parameters.Add(PayUParameterName.CURRENCY, Currency.USD.ToString());

            string orderReferenceCode = GetRandom.String(6, true, null);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);
            parameters.Add(PayUParameterName.DESCRIPTION, GetRandom.Phrase(20));

            decimal transactionValue = new decimal(100);
            parameters.Add(PayUParameterName.VALUE, transactionValue.ToString("#.##"));

            parameters.Add(PayUParameterName.PAYMENT_METHOD, PaymentMethod.BOLETO_BANCARIO.ToString());

            parameters.Add(PayUParameterName.PAYER_STREET, "ABC 123");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "ABC 123");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "0190030");

            parameters.Add(PayUParameterName.EXPIRATION_DATE,
                String.Format(CultureInfo.InvariantCulture, "{0:s}", DateTime.Now.AddDays(1))); // SortableDateTime Eg: '1982-06-13T14:45:00' 

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.PENDING, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.PENDING_TRANSACTION_CONFIRMATION, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationAndCaptureWithoutSecurityCodeTest()
        {
            PayUPayments.ApiKey = base.apiKey;
            PayUPayments.ApiLogin = base.apiLogin;
            PayUPayments.Language = Language.en;
            PayUPayments.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            String nameOnCard = GetRandom.FirstName() + " " + GetRandom.LastName();
            parameters.Add(PayUParameterName.PAYER_NAME, nameOnCard);

            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "3");

            parameters.Add(PayUParameterName.COUNTRY, PaymentCountry.CO.ToString());

            // Colombia account
            int accountId = 1;

            parameters.Add(PayUParameterName.ACCOUNT_ID, accountId.ToString());

            // Currency
            Currency txCurrency = Currency.COP;
            parameters.Add(PayUParameterName.CURRENCY, txCurrency.ToString());
            String orderReferenceCode = "A1B2C3" + GetRandom.NumericString(10);
            parameters.Add(PayUParameterName.REFERENCE_CODE, orderReferenceCode);

            String description = "ALL IN 5";
            parameters.Add(PayUParameterName.DESCRIPTION, description);

            // Transaction value
            decimal txValue = 100;
            parameters.Add(PayUParameterName.VALUE, txValue.ToString("#.##"));

            // Credit card values

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            parameters.Add(PayUParameterName.PROCESS_WITHOUT_CVV2, "true");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

        }

        [Test]
        public void TestRegex1()
        {
            string text = "property: order.referenceCode, message: No puede ser vacio";
            Match match = Regex.Match(text, @"property:\s*\w*[.]{1}(\w*)[,]{1}\s*\w*message:\s*(.*)");
        }

    }
}

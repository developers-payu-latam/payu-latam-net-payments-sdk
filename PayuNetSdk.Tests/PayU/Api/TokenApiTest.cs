namespace PayuNetSdk.Tests.PayU.Api
{
    using NUnit.Framework;
    using PayuNetSdk.PayU.Api;
    using PayuNetSdk.PayU.Messages.Enums;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Messages;
    using FizzWare.NBuilder.Generators;
    using PayuNetSdk.PayU;
    using System;
    using PayuNetSdk.PayU.Exceptions;

    public class TokenApiTest : AbstractTest
    {
        [Test]
        public void CreateTokenTest()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string nameOnCard = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            parameters.Add(PayUParameterName.PAYER_NAME, nameOnCard);
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            parameters.Add(PayUParameterName.PAYER_ID, GetRandom.NumericString(6));

            TokenResponse response = PayUTokens.Instance.Create(parameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
            Assert.IsNotNull(response.CreditCardToken.TokenId);
            Assert.AreEqual(36, response.CreditCardToken.TokenId.Length);
        }

        [Test]
        public void GetCreditCardTokenTest()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string nameOnCard = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            parameters.Add(PayUParameterName.PAYER_NAME, nameOnCard);
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            string payerId = GetRandom.NumericString(6);
            parameters.Add(PayUParameterName.PAYER_ID, payerId);

            TokenResponse response = PayUTokens.Instance.Create(parameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
            Assert.IsNotNull(response.CreditCardToken.TokenId);
            Assert.AreEqual(36, response.CreditCardToken.TokenId.Length);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            findParameters.Add(PayUParameterName.PAYER_ID, payerId);
            findParameters.Add(PayUParameterName.TOKEN_ID, response.CreditCardToken.TokenId);

            TokenInfoResponse tokenInfoResponse = PayUTokens.Instance.Find(findParameters);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenInfoResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationiWithTokenTest()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            IDictionary<string, string> tokenParameters = new Dictionary<string, string>();

            string nameOnCardForToken = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            tokenParameters.Add(PayUParameterName.PAYER_NAME, nameOnCardForToken);
            tokenParameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            tokenParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            tokenParameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            tokenParameters.Add(PayUParameterName.PAYER_ID, GetRandom.NumericString(6));

            TokenResponse tokenResponse = PayUTokens.Instance.Create(tokenParameters);

            Assert.IsNotNull(tokenResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenResponse.ResponseCode);
            Assert.IsNotNull(tokenResponse.CreditCardToken.TokenId);
            Assert.AreEqual(36, tokenResponse.CreditCardToken.TokenId.Length);

            // Do authorization
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString()); // revisar validacion

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

            // The token is assigned
            parameters.Add(PayUParameterName.TOKEN_ID, tokenResponse.CreditCardToken.TokenId);
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void DoAuthorizationAndCaptureWithToken()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            IDictionary<string, string> tokenParameters = new Dictionary<string, string>();

            string nameOnCardForToken = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            tokenParameters.Add(PayUParameterName.PAYER_NAME, nameOnCardForToken);
            tokenParameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            tokenParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            tokenParameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            tokenParameters.Add(PayUParameterName.PAYER_ID, GetRandom.NumericString(6));

            TokenResponse tokenResponse = PayUTokens.Instance.Create(tokenParameters);

            Assert.IsNotNull(tokenResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenResponse.ResponseCode);
            Assert.IsNotNull(tokenResponse.CreditCardToken.TokenId);
            Assert.AreEqual(36, tokenResponse.CreditCardToken.TokenId.Length);

            // Do authorization and Capture
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString()); // revisar validacion

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

            // The token is assigned
            parameters.Add(PayUParameterName.TOKEN_ID, tokenResponse.CreditCardToken.TokenId);
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorizationAndCapture(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);
        }

        [Test]
        public void GetCreditCardTokenWithDatesTest()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string nameOnCard = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            parameters.Add(PayUParameterName.PAYER_NAME, nameOnCard);
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            string payerId = GetRandom.NumericString(6);
            parameters.Add(PayUParameterName.PAYER_ID, payerId);

            TokenResponse response = PayUTokens.Instance.Create(parameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
            Assert.IsNotNull(response.CreditCardToken.TokenId);
            Assert.AreEqual(36, response.CreditCardToken.TokenId.Length);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            findParameters.Add(PayUParameterName.PAYER_ID, payerId);
            findParameters.Add(PayUParameterName.START_DATE, "2013-01-01T00:00:00");

            TokenInfoResponse tokenInfoResponse = PayUTokens.Instance.Find(findParameters);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenInfoResponse.ResponseCode);
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetCreditCardTokenWithoutDataTest()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string nameOnCard = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            parameters.Add(PayUParameterName.PAYER_NAME, nameOnCard);
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            string payerId = GetRandom.NumericString(6);
            parameters.Add(PayUParameterName.PAYER_ID, payerId);

            TokenResponse response = PayUTokens.Instance.Create(parameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
            Assert.IsNotNull(response.CreditCardToken.TokenId);
            Assert.AreEqual(36, response.CreditCardToken.TokenId.Length);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            //findParameters.Add(PayUParameterName.PAYER_ID, "925bkj8dn92hnjug15tro4j");

            TokenInfoResponse tokenInfoResponse = PayUTokens.Instance.Find(findParameters);
            Assert.Fail();
        }

        [Test]
        public void DeleteTokenTest()
        {

            PayUTokens.ApiKey = base.apiKey;
            PayUTokens.ApiLogin = base.apiLogin;
            PayUTokens.Language = Language.en;
            PayUTokens.PaymentsUrl = base.paymentsUrl;
            PayUPayments.MerchantId = 1;

            IDictionary<string, string> tokenParameters = new Dictionary<string, string>();

            string nameOnCardForToken = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());
            tokenParameters.Add(PayUParameterName.PAYER_NAME, nameOnCardForToken);
            tokenParameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            tokenParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/12");
            tokenParameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");
            tokenParameters.Add(PayUParameterName.PAYER_ID, GetRandom.NumericString(6));

            TokenResponse tokenResponse = PayUTokens.Instance.Create(tokenParameters);

            Assert.IsNotNull(tokenResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenResponse.ResponseCode);
            Assert.IsNotNull(tokenResponse.CreditCardToken.TokenId);
            Assert.AreEqual(36, tokenResponse.CreditCardToken.TokenId.Length);

            // Do authorization
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, GetRandom.Short(1, 9).ToString()); // revisar validacion

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

            // The token is assigned
            parameters.Add(PayUParameterName.TOKEN_ID, tokenResponse.CreditCardToken.TokenId);
            parameters.Add(PayUParameterName.CREDIT_CARD_SECURITY_CODE, "495");

            PaymentResponse paymentResponse = PayUPayments.Instance.DoAuthorization(parameters);

            Assert.IsNotNull(paymentResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, paymentResponse.ResponseCode);
            Assert.AreEqual(36, paymentResponse.TransactionResponse.TransactionId.Length); // :) 36 UUID length
            Assert.AreEqual(TransactionState.APPROVED, paymentResponse.TransactionResponse.State);
            Assert.Greater(paymentResponse.TransactionResponse.OrderId, 1);
            Assert.AreEqual(TransactionResponseCode.APPROVED, paymentResponse.TransactionResponse.ResponseCode);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            findParameters.Add(PayUParameterName.PAYER_ID, tokenResponse.CreditCardToken.PayerId);
            findParameters.Add(PayUParameterName.TOKEN_ID, tokenResponse.CreditCardToken.TokenId);

            TokenInfoResponse tokenInfoResponse = PayUTokens.Instance.Find(findParameters);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenInfoResponse.ResponseCode);

            // Remove 

            IDictionary<string, string> removeParameters = new Dictionary<string, string>();

            removeParameters.Add(PayUParameterName.PAYER_ID, tokenResponse.CreditCardToken.PayerId);
            removeParameters.Add(PayUParameterName.TOKEN_ID, tokenResponse.CreditCardToken.TokenId);

            TokenResponse tokenRemovedResponse = PayUTokens.Instance.Remove(removeParameters);
            Assert.AreEqual(ResponseCode.SUCCESS, tokenInfoResponse.ResponseCode);
        }
    }
}

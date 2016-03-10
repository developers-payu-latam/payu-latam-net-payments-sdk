
namespace PayuNetSdk.Tests.PayU.Api
{
    using NUnit.Framework;
    using PayuNetSdk.PayU.Api;
    using PayuNetSdk.PayU.Messages.Enums;
    using System.Collections.Generic;
    using PayuNetSdk.PayU;
    using PayuNetSdk.PayU.Messages;
    using FizzWare.NBuilder.Generators;
    using System.Text.RegularExpressions;
    using System;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Model.Subscriptions;
    using PayuNetSdk.PayU.Exceptions;

    public class RecurringPaymentTest : AbstractTest
    {

        //////////////////////////////////////////////////////////////////////////////
        //// CREATE ONLY CUSTOMER
        //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the customer success test.
        /// </summary>
        [Test]
        public void CreateCustomerSuccessTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);
        }

        /// <summary>
        /// Creates the customer invalid email test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateCustomerInvalidEmailTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, customerName.ToLower().Replace(" ", "")); // Invalid :P

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Creates the customer name too long test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateCustomerNameTooLongTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.String(1000));
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Creates the customer invalid parameters test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateCustomerInvalidParametersTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.String(1000));
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, customerName.ToLower().Replace(" ", "")); // Invalid :P

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Creates the customer empty parameters test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateCustomerEmptyParametersTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, null);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, null); // Invalid :P

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);
            Assert.Fail();
        }

        //////////////////////////////////////////////////////////////////////////////
        //// CUSTOMER AND CREDIT CARD
        //////////////////////////////////////////////////////////////////////////////

        [Test]
        public void CreateCustomerWithCreditCardSuccessTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "3005551213");

            CustomerResponse customerResponse = PayUCustomers.Instance.CreateCustomerWithCreditCard(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);
            Assert.IsNotNull(customerResponse.Customer.CreditCards[0]);
        }

        /// <summary>
        /// Creates the customer with credit card invalid credit card test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateCustomerWithCreditCardInvalidCreditCardTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "EPICSAXGUY");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "3005551213");

            CustomerResponse customerResponse = PayUCustomers.Instance.CreateCustomerWithCreditCard(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Gets the customer test.
        /// </summary>
        [Test]
        public void GetCustomerTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);

            Assert.IsNotNull(findCustomerResponse);
            Assert.AreEqual(findCustomerResponse.Customer.Id, customerResponse.Customer.Id);
        }

        /// <summary>
        /// Gets the customer test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetCustomerWithoutParametersTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);
            Assert.Fail();
        }

        /// <summary>
        /// Gets the customer test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetCustomerWithEmptyParametersTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.CUSTOMER_ID, null);
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);

            Assert.Fail();
        }

        /// <summary>
        /// Gets the customer test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetCustomerNoExistsTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.CUSTOMER_ID, "EPICSAXGUY1234567890");
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);

            Assert.Fail();
        }

        /// <summary>
        /// Updates the customer test.
        /// </summary>
        [Test]
        public void UpdateCustomerSuccessTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);

            Assert.IsNotNull(findCustomerResponse);
            Assert.AreEqual(findCustomerResponse.Customer.Id, customerResponse.Customer.Id);

            // Update

            IDictionary<string, string> updateParameters = new Dictionary<string, string>();
            updateParameters.Add(PayUParameterName.CUSTOMER_ID, findCustomerResponse.Customer.Id);
            updateParameters.Add(PayUParameterName.CUSTOMER_NAME, "Mr/Ms. " + customerName);
            CustomerResponse modifiedCustomerResponse = PayUCustomers.Instance.Update(updateParameters);

            Assert.IsNotNull(modifiedCustomerResponse);
            Assert.AreEqual("Mr/Ms. " + customerName, modifiedCustomerResponse.Customer.FullName);
        }

        /// <summary>
        /// Deletes the customer test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void DeleteCustomerTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);

            Assert.IsNotNull(findCustomerResponse);
            Assert.AreEqual(findCustomerResponse.Customer.Id, customerResponse.Customer.Id);

            // Delete

            IDictionary<string, string> deleteParameters = new Dictionary<string, string>();
            deleteParameters.Add(PayUParameterName.CUSTOMER_ID, findCustomerResponse.Customer.Id);
            CustomerResponse deleteCustomerResponse = PayUCustomers.Instance.Delete(deleteParameters);

            // Find

            CustomerResponse verifyDeleteParameters = PayUCustomers.Instance.Find(findParameters);
            Assert.Fail();
        }

        /// <summary>
        /// Deletes the customer test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void DeleteCustomerAlreadyDeletedTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parameters);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
            Assert.IsNotNull(customerResponse.Customer.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            CustomerResponse findCustomerResponse = PayUCustomers.Instance.Find(findParameters);

            Assert.IsNotNull(findCustomerResponse);
            Assert.AreEqual(findCustomerResponse.Customer.Id, customerResponse.Customer.Id);

            // Delete

            IDictionary<string, string> deleteParameters = new Dictionary<string, string>();
            deleteParameters.Add(PayUParameterName.CUSTOMER_ID, findCustomerResponse.Customer.Id);
            CustomerResponse deleteCustomerResponse = PayUCustomers.Instance.Delete(deleteParameters);

            // Re-delete :P

            deleteCustomerResponse = PayUCustomers.Instance.Delete(deleteParameters);
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void DeleteCustomerNotExistCustomerTest()
        {
            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            // Delete

            IDictionary<string, string> deleteParameters = new Dictionary<string, string>();
            deleteParameters.Add(PayUParameterName.CUSTOMER_ID, "EFD8592KHZP9246HQP55Y8HG");
            CustomerResponse deleteCustomerResponse = PayUCustomers.Instance.Delete(deleteParameters);
            Assert.Fail();

        }

        //////////////////////////////////////////////////////////////////////////////
        //// CREATE ONLY PLAN
        //////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the plan success test.
        /// </summary>
        [Test]
        public void CreatePlanSuccessTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);
        }

        /// <summary>
        /// Creates the plan with  invalid parameters test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(InvalidCastException))]
        public void CreatePlanInvalidParametersTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "MOCK");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);
        }

        /// <summary>
        /// Creates the plan with empty parameter test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreatePlanWithEmptyParameterTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, string.Empty);
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Creates the plan without account test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreatePlanWithoutAccountTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MES");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Edits the plan success test.
        /// </summary>
        [Test]
        public void GetPlanSuccessTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);

            Assert.IsNotNull(findSubscriptionPlanResponse);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.Id, subscriptionPlanResponse.SubscriptionPlan.Id);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.PlanCode, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
        }

        /// <summary>
        /// Edits the plan success test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetPlanWithoutPlanCreatedTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_CODE, "258DJHF54766GNC852GN78Q");
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);
            Assert.Fail();
        }

        /// <summary>
        /// Edits the plan success test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetPlanWithEmptyParameterTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_CODE, string.Empty);
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetPlanWithAnotherParameterTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_ID, "91675548313854");
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);
            Assert.Fail();
        }

        [Test]
        public void EditPlanSuccessTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);

            Assert.IsNotNull(findSubscriptionPlanResponse);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.Id, subscriptionPlanResponse.SubscriptionPlan.Id);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.PlanCode, subscriptionPlanResponse.SubscriptionPlan.PlanCode);

            // Update

            IDictionary<string, string> editParameters = new Dictionary<string, string>();
            editParameters.Add(PayUParameterName.PLAN_CODE, findSubscriptionPlanResponse.SubscriptionPlan.PlanCode);
            editParameters.Add(PayUParameterName.PLAN_DESCRIPTION, findSubscriptionPlanResponse.SubscriptionPlan.Description + "Modified");
            editParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            editParameters.Add(PayUParameterName.PLAN_VALUE, "60000");

            SubscriptionPlanResponse subscriptionUpdatedPlanResponse = PayUPlans.Instance.Update(editParameters);

            Assert.IsNotNull(subscriptionUpdatedPlanResponse);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.Id, subscriptionUpdatedPlanResponse.SubscriptionPlan.Id);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.PlanCode, subscriptionUpdatedPlanResponse.SubscriptionPlan.PlanCode);
            Assert.AreEqual(new decimal(60000), subscriptionUpdatedPlanResponse.SubscriptionPlan.AdditionalValues[0].Value);
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void EditPlanWithoutCreatedPlanTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            // Update

            IDictionary<string, string> editParameters = new Dictionary<string, string>();
            editParameters.Add(PayUParameterName.PLAN_CODE, "98285985857");
            editParameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Modified");
            editParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            editParameters.Add(PayUParameterName.PLAN_VALUE, "60000");

            SubscriptionPlanResponse subscriptionUpdatedPlanResponse = PayUPlans.Instance.Update(editParameters);
            Assert.Fail();
        }

        [Test]
        public void DeletePlanSuccessTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);

            Assert.IsNotNull(findSubscriptionPlanResponse);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.Id, subscriptionPlanResponse.SubscriptionPlan.Id);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.PlanCode, subscriptionPlanResponse.SubscriptionPlan.PlanCode);

            // Delete

            IDictionary<string, string> editParameters = new Dictionary<string, string>();
            editParameters.Add(PayUParameterName.PLAN_CODE, findSubscriptionPlanResponse.SubscriptionPlan.PlanCode);

            SubscriptionPlanResponse subscriptionUpdatedPlanResponse = PayUPlans.Instance.Delete(editParameters);

            Assert.IsNotNull(subscriptionUpdatedPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionUpdatedPlanResponse.ResponseCode);
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void DeletePlanWithPlanDeletedTest()
        {
            PayUPlans.ApiKey = base.apiKey;
            PayUPlans.ApiLogin = base.apiLogin;
            PayUPlans.Language = Language.en;
            PayUPlans.PaymentsUrl = base.paymentsUrl;
            PayUPlans.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.PLAN_TAX, "10000");
            parameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            parameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Find

            IDictionary<string, string> findParameters = new Dictionary<string, string>();
            findParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            SubscriptionPlanResponse findSubscriptionPlanResponse = PayUPlans.Instance.Find(findParameters);

            Assert.IsNotNull(findSubscriptionPlanResponse);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.Id, subscriptionPlanResponse.SubscriptionPlan.Id);
            Assert.AreEqual(findSubscriptionPlanResponse.SubscriptionPlan.PlanCode, subscriptionPlanResponse.SubscriptionPlan.PlanCode);

            // Delete

            IDictionary<string, string> editParameters = new Dictionary<string, string>();
            editParameters.Add(PayUParameterName.PLAN_CODE, findSubscriptionPlanResponse.SubscriptionPlan.PlanCode);

            SubscriptionPlanResponse subscriptionUpdatedPlanResponse = PayUPlans.Instance.Delete(editParameters);

            Assert.IsNotNull(subscriptionUpdatedPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionUpdatedPlanResponse.ResponseCode);

            subscriptionUpdatedPlanResponse = PayUPlans.Instance.Delete(editParameters);
            Assert.Fail();
        }

        //////////////////////////////////////////////////////////////////////////////
        //// CREATE ONLY CREDIT CARD
        //////////////////////////////////////////////////////////////////////////////

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateCreditCardInvalidCustomerIdTest()
        {
            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");


            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);
            Assert.Fail();
        }

        /// <summary>
        /// Creates the credit card success test.
        /// </summary>
        [Test]
        public void CreateCreditCardSuccessTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");


            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);
        }

        /// <summary>
        /// Gets the credit card success test.
        /// </summary>
        [Test]
        public void GetCreditCardSuccessTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);

            // Find 

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            findParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);

            CreditCardResponse findCreditCardResponse = PayUCreditCard.Instance.Find(findParameters);

            Assert.IsNotNull(findCreditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, findCreditCardResponse.ResponseCode);
            Assert.IsNotNull(findCreditCardResponse.CreditCard);
            Assert.IsNotNull(findCreditCardResponse.CreditCard.Token);
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void GetCreditCardNonExistentCreditCardTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            // Find 

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            //findParameters.Add(PayUParameterName.TOKEN_ID, "00000000-0000-0000-0000-000000000000");

            CreditCardResponse findCreditCardResponse = PayUCreditCard.Instance.Find(findParameters);
            Assert.Fail();
        }

        /// <summary>
        /// Update the credit card success test.
        /// </summary>
        [Test]
        public void EditCreditCardSuccessTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);

            // Find 

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            findParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);

            CreditCardResponse findCreditCardResponse = PayUCreditCard.Instance.Find(findParameters);

            Assert.IsNotNull(findCreditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, findCreditCardResponse.ResponseCode);
            Assert.IsNotNull(findCreditCardResponse.CreditCard);
            Assert.IsNotNull(findCreditCardResponse.CreditCard.Token);

            // Update 

            IDictionary<string, string> updateParameters = new Dictionary<string, string>();

            updateParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);

            updateParameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B Modified");
            updateParameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            updateParameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301 Modified");
            updateParameters.Add(PayUParameterName.PAYER_CITY, "Bogotá Modified");
            updateParameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C. Modified");
            updateParameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            updateParameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            updateParameters.Add(PayUParameterName.PAYER_PHONE, "5551234");

            CreditCardResponse updateCreditCardResponse = PayUCreditCard.Instance.Update(updateParameters);

            Assert.AreEqual(ResponseCode.SUCCESS, updateCreditCardResponse.ResponseCode);
            Assert.IsNotNull(updateCreditCardResponse.CreditCard);
            Assert.IsNotNull(updateCreditCardResponse.CreditCard.Token);
        }

        /// <summary>
        /// Deletes the credit card success test.
        /// </summary>
        [Test]
        [ExpectedException(typeof(PayUException))]
        public void DeleteCreditCardSuccessTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);

            // Find 

            IDictionary<string, string> findParameters = new Dictionary<string, string>();

            findParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);

            CreditCardResponse findCreditCardResponse = PayUCreditCard.Instance.Find(findParameters);

            Assert.IsNotNull(findCreditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, findCreditCardResponse.ResponseCode);
            Assert.IsNotNull(findCreditCardResponse.CreditCard);
            Assert.IsNotNull(findCreditCardResponse.CreditCard.Token);

            // Delete 

            IDictionary<string, string> deleteParameters = new Dictionary<string, string>();

            deleteParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);
            deleteParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            CreditCardResponse deleteCreditCardResponse = PayUCreditCard.Instance.Delete(deleteParameters);

            Assert.IsNotNull(deleteCreditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, deleteCreditCardResponse.ResponseCode);
            deleteCreditCardResponse = PayUCreditCard.Instance.Delete(deleteParameters);
        }

        //////////////////////////////////////////////////////////////////////////////
        //////////
        /////////////////////////////////////////////////////////////////////////////
        [Test]
        public void CreateSubscriptionSuccessTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);

            // Plan 

            IDictionary<string, string> subscriptionPlanParameters = new Dictionary<string, string>();

            subscriptionPlanParameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_TAX, "10000");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            subscriptionPlanParameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(subscriptionPlanParameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Subscription

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            subscriptionParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            subscriptionParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            subscriptionParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(subscriptionParameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionResponse.Subscription);
            Assert.IsNotNull(subscriptionResponse.Subscription.Id);
        }

        [Test]
        public void CreateSubscriptionExistingPlanTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            // Plan 

            IDictionary<string, string> subscriptionPlanParameters = new Dictionary<string, string>();

            subscriptionPlanParameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_TAX, "10000");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            subscriptionPlanParameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(subscriptionPlanParameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Subscription

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            subscriptionParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            subscriptionParameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            string customerName = string.Format("{0} {1}", GetRandom.FirstName(), GetRandom.LastName());

            subscriptionParameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            subscriptionParameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            subscriptionParameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            subscriptionParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            subscriptionParameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            subscriptionParameters.Add(PayUParameterName.PAYER_NAME, customerName);
            subscriptionParameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            subscriptionParameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            subscriptionParameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            subscriptionParameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            subscriptionParameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            subscriptionParameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            subscriptionParameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            subscriptionParameters.Add(PayUParameterName.PAYER_PHONE, "300300300");


            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(subscriptionParameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
        }

        [Test]
        public void CreateSubscriptionNewPlanTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);


            // Subscription

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            subscriptionParameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(8));
            subscriptionParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            subscriptionParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            subscriptionParameters.Add(PayUParameterName.TRIAL_DAYS, "2");
            subscriptionParameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.Usa.State());
            subscriptionParameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            subscriptionParameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            subscriptionParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            subscriptionParameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            subscriptionParameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            subscriptionParameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            subscriptionParameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(subscriptionParameters);


            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);
        }

        [Test]
        public void CreateSubscriptionExistingCustomerTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);
       
            // Subscription

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            subscriptionParameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(8));
            subscriptionParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            subscriptionParameters.Add(PayUParameterName.TRIAL_DAYS, "2");
            subscriptionParameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.Usa.State());
            subscriptionParameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            subscriptionParameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            subscriptionParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            subscriptionParameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            subscriptionParameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            subscriptionParameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            subscriptionParameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");


            subscriptionParameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            subscriptionParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            subscriptionParameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            subscriptionParameters.Add(PayUParameterName.PAYER_NAME, customerName);
            subscriptionParameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            subscriptionParameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            subscriptionParameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            subscriptionParameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            subscriptionParameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            subscriptionParameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            subscriptionParameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            subscriptionParameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(subscriptionParameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateEmptySubscriptionTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            // Subscription parameters
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            subscriptionParameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            SubscriptionResponse response = PayUSubscription.Instance.Create(subscriptionParameters);
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateFailedSubscriptionTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            // Subscription parameters
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            subscriptionParameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            subscriptionParameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");

            // Credit card parameters
            subscriptionParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");

            SubscriptionResponse response = PayUSubscription.Instance.Create(subscriptionParameters);
            Assert.Fail();
        }

        [Test]
        [ExpectedException(typeof(PayUException))]
        public void CreateFailedFullSubscriptionTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            // Customer
            IDictionary<string, string> customerParameters = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            customerParameters.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            customerParameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(customerParameters);
            
            // Credit Card

            IDictionary<string, string> creditCardParameters = new Dictionary<string, string>();

            creditCardParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            creditCardParameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            creditCardParameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            creditCardParameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            creditCardParameters.Add(PayUParameterName.PAYER_NAME, customerName);
            creditCardParameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            creditCardParameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            creditCardParameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            creditCardParameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            creditCardParameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            creditCardParameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            creditCardParameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            creditCardParameters.Add(PayUParameterName.PAYER_PHONE, "300300300");


            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(creditCardParameters);

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // Subscription parameters
            parameters.Add(PayUParameterName.QUANTITY, "5");
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            parameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            // Customer parameters
            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            parameters.Add(PayUParameterName.CUSTOMER_NAME, "Name");
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, "prueba@payulatam.com");

            // Plan parameters
            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(8));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            // Credit card parameters
            parameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, "Dominique A");
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(parameters);
            Assert.Fail();
        }

        [Test]
        public void CreateFullSubscriptionTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            // Customer
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // Subscription parameters
            parameters.Add(PayUParameterName.QUANTITY, "5");
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            parameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            // Customer parameters
            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.FirstName());
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            // Plan parameters
            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(5));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            // Credit card parameters
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, "Dominique A");
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);

            IDictionary<string, string> customerParameters = new Dictionary<string, string>();
            customerParameters.Add(PayUParameterName.CUSTOMER_ID, subscriptionResponse.Subscription.Customer.Id);
            CustomerResponse response = PayUCustomers.Instance.Find(customerParameters);


        }

        [Test]
        public void CreateRecurringBillItemTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            // Customer
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // Subscription parameters
            parameters.Add(PayUParameterName.QUANTITY, "5");
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            parameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            // Customer parameters
            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.FirstName());
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            // Plan parameters
            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(5));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            // Credit card parameters
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, "Dominique A");
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);

            // Recurring bill item
            IDictionary<string, string> recurringBillItemParameters = new Dictionary<string, string>();

            recurringBillItemParameters.Add(PayUParameterName.DESCRIPTION, "Test Item");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_VALUE, "100.5");
            recurringBillItemParameters.Add(PayUParameterName.CURRENCY, "COP");
            recurringBillItemParameters.Add(PayUParameterName.SUBSCRIPTION_ID, subscriptionResponse.Subscription.Id);

            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX, "10");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX_RETURN_BASE, "90.5");

            RecurringBillItemResponse response = PayURecurringBillItem.Instance.Create(recurringBillItemParameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);  
        }

        [Test]
        public void UpdateRecurringBillItemTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            // Customer
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // Subscription parameters
            parameters.Add(PayUParameterName.QUANTITY, "5");
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            parameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            // Customer parameters
            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.FirstName());
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            // Plan parameters
            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(5));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            // Credit card parameters
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, "Dominique A");
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);

            // Recurring bill item
            IDictionary<string, string> recurringBillItemParameters = new Dictionary<string, string>();

            recurringBillItemParameters.Add(PayUParameterName.DESCRIPTION, "Test Item");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_VALUE, "100.5");
            recurringBillItemParameters.Add(PayUParameterName.CURRENCY, "COP");
            recurringBillItemParameters.Add(PayUParameterName.SUBSCRIPTION_ID, subscriptionResponse.Subscription.Id);

            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX, "10");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX_RETURN_BASE, "90.5");

            RecurringBillItemResponse response = PayURecurringBillItem.Instance.Create(recurringBillItemParameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);  

            // Update recurring bill item

            IDictionary<string, string> updateRecurringBillItemParameters = new Dictionary<string, string>();

            updateRecurringBillItemParameters.Add(PayUParameterName.RECURRING_BILL_ITEM_ID,
                    response.RecurringBillItem.Id);
            updateRecurringBillItemParameters.Add(PayUParameterName.DESCRIPTION, "Test Item New");
            updateRecurringBillItemParameters.Add(PayUParameterName.ITEM_VALUE, "200.5");
            updateRecurringBillItemParameters.Add(PayUParameterName.CURRENCY, "COP");
            updateRecurringBillItemParameters.Add(PayUParameterName.SUBSCRIPTION_ID, response.RecurringBillItem.SubscriptionId);

            updateRecurringBillItemParameters.Add(PayUParameterName.ITEM_TAX, "15");
            updateRecurringBillItemParameters.Add(PayUParameterName.ITEM_TAX_RETURN_BASE, "185.5");

            RecurringBillItemResponse updateResponse = PayURecurringBillItem.Instance.Update(updateRecurringBillItemParameters);

            Assert.IsNotNull(updateResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, updateResponse.ResponseCode);  
        }

        [Test]
        public void GetRecurringBillItemTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            // Customer
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // Subscription parameters
            parameters.Add(PayUParameterName.QUANTITY, "5");
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            parameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            // Customer parameters
            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.FirstName());
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            // Plan parameters
            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(5));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            // Credit card parameters
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, "Dominique A");
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);

            // Recurring bill item
            IDictionary<string, string> recurringBillItemParameters = new Dictionary<string, string>();

            recurringBillItemParameters.Add(PayUParameterName.DESCRIPTION, "Test Item");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_VALUE, "100.5");
            recurringBillItemParameters.Add(PayUParameterName.CURRENCY, "COP");
            recurringBillItemParameters.Add(PayUParameterName.SUBSCRIPTION_ID, subscriptionResponse.Subscription.Id);

            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX, "10");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX_RETURN_BASE, "90.5");

            RecurringBillItemResponse response = PayURecurringBillItem.Instance.Create(recurringBillItemParameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);

            // get recurring bill item

            IDictionary<string, string> getRecurringBillItemParameters = new Dictionary<string, string>();

            getRecurringBillItemParameters.Add(PayUParameterName.RECURRING_BILL_ITEM_ID,
                    response.RecurringBillItem.Id);

            RecurringBillItemResponse getResponse = PayURecurringBillItem.Instance.Find(getRecurringBillItemParameters);

            Assert.IsNotNull(getResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, getResponse.ResponseCode);
        }

        [Test]
        public void DeleteRecurringBillItemTest()
        {
            PayUSubscription.ApiKey = base.apiKey;
            PayUSubscription.ApiLogin = base.apiLogin;
            PayUSubscription.Language = Language.en;
            PayUSubscription.PaymentsUrl = base.paymentsUrl;
            PayUSubscription.MerchantId = 1;

            // Customer
            IDictionary<string, string> parameters = new Dictionary<string, string>();

            // Subscription parameters
            parameters.Add(PayUParameterName.QUANTITY, "5");
            parameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");
            parameters.Add(PayUParameterName.TRIAL_DAYS, "2");

            // Customer parameters
            parameters.Add(PayUParameterName.CUSTOMER_NAME, GetRandom.FirstName());
            parameters.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            // Plan parameters
            parameters.Add(PayUParameterName.PLAN_DESCRIPTION, "Basic Plan");
            parameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(5));
            parameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            parameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            parameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            parameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            parameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            parameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "2");
            parameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");

            // Credit card parameters
            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, "Dominique A");
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(parameters);

            Assert.IsNotNull(subscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionResponse.ResponseCode);

            // Recurring bill item
            IDictionary<string, string> recurringBillItemParameters = new Dictionary<string, string>();

            recurringBillItemParameters.Add(PayUParameterName.DESCRIPTION, "Test Item");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_VALUE, "100.5");
            recurringBillItemParameters.Add(PayUParameterName.CURRENCY, "COP");
            recurringBillItemParameters.Add(PayUParameterName.SUBSCRIPTION_ID, subscriptionResponse.Subscription.Id);

            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX, "10");
            recurringBillItemParameters.Add(PayUParameterName.ITEM_TAX_RETURN_BASE, "90.5");

            RecurringBillItemResponse response = PayURecurringBillItem.Instance.Create(recurringBillItemParameters);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);

            // Delete recurring bill item

            IDictionary<string, string> deleteRecurringBillItemParameters = new Dictionary<string, string>();

            deleteRecurringBillItemParameters.Add(PayUParameterName.RECURRING_BILL_ITEM_ID,
                    response.RecurringBillItem.Id);

            RecurringBillItemResponse deleteResponse = PayURecurringBillItem.Instance.Delete(deleteRecurringBillItemParameters);

            Assert.IsNotNull(deleteResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, deleteResponse.ResponseCode);
        }

        [Test]
        public void CancelSubscriptionSuccessTest()
        {
            // Customer

            PayUCustomers.ApiKey = base.apiKey;
            PayUCustomers.ApiLogin = base.apiLogin;
            PayUCustomers.Language = Language.en;
            PayUCustomers.PaymentsUrl = base.paymentsUrl;
            PayUCustomers.MerchantId = 1;

            IDictionary<string, string> parametersCustomer = new Dictionary<string, string>();

            string customerName = string.Format("{0} {1}",
                GetRandom.FirstName(), GetRandom.LastName());

            parametersCustomer.Add(PayUParameterName.CUSTOMER_NAME, customerName);
            parametersCustomer.Add(PayUParameterName.CUSTOMER_EMAIL, GetRandom.Email());

            CustomerResponse customerResponse = PayUCustomers.Instance.Create(parametersCustomer);

            Assert.IsNotNull(customerResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, customerResponse.ResponseCode);
            Assert.IsNotNull(customerResponse.Customer);

            // Credit Card

            PayUCreditCard.ApiKey = base.apiKey;
            PayUCreditCard.ApiLogin = base.apiLogin;
            PayUCreditCard.Language = Language.en;
            PayUCreditCard.PaymentsUrl = base.paymentsUrl;
            PayUCreditCard.MerchantId = 1;

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);

            parameters.Add(PayUParameterName.CREDIT_CARD_NUMBER, "4005580000029205");
            parameters.Add(PayUParameterName.CREDIT_CARD_EXPIRATION_DATE, "2015/01");
            parameters.Add(PayUParameterName.PAYMENT_METHOD, "VISA");

            parameters.Add(PayUParameterName.PAYER_NAME, customerName);
            parameters.Add(PayUParameterName.PAYER_STREET, "Calle 93B");
            parameters.Add(PayUParameterName.PAYER_STREET_2, "17 25");
            parameters.Add(PayUParameterName.PAYER_STREET_3, "Oficina 301");
            parameters.Add(PayUParameterName.PAYER_CITY, "Bogotá");
            parameters.Add(PayUParameterName.PAYER_STATE, "Bogotá D.C.");
            parameters.Add(PayUParameterName.PAYER_COUNTRY, PaymentCountry.CO.ToString());
            parameters.Add(PayUParameterName.PAYER_POSTAL_CODE, "00000");
            parameters.Add(PayUParameterName.PAYER_PHONE, "300300300");

            CreditCardResponse creditCardResponse = PayUCreditCard.Instance.Create(parameters);

            Assert.IsNotNull(creditCardResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, creditCardResponse.ResponseCode);
            Assert.IsNotNull(creditCardResponse.CreditCard);
            Assert.IsNotNull(creditCardResponse.CreditCard.Token);

            // Plan 

            IDictionary<string, string> subscriptionPlanParameters = new Dictionary<string, string>();

            subscriptionPlanParameters.Add(PayUParameterName.PLAN_DESCRIPTION, GetRandom.UK.County());
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_CODE, GetRandom.NumericString(13));
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_INTERVAL, "MONTH");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_INTERVAL_COUNT, "12");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_CURRENCY, "COP");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_VALUE, "50000");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_TAX, "10000");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_TAX_RETURN_BASE, "40000");
            subscriptionPlanParameters.Add(PayUParameterName.ACCOUNT_ID, "2");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_ATTEMPTS_DELAY, "1");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PAYMENTS, "2");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS, "3");
            subscriptionPlanParameters.Add(PayUParameterName.PLAN_MAX_PENDING_PAYMENTS, "4");

            SubscriptionPlanResponse subscriptionPlanResponse = PayUPlans.Instance.Create(subscriptionPlanParameters);

            Assert.IsNotNull(subscriptionPlanResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, subscriptionPlanResponse.ResponseCode);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan);
            Assert.IsNotNull(subscriptionPlanResponse.SubscriptionPlan.Id);

            // Subscription

            IDictionary<string, string> subscriptionParameters = new Dictionary<string, string>();

            subscriptionParameters.Add(PayUParameterName.PLAN_CODE, subscriptionPlanResponse.SubscriptionPlan.PlanCode);
            subscriptionParameters.Add(PayUParameterName.CUSTOMER_ID, customerResponse.Customer.Id);
            subscriptionParameters.Add(PayUParameterName.TOKEN_ID, creditCardResponse.CreditCard.Token);
            subscriptionParameters.Add(PayUParameterName.QUANTITY, "5");
            subscriptionParameters.Add(PayUParameterName.INSTALLMENTS_NUMBER, "2");

            SubscriptionResponse subscriptionResponse = PayUSubscription.Instance.Create(subscriptionParameters);

            Assert.IsNotNull(subscriptionResponse);

            IDictionary<string, string> deleteSubscriptionParameters = new Dictionary<string, string>();
            deleteSubscriptionParameters.Add(PayUParameterName.SUBSCRIPTION_ID, subscriptionResponse.Subscription.Id);


            SubscriptionResponse cancelSubscriptionResponse = PayUSubscription.Instance.Cancel(deleteSubscriptionParameters);

            Assert.IsNotNull(cancelSubscriptionResponse);
            Assert.AreEqual(ResponseCode.SUCCESS, cancelSubscriptionResponse.ResponseCode);

        }
    }
}

// The MIT License (MIT)
//
// Copyright (c) 2016 PayU Latam
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// <author>Jorge D. Porras</author>

using System;
using System.Collections.Generic;
using PayuNetSdk.PayU.Util.DataStructures;
namespace PayuNetSdk.PayU
{
    /// <summary>
    /// Defines parameter names for PayU requests .
    /// </summary>
    public static class PayUParameterName
    {
        /// <summary>
        /// The parameters
        /// </summary>
        private static readonly IDictionary<string, string> parameters = new Dictionary<string, string>() {

            {ACCOUNT_ID, "ACCOUNT_ID"},
            {BATCH_TOKEN_ID, "BATCH_TOKEN_ID"},
            {COOKIE, "COOKIE"},
            {COUNTRY, "COUNTRY"},
            {CREDIT_CARD_EXPIRATION_DATE, "CREDIT_CARD_EXPIRATION_DATE"},
            {CREDIT_CARD_NUMBER, "CREDIT_CARD_NUMBER"},
            {CREDIT_CARD_SECURITY_CODE, "CREDIT_CARD_SECURITY_CODE"},
            {CURRENCY, "CURRENCY"},
            {CUSTOMER_EMAIL, "CUSTOMER_EMAIL"},
            {CUSTOMER_ID, "CUSTOMER_ID"},
            {CUSTOMER_NAME, "CUSTOMER_NAME"},
            {DESCRIPTION, "DESCRIPTION"},
            {END_DATE, "END_DATE"},
            {EXPIRATION_DATE, "EXPIRATION_DATE"},
            {INSTALLMENTS_NUMBER, "INSTALLMENTS_NUMBER"},
            {ITEM_TAX, "ITEM_TAX"},
            {ITEM_TAX_RETURN_BASE, "ITEM_TAX_RETURN_BASE"},
            {ITEM_VALUE, "ITEM_VALUE"},
            {ORDER_ID, "ORDER_ID"},
            {PAYER_CITY, "PAYER_CITY"},
            {PAYER_CNPJ, "PAYER_CNPJ"},
            {PAYER_CONTACT_PHONE, "PAYER_CONTACT_PHONE"},
            {PAYER_COUNTRY, "PAYER_COUNTRY"},
            {PAYER_DNI, "PAYER_DNI"},
            {PAYER_EMAIL, "PAYER_EMAIL"},
            {PAYER_ID, "PAYER_ID"},
            {PAYER_NAME, "PAYER_NAME"},
            {PAYER_PHONE, "PAYER_PHONE"},
            {PAYER_POSTAL_CODE, "PAYER_POSTAL_CODE"},
            {PAYER_STATE, "PAYER_STATE"},
            {PAYER_STREET, "PAYER_STREET"},
            {PAYER_STREET_2, "PAYER_STREET_2"},
            {PAYER_STREET_3, "PAYER_STREET_3"},
            {PAYMENT_METHOD, "PAYMENT_METHOD"},
            {PLAN_ATTEMPTS_DELAY, "PLAN_ATTEMPTS_DELAY"},
            {PLAN_CODE, "PLAN_CODE"},
            {PLAN_CURRENCY, "PLAN_CURRENCY"},
            {PLAN_DESCRIPTION, "PLAN_DESCRIPTION"},
            {PLAN_ID, "PLAN_ID"},
            {PLAN_INTERVAL, "PLAN_INTERVAL"},
            {PLAN_INTERVAL_COUNT, "PLAN_INTERVAL_COUNT"},
            {PLAN_MAX_PAYMENTS, "PLAN_MAX_PAYMENTS"},
            {PLAN_MAX_PAYMENT_ATTEMPTS, "PLAN_MAX_PAYMENT_ATTEMPTS"},
            {PLAN_MAX_PENDING_PAYMENTS, "PLAN_MAX_PENDING_PAYMENTS"},
            {PLAN_TAX, "PLAN_TAX"},
            {PLAN_TAX_RETURN_BASE, "PLAN_TAX_RETURN_BASE"},
            {PLAN_TRIAL_PERIOD_DAYS, "PLAN_TRIAL_PERIOD_DAYS"},
            {PLAN_VALUE, "PLAN_VALUE"},
            {PROCESS_WITHOUT_CVV2, "PROCESS_WITHOUT_CVV2"},
            {QUANTITY, "QUANTITY"},
            {RECURRING_BILL_ITEM_ID, "RECURRING_BILL_ITEM_ID"},
            {REFERENCE_CODE, "REFERENCE_CODE"},
            {SIGNATURE, "SIGNATURE"},
            {START_DATE, "START_DATE"},
            {SUBSCRIPTION_ID, "SUBSCRIPTION_ID"},
            {TAX_RETURN_BASE, "TAX_RETURN_BASE"},
            {TAX_VALUE, "TAX_VALUE"},
            {TOKEN_ID, "TOKEN_ID"},
            {TRANSACTION_ID, "TRANSACTION_ID"},
            {TRIAL_DAYS, "TRIAL_DAYS"},
            {VALUE, "VALUE"}
        };

        /// <summary>
        /// The account's id.
        /// </summary>
        public static string ACCOUNT_ID { get { return "accountId"; } }

        /// <summary>
        /// the batch token id.
        /// </summary>
        public static string BATCH_TOKEN_ID { get { return "batchTokenId"; } }

        /// <summary>
        /// The cookie corresponding with the current web session (Only for validation purposes)
        /// </summary>
        public static string COOKIE { get { return "cookie"; } }

        /// <summary>
        /// The payment method's country.
        /// </summary>
        public static string COUNTRY { get { return "country"; } }

        /// <summary>
        /// The credit card's expiration date.
        /// </summary>
        public static string CREDIT_CARD_EXPIRATION_DATE { get { return "creditCardExpirationDate"; } }

        /// <summary>
        /// The number on the credit card.
        /// </summary>
        public static string CREDIT_CARD_NUMBER { get { return "creditCardNumber"; } }

        /// <summary>
        /// The credit card's security code.
        /// </summary>
        public static string CREDIT_CARD_SECURITY_CODE { get { return "creditCardSecurityCode"; } }

        /// <summary>
        /// The ISO code for the currency to use.
        /// </summary>
        public static string CURRENCY { get { return "currency"; } }

        /// <summary>
        /// The customer's contact e-mail.
        /// </summary>
        public static string CUSTOMER_EMAIL { get { return "customerEmail"; } }

        /// <summary>
        /// The customer's id on the merchant.
        /// </summary>
        public static string CUSTOMER_ID { get { return "customerId"; } }

        /// <summary>
        /// The customer's name.
        /// </summary>
        public static string CUSTOMER_NAME { get { return "customerName"; } }

        /// <summary>
        /// The order's or payment method's description.
        /// </summary>
        public static string DESCRIPTION { get { return "description"; } }

        /// <summary>
        /// Last date to filter.
        /// </summary>
        public static string END_DATE { get { return "endDate"; } }

        /// <summary>
        /// The credit card's expiration date.
        /// </summary>
        public static string EXPIRATION_DATE { get { return "expirationDate"; } }

        /// <summary>
        /// The number of installments on the purchase.
        /// </summary>
        public static string INSTALLMENTS_NUMBER { get { return "installmentsNumber"; } }

        /// <summary>
        /// The tax to apply over the item.
        /// </summary>
        public static string ITEM_TAX { get { return "itemTax"; } }

        /// <summary>
        /// The item tax return base.
        /// </summary>
        public static string ITEM_TAX_RETURN_BASE { get { return "itemTaxReturnBase"; } }

        /// <summary>
        /// The item value.
        /// </summary>
        public static string ITEM_VALUE { get { return "itemValue"; } }

        /// <summary>
        /// The order's id.
        /// </summary>
        public static string ORDER_ID { get { return "orderId"; } }

        /// <summary>
        /// The payer's city.
        /// </summary>
        public static string PAYER_CITY { get { return "payerCity"; } }

        /// <summary>
        /// The payer's CNPJ.
        /// </summary>
        public static string PAYER_CNPJ { get { return "payerCNPJ"; } }

        /// <summary>
        /// The payer's contact phone.
        /// </summary>
        public static string PAYER_CONTACT_PHONE { get { return "payerContactPhone"; } }

        /// <summary>
        /// The payer's country.
        /// </summary>
        public static string PAYER_COUNTRY { get { return "payerCountry"; } }

        /// <summary>
        /// The payer's DNI.
        /// </summary>
        public static string PAYER_DNI { get { return "payerDNI"; } }

        /// <summary>
        /// The payer's contact e-mail.
        /// </summary>
        public static string PAYER_EMAIL { get { return "payerEmail"; } }

        /// <summary>
        /// The payer's id on the merchant.
        /// </summary>
        public static string PAYER_ID { get { return "payerId"; } }

        /// <summary>
        /// The payer's name
        /// </summary>
        public static string PAYER_NAME { get { return "payerName"; } }

        /// <summary>
        /// The payer's phone.
        /// </summary>
        public static string PAYER_PHONE { get { return "payerPhone"; } }

        /// <summary>
        /// The payer's postal code.
        /// </summary>
        public static string PAYER_POSTAL_CODE { get { return "payerPostalCode"; } }

        /// <summary>
        /// The payer's state.
        /// </summary>
        public static string PAYER_STATE { get { return "payerState"; } }

        /// <summary>
        /// The payer's address (part 1).
        /// </summary>
        public static string PAYER_STREET { get { return "payerStreet"; } }

        /// <summary>
        /// The payer's address (part 2).
        /// </summary>
        public static string PAYER_STREET_2 { get { return "payerStreet2"; } }

        /// <summary>
        /// The payer's address (part 3).
        /// </summary>
        public static string PAYER_STREET_3 { get { return "payerStreet3"; } }

        /// <summary>
        /// The payment method to use.
        /// </summary>
        public static string PAYMENT_METHOD { get { return "paymentMethod"; } }

        /// <summary>
        /// The plan attempts delay.
        /// </summary>
        public static string PLAN_ATTEMPTS_DELAY { get { return "paymentAttemptsDelay"; } }

        /// <summary>
        /// The plan code.
        /// </summary>
        public static string PLAN_CODE { get { return "planCode"; } }

        /// <summary>
        /// The currency to use on the plan.
        /// </summary>
        public static string PLAN_CURRENCY { get { return "planCurrency"; } }

        /// <summary>
        /// The plan description.
        /// </summary>
        public static string PLAN_DESCRIPTION { get { return "planDescription"; } }

        /// <summary>
        /// The plan id.
        /// </summary>
        public static string PLAN_ID { get { return "planId"; } }

        /// <summary>
        /// The plan interval.
        /// </summary>
        public static string PLAN_INTERVAL { get { return "planInterval"; } }

        /// <summary>
        /// The plan interval count.
        /// </summary>
        public static string PLAN_INTERVAL_COUNT { get { return "planIntervalCount"; } }

        /// <summary>
        /// The plan maximum number of payments.
        /// </summary>
        public static string PLAN_MAX_PAYMENTS { get { return "maxPaymentsAllowed"; } }

        /// <summary>
        /// The plan max payments attempts delay.
        /// </summary>
        public static string PLAN_MAX_PAYMENT_ATTEMPTS { get { return "maxPaymentAttempts"; } }

        /// <summary>
        /// The plan max pending payments.
        /// </summary>
        public static string PLAN_MAX_PENDING_PAYMENTS { get { return "maxPendingPayments"; } }

        /// <summary>
        /// The plan tax.
        /// </summary>
        public static string PLAN_TAX { get { return "planTax"; } }

        /// <summary>
        /// The plan tax return base.
        /// </summary>
        public static string PLAN_TAX_RETURN_BASE { get { return "planTaxReturnBase"; } }

        /// <summary>
        /// The number of trial days of the plan.
        /// </summary>
        public static string PLAN_TRIAL_PERIOD_DAYS { get { return "planTrialPeriodDays"; } }

        /// <summary>
        /// The plan value.
        /// </summary>
        public static string PLAN_VALUE { get { return "planValue"; } }

        /// <summary>
        /// Whether a transaction must process the cvv2 field
        /// </summary>
        public static string PROCESS_WITHOUT_CVV2 { get { return "processWithoutCvv2"; } }

        /// <summary>
        /// The quantity to purchase.
        /// </summary>
        public static string QUANTITY { get { return "quantity"; } }

        /// <summary>
        /// The recurring bill item id.
        /// </summary>
        public static string RECURRING_BILL_ITEM_ID { get { return "recurringBillItemId"; } }

        /// <summary>
        /// El order's reference code.
        /// </summary>
        public static string REFERENCE_CODE { get { return "referenceCode"; } }

        /// <summary>
        /// The tranactions signature.
        /// </summary>
        public static string SIGNATURE { get { return "signature"; } }

        /// <summary>
        /// Start date to filter.
        /// </summary>
        public static string START_DATE { get { return "startDate"; } }

        /// <summary>
        /// The subscription id.
        /// </summary>
        public static string SUBSCRIPTION_ID { get { return "subscriptionId"; } }

        /// <summary>
        /// The tax return base.
        /// </summary>
        public static string TAX_RETURN_BASE { get { return "taxDevolutionBase"; } }

        /// <summary>
        /// The tax value.
        /// </summary>
        public static string TAX_VALUE { get { return "taxValue"; } }

        /// <summary>
        /// The credit card token id.
        /// </summary>
        public static string TOKEN_ID { get { return "tokenId"; } }

        /// <summary>
        /// El identificador de la transacción.
        /// </summary>
        public static string TRANSACTION_ID { get { return "transactionId"; } }

        /// <summary>
        /// The number of trial days.
        /// </summary>
        public static string TRIAL_DAYS { get { return "trialDays"; } }

        /// <summary>
        /// The value of the purchase.
        /// </summary>
        public static string VALUE { get { return "value"; } }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static string GetKey(string value)
        {
            string result = null;
            try
            {
                parameters.TryGetValue(value, out result);
            }
            catch (ArgumentNullException) { /*Nothing*/ }
            return result;
        }
    }
}

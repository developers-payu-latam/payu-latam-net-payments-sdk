// <copyright file="SDKException.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

using PayuNetSdk.PayU.Messages.Enums;
using System;
namespace PayuNetSdk.PayU.Configuration
{
    /// <summary>
    /// Contatins PayU urls
    /// </summary>
    public static class Enviroment
    {
        /// <summary>
        /// Gets the payment url.
        /// </summary>
        private const string PAYMENTS_URL = "https://api.payulatam.com/payments-api";

        /// <summary>
        /// Gets the reports url.
        /// </summary>
        private const string REPORTS_URL = "https://api.payulatam.com/reports-api";

        /// <summary>
        /// The recurrin payment url.
        /// </summary>
        private const string RECURRING_PAYMENT_URL = "https://api.payulatam.com/payments-api";

        /// <summary>
        /// The post version
        /// </summary>
        private const string POST_VERSION = "/4.0/service.cgi";

        /// <summary>
        /// The rest verison
        /// </summary>
        private const string REST_VERSION = "/rest/v4.3/";
            
        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="serverType">Type of the server.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Invalid url for  + serverType.ToString()</exception>
        public static string GetUrl(ServerType serverType){

            switch (serverType)
            {
                case ServerType.Payments:

                    return string.IsNullOrEmpty(PayuNetSdk.PayU.Api.PayU.PaymentsUrl) ?
                        string.Format("{0}{1}", Enviroment.PAYMENTS_URL, Enviroment.POST_VERSION) :
                        string.Format("{0}{1}", PayuNetSdk.PayU.Api.PayU.PaymentsUrl, Enviroment.POST_VERSION);

                case ServerType.Reports:

                    return string.IsNullOrEmpty(PayuNetSdk.PayU.Api.PayU.ReportsUrl) ?
                        string.Format("{0}{1}", Enviroment.REPORTS_URL, Enviroment.POST_VERSION) :
                        string.Format("{0}{1}", PayuNetSdk.PayU.Api.PayU.ReportsUrl, Enviroment.POST_VERSION);

                case ServerType.RecurringPayment:
                    return string.IsNullOrEmpty(PayuNetSdk.PayU.Api.PayU.PaymentsUrl) ?
                        string.Format("{0}{1}", Enviroment.RECURRING_PAYMENT_URL, Enviroment.REST_VERSION) :
                        string.Format("{0}{1}", PayuNetSdk.PayU.Api.PayU.PaymentsUrl, Enviroment.REST_VERSION);
            }
            throw new NotImplementedException("Invalid url for " + serverType.ToString());
        }
    }
}

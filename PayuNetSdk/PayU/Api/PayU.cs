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

namespace PayuNetSdk.PayU.Api
{
    using System;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;
    using PayuNetSdk.PayU.Configuration;
    using System.Threading;
    using System.Globalization;
    using PayuNetSdk.Resources;
    using PayuNetSdk.PayU.Validators.Base;

    /// <summary>
    /// PAYU API abstract class. Maintains common elements to API interfaces.
    /// Generates a common request for AbstractRequest.
    /// </summary>
    public abstract class PayU
    {
        /// <summary>
        ///  Gets API version.
        /// </summary>
        public static string API_VERSION { get { return "4.0.1"; } }

        /// <summary>
        /// Gets API name.
        /// </summary>
        public static string API_NAME { get { return "PayU SDK"; } }

        /// <summary>
        /// Gets or sets custom Payments-API end-point URL.
        /// </summary>
        public static string PaymentsUrl { get; set; }

        /// <summary>
        /// Gets or sets custom Reports-API end-point URL.
        /// </summary>
        public static string ReportsUrl { get; set; }

        /// <summary>
        /// Gets or sets if request is in TEST mode.
        /// </summary>
        public static bool IsTest { get; set; }

        /// <summary>
        /// Gets or sets merchant API key.
        /// </summary>
        public static string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets merchant API Login.
        /// </summary>
        public static string ApiLogin { get; set; }

        /// <summary>
        /// Gets or sets merchant Id.
        /// </summary>
        public static int MerchantId { get; set; }

        /// <summary>
        /// Gets or sets request language.
        /// </summary>
        public static Language Language { get; set; }

        /// <summary>
        /// Creates the base request. Prepares a request of a type that inherits from
        /// <see cref="AbstractRequest" /> class.
        /// Sets Language, Merchant (ApiKey y ApiLogin) and Url's.
        /// </summary>
        /// <typeparam name="T">Classes that inherit from AbstractRequest.</typeparam>
        /// <param name="serverType">Type of the server.</param>
        /// <returns>
        /// Instance of a type T
        /// </returns>
        protected virtual T CreateBaseRequest<T>(ServerType serverType) where T : AbstractRequest
        {
            T request = Activator.CreateInstance<T>();

            request.Language = PayU.Language;
            request.Merchant = new Merchant()
            {
                Id = PayU.MerchantId,
                ApiKey = PayU.ApiKey,
                ApiLogin = PayU.ApiLogin
            };
            request.Url = Enviroment.GetUrl(serverType);
            request.IsTest = PayU.IsTest;

            ValidatorLoader.Load();
            this.CreateCulture(request);

            return request;
        }

        /// <summary>
        /// Creates the base request. Prepares a request given a type.
        /// Sets Language, Merchant (ApiKey y ApiLogin), Url.
        /// </summary>
        /// <typeparam name="T">Classes that inherit from AbstractRequest.</typeparam>
        /// <param name="serverType">Type of the server.</param>
        /// <param name="internalParameters">The internal parameters.</param>
        /// <returns>
        /// Instance of a type T
        /// </returns>
        protected virtual T CreateBaseRequest<T>(ServerType serverType, IDictionary<string, string> internalParameters)
            where T : AbstractRequest
        {
            T request = this.CreateBaseRequest<T>(serverType);

            request.InternalParameters = internalParameters;

            return request;
        }

        /// <summary>
        /// Creates the culture.
        /// </summary>
        private void CreateCulture(AbstractRequest request)
        {
            String culture = request.Language.ToString();
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

    }
}

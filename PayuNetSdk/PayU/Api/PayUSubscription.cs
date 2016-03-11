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

using PayuNetSdk.PayU.Messages;
using System.Collections.Generic;
using PayuNetSdk.PayU.Builders;
using PayuNetSdk.PayU.Services;
using PayuNetSdk.PayU.Messages.Enums;
namespace PayuNetSdk.PayU.Api
{
    /// <summary>
    ///
    /// </summary>
    public sealed class PayUSubscription : PayU
    {
        /// <summary>
        /// PayUSubscription instance for singleton pattern.
        /// </summary>
        private static PayUSubscription instance;

        private static object syncLock = new object();

        /// <summary>
        /// The recurring payment service
        /// </summary>
        private RecurringPaymentService recurringPaymentService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUSubscription"/> class from being created.
        /// </summary>
        private PayUSubscription()
        {
            recurringPaymentService = new RecurringPaymentService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUSubscription Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUSubscription();
                        }
                    }
                }
                return instance;
            }
        }

        ////////////////////////////////////////////////////////////////
        //// PUBLIC OPERATIONS
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates a subscription with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public SubscriptionResponse Create(IDictionary<string, string> parameters)
        {
            SubscriptionRequest request = base.CreateBaseRequest<SubscriptionRequest>(ServerType.RecurringPayment, parameters);

            SubscriptionBuilder builder = new SubscriptionBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.CreateSubscription(request);
        }

        /// <summary>
        /// Deletes a subscription with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public SubscriptionResponse Cancel(IDictionary<string, string> parameters)
        {
            SubscriptionRequest request = base.CreateBaseRequest<SubscriptionRequest>(ServerType.RecurringPayment, parameters);

            SubscriptionBuilder builder = new SubscriptionBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.DeleteSubscription(request);
        }
    }
}

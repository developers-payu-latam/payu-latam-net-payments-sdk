// <copyright file="PayUSubscription.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
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

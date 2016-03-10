// <copyright file="PayUPlans.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.Builders;
using PayuNetSdk.PayU.Services;
using System.Collections.Generic;
using PayuNetSdk.PayU.Messages.Enums;
namespace PayuNetSdk.PayU.Api
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class PayUPlans : PayU
    {
        /// <summary>
        /// PayUPlans instance for singleton pattern.
        /// </summary>
        private static PayUPlans instance;

        private static object syncLock = new object();

        /// <summary>
        /// The recurring payment service
        /// </summary>
        private RecurringPaymentService recurringPaymentService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUPlans"/> class from being created.
        /// </summary>
        private PayUPlans()
        {
            recurringPaymentService = new RecurringPaymentService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUPlans Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUPlans();
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
        /// Creates a subscription plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse Create(IDictionary<string, string> parameters)
        {
            SubscriptionPlanRequest request = base.CreateBaseRequest<SubscriptionPlanRequest>(ServerType.RecurringPayment, parameters);

            SubscriptionPlanBuilder builder = new SubscriptionPlanBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.CreateSubscriptionPlan(request);            
        }

        /// <summary>
        /// Updates a subscription plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse Update(IDictionary<string, string> parameters)
        {
            SubscriptionPlanRequest request = base.CreateBaseRequest<SubscriptionPlanRequest>(ServerType.RecurringPayment, parameters);

            SubscriptionPlanBuilder builder = new SubscriptionPlanBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.UpdateSubscriptionPlan(request);
        }

        /// <summary>
        /// Finds a subscription plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse Find(IDictionary<string, string> parameters)
        {
            SubscriptionPlanRequest request = base.CreateBaseRequest<SubscriptionPlanRequest>(ServerType.RecurringPayment, parameters);

            SubscriptionPlanBuilder builder = new SubscriptionPlanBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.GetSubscriptionPlan(request);
        }

        /// <summary>
        /// Deletes a subscription plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse Delete(IDictionary<string, string> parameters)
        {
            SubscriptionPlanRequest request = base.CreateBaseRequest<SubscriptionPlanRequest>(ServerType.RecurringPayment, parameters);

            SubscriptionPlanBuilder builder = new SubscriptionPlanBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.DeleteSubscriptionPlan(request);
        }
    }
}

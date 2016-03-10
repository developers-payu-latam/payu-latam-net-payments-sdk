// <copyright file="SubscriptionBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.PayU.Model.Subscriptions;
    using PayuNetSdk.PayU.Model.Customers;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Model.Personal;

    /// <summary>
    /// Builder class for build new <see cref="SubscriptionBuilder"/>.
    /// </summary>
    internal class SubscriptionBuilder : AbstractBuilder<Subscription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public SubscriptionBuilder(AbstractRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public override void Build()
        {
            base.Entity.Id = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.SUBSCRIPTION_ID);

            base.Entity.Quantity = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.QUANTITY);

            base.Entity.Installments = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.INSTALLMENTS_NUMBER);

            base.Entity.TrialDays = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.TRIAL_DAYS);

            SubscriptionPlanBuilder builder = new SubscriptionPlanBuilder(base.request);
            base.Entity.Plan = builder.Entity;

            CustomerWithCreditCardBuilder customer = new CustomerWithCreditCardBuilder(base.request);
            base.Entity.Customer = customer.Entity;

            if (base.Entity.Customer.CreditCards != null && base.Entity.Customer.CreditCards.Count > 0)
            {
                base.Entity.Customer.CreditCards[0].CustomerId = null;
                if (base.Entity.Customer.CreditCards[0].Address.Equals(new Address()))
                {
                    base.Entity.Customer.CreditCards[0].Address = null;
                }
            }
        }
    }
}

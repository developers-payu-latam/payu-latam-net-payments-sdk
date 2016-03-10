// <copyright file="SubscriptionPlanBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.PayU.Util.DataStructures;
    using PayuNetSdk.PayU.Messages.Enums;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Builder class for build new <see cref="SubscriptionPlanBuilder"/>.
    /// </summary>
    internal class SubscriptionPlanBuilder : AbstractBuilder<SubscriptionPlan>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionPlanBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public SubscriptionPlanBuilder(AbstractRequest request) : base(request)
        {

        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public override void Build()
        {
            /*base.Entity.Id = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CUSTOMER_ID);*/

            base.Entity.Description = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.PLAN_DESCRIPTION);

            base.Entity.PlanCode = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.PLAN_CODE);

            base.Entity.Interval = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.PLAN_INTERVAL);

            base.Entity.IntervalCount = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.PLAN_INTERVAL_COUNT);

            base.Entity.AccountId = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.ACCOUNT_ID);

            base.Entity.PaymentAttemptsDelay = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.PLAN_ATTEMPTS_DELAY);

            base.Entity.MaxPaymentAttempts = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.PLAN_MAX_PAYMENT_ATTEMPTS);

            base.Entity.MaxPaymentsAllowed = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.PLAN_MAX_PAYMENTS);

            base.Entity.MaxPendingPayments = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.PLAN_MAX_PENDING_PAYMENTS);

            try
            {

                Currency planCurrency = DataConverter.GetEnumValue<Currency>(
                    this.request.InternalParameters, PayUParameterName.PLAN_CURRENCY);

                this.Entity.AdditionalValues = new List<AdditionalValue>();

                this.AddAdditionalValue("PLAN_VALUE", DataConverter.GetDecimalValue(
                    this.request.InternalParameters, PayUParameterName.PLAN_VALUE), planCurrency);

                this.AddAdditionalValue("PLAN_TAX", DataConverter.GetDecimalValue(
                    this.request.InternalParameters, PayUParameterName.PLAN_TAX), planCurrency);

                this.AddAdditionalValue("PLAN_TAX_RETURN_BASE", DataConverter.GetDecimalValue(
                    this.request.InternalParameters, PayUParameterName.PLAN_TAX_RETURN_BASE), planCurrency);
            }
            catch (ArgumentNullException)
            {
                // Do nothing 
            }
        }

        /// <summary>
        /// Adds the additional value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="currency">The currency.</param>
        private void AddAdditionalValue(string key, decimal? parameter, Currency currency)
        {
            if (parameter.HasValue)
            {
                AdditionalValue additionalValue = new AdditionalValue();
                additionalValue.Currency = currency;
                additionalValue.Value = parameter.Value;
                additionalValue.Name = key;
                this.Entity.AdditionalValues.Add(additionalValue);
            }
        }
    }
}

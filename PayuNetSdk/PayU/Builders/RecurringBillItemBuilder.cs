// <copyright file="SubscriptionBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

using PayuNetSdk.PayU.Model.RecurringBillItems;
using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.Util;
using PayuNetSdk.PayU.Model.Plans;
using PayuNetSdk.PayU.Messages.Enums;
using System;
using System.Collections.Generic;
namespace PayuNetSdk.PayU.Builders
{
    internal class RecurringBillItemBuilder : AbstractBuilder<RecurringBillItem>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RecurringBillItemBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public RecurringBillItemBuilder(AbstractRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public override void Build()
        {
            base.Entity.Id = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.RECURRING_BILL_ITEM_ID);

            base.Entity.SubscriptionId = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.SUBSCRIPTION_ID);

            base.Entity.Description = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.DESCRIPTION);

            try
            {
                Currency planCurrency = DataConverter.GetEnumValue<Currency>(
                    this.request.InternalParameters, PayUParameterName.CURRENCY);

                this.Entity.AdditionalValues = new List<AdditionalValue>();

                this.AddAdditionalValue("ITEM_VALUE", DataConverter.GetDecimalValue(
                    this.request.InternalParameters, PayUParameterName.ITEM_VALUE), planCurrency);

                this.AddAdditionalValue("ITEM_TAX", DataConverter.GetDecimalValue(
                    this.request.InternalParameters, PayUParameterName.ITEM_TAX), planCurrency);

                this.AddAdditionalValue("ITEM_TAX_RETURN_BASE", DataConverter.GetDecimalValue(
                    this.request.InternalParameters, PayUParameterName.ITEM_TAX_RETURN_BASE), planCurrency);
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

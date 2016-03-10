// <copyright file="Subscription.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Subscriptions
{
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Util.DataStructures;
    using PayuNetSdk.PayU.Model.Customers;
    using System;
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Validators.Base;

    [XmlType("subscription")]
    public class Subscription : IValidatable<Subscription>
    {
        /// <summary>
        /// Gets or sets the identifier of the order.
        /// </summary>
        /// <value>
        /// The identifier of the order.
        /// </value>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the subscription plan.
        /// </summary>
        /// <value>
        /// The subscription plan.
        /// </value>
        [XmlElement("plan")]
        public SubscriptionPlan Plan { get; set; }

        /// <summary>
        /// The customer
        /// </summary>
        [XmlElement("customer")]
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the number of trial days
        /// </summary>
        /// <value>
        /// The number of trial days
        /// </value>
        [XmlElement("trialDays")]
        public int? TrialDays { get; set; }
        public bool ShouldSerializeTrialDays() { return TrialDays.HasValue; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        [XmlElement("quantity")]
        public int? Quantity { get; set; }
        public bool ShouldSerializeQuantity() { return Quantity.HasValue; }

        /// <summary>
        /// Gets or sets the installments.
        /// </summary>
        /// <value>
        /// The installments.
        /// </value>
        [XmlElement("installments")]
        public int? Installments { get; set; }
        public bool ShouldSerializeInstallments() { return Installments.HasValue; }

        /// <summary>
        /// Gets or sets the current period start.
        /// </summary>
        /// <value>
        /// The current period start.
        /// </value>
        [XmlElement("currentPeriodStart")]
        public DateTime? CurrentPeriodStart { get; set; }
        public bool ShouldSerializeCurrentPeriodStart() { return CurrentPeriodStart.HasValue; }

        /// <summary>
        /// Gets or sets the current period end.
        /// </summary>
        /// <value>
        /// The current period end.
        /// </value>
        [XmlElement("currentPeriodEnd")]
        public DateTime? CurrentPeriodEnd { get; set; }
        public bool ShouldSerializeCurrentPeriodEnd() { return CurrentPeriodEnd.HasValue; }

        /// <summary>
        /// Gets or sets the credit card token.
        /// </summary>
        /// <value>
        /// The credit card token.
        /// </value>
        [XmlElement("creditCardToken")]
        public string CreditCardToken { get; set; }

        public bool Validate(IValidator<Subscription> validator, out IEnumerable<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return validator.IsValid(this);
        }


    }
}

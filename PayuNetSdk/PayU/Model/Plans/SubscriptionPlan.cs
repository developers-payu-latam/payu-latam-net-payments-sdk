// <copyright file="SubscriptionPlan.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Plans
{
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Util.DataStructures;
    using PayuNetSdk.PayU.Validators.Base;

    [XmlRoot("plan")]
    public class SubscriptionPlan : IValidatable<SubscriptionPlan>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the plan Code
        /// </summary>
        /// <value>
        /// The plan Code
        /// </value>
        [XmlElement("planCode")]
        public string PlanCode { get; set; }

        /// <summary>
        /// Gets or sets the plan description
        /// </summary>
        /// <value>
        /// The plan description
        /// </value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the account related to the order.
        /// </summary>
        /// <value>
        /// The identifier of the account related to the order.
        /// </value>
        [XmlElement("accountId")]
        public int? AccountId { get; set; }
        public bool ShouldSerializeAccountId() { return AccountId.HasValue; }

        /// <summary>
        /// Gets or sets the number of intervals
        /// </summary>
        /// <value>
        /// The number of intervals
        /// </value>
        [XmlElement("intervalCount")]
        public int? IntervalCount { get; set; }
        public bool ShouldSerializeIntervalCount() { return IntervalCount.HasValue; }

        /// <summary>
        /// Gets or sets the payment interval
        /// </summary>
        /// <value>
        /// The payment interval
        /// </value>
        [XmlElement("interval")]
        public string Interval { get; set; }

        /// <summary>
        /// Gets or sets the number of payments allowed in the interval
        /// </summary>
        /// <value>
        /// The number of payments allowed in the interval
        /// </value>
        [XmlElement("maxPaymentsAllowed")]
        public int? MaxPaymentsAllowed { get; set; }
        public bool ShouldSerializeMaxPaymentsAllowed() { return MaxPaymentsAllowed.HasValue; }

        /// <summary>
        /// Gets or sets the number of attempts allowed by payment
        /// </summary>
        /// <value>
        /// The number of attempts allowed by payment
        /// </value>
        [XmlElement("maxPaymentAttempts")]
        public int? MaxPaymentAttempts { get; set; }
        public bool ShouldSerializeMaxPaymentAttempts() { return MaxPaymentAttempts.HasValue; }

        /// <summary>
        /// Gets or sets the hours to delay the next payment Attempt
        /// </summary>
        /// <value>
        /// The hours to delay the next payment Attempt
        /// </value>
        [XmlElement("paymentAttemptsDelay")]
        public int? PaymentAttemptsDelay { get; set; }
        public bool ShouldSerializePaymentAttemptsDelay() { return PaymentAttemptsDelay.HasValue; }

        /// <summary>
        /// Gets or sets the max pending bills allowed
        /// </summary>
        /// <value>
        /// The max pending bills allowed
        /// </value>
        [XmlElement("maxPendingPayments")]
        public int? MaxPendingPayments { get; set; }
        public bool ShouldSerializeMaxPendingPayments() { return MaxPendingPayments.HasValue; }

        /// <summary>
        /// Gets or sets the number of trial days
        /// </summary>
        /// <value>
        /// The number of trial days
        /// </value>
        [XmlElement("trialDays")]
        public int? TrialDays { get; set; }
        public bool ShouldSerializeTrialDays() { return TrialDays.HasValue; }

        [XmlArray("additionalValues")]
        public List<AdditionalValue> AdditionalValues { get; set; }

        public bool Validate(IValidator<SubscriptionPlan> validator, out IEnumerable<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return validator.IsValid(this);
        }
    }
}

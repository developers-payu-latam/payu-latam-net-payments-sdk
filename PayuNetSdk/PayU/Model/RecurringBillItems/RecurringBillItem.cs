// <copyright file="RecurringBillItem.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.RecurringBillItems
{
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Util.DataStructures;
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Validators.Base;

    [XmlRoot("recurringBillItem")]
    public class RecurringBillItem : IValidatable<RecurringBillItem>
    {
        /// <summary>
        /// Gets or sets the recurring bill item identifier
        /// </summary>
        /// <value>
        /// The recurring bill item identifier
        /// </value>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the recurring bill item description
        /// </summary>
        /// <value>
        /// The recurring bill item description
        /// </value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the subscription identifier
        /// </summary>
        /// <value>
        /// The subscription identifier
        /// </value>
        [XmlElement("subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Gets or sets the additional values.
        /// </summary>
        /// <value>
        /// The additional values.
        /// </value>
        [XmlArray("additionalValues")]
        public List<AdditionalValue> AdditionalValues { get; set; }

        public bool Validate(IValidator<RecurringBillItem> validator, out IEnumerable<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return validator.IsValid(this);
        }
    }
}

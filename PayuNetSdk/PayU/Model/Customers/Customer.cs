// <copyright file="Customer.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Customers
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Model.Subscriptions;
    using PayuNetSdk.PayU.Validators.Base;

    /// <summary>
    /// Represents a customer
    /// </summary>
    [XmlRoot("customer")]
    public class Customer : IValidatable<Customer>
    {
        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        /// <value>
        /// The customer identifier
        /// </value>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the customer full name
        /// </summary>
        /// <value>
        /// The customer full name
        /// </value>
        [XmlElement("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the customer email
        /// </summary>
        /// <value>
        /// The customer email
        /// </value>
        [XmlElement("email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the banks information.
        /// </summary>
        /// <value>
        /// The banks information.
        /// </value>
        [XmlArray("creditCards")]
        public List<CreditCard> CreditCards { get; set; }

        /// <summary>
        /// Gets or sets the subscriptions.
        /// </summary>
        /// <value>
        /// The subscriptions.
        /// </value>
        [XmlArray("subscriptions")]
        public List<Subscription> Subscriptions { get; set; }

        /// <summary>
        /// Validates the specified validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="brokenRules">The broken rules.</param>
        /// <returns></returns>
        public bool Validate(IValidator<Customer> validator, out IEnumerable<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return validator.IsValid(this);
        }
    }
}

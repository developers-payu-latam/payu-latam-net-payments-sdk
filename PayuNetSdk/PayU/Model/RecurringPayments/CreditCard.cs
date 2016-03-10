// <copyright file="CreditCard.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.RecurringPayments
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Validators.Base;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    [XmlType(TypeName = "creditCard")]
    public class CreditCard : IValidatable<CreditCard>
    {
        /// <summary>
        /// Gets or sets the credit card token
        /// </summary>
        /// <value>
        /// The credit card token
        /// </value>
        [XmlElement("token")]
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the customer identification code
        /// </summary>
        /// <value>
        /// The customer identification code
        /// </value>
        [XmlElement("customerId")]
        public string CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the credit card number
        /// </summary>
        /// <value>
        /// The credit card number
        /// </value>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the expiration month
        /// </summary>
        /// <value>
        /// The expiration month
        /// </value>
        [XmlElement("expMonth")]
        public int? ExpMonth { get; set; }
        public bool ShouldSerializeExpMonth() { return ExpMonth.HasValue; }

        /// <summary>
        /// Gets or sets the expiration year
        /// </summary>
        /// <value>
        /// The expiration year
        /// </value>
        [XmlElement("expYear")]
        public int? ExpYear { get; set; }
        public bool ShouldSerializeExpYear() { return ExpYear.HasValue; }

        /// <summary>
        /// Gets or sets the credit card type
        /// </summary>
        /// <value>
        /// The credit card type
        /// </value>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the issuer bank
        /// </summary>
        /// <value>
        /// The issuer bank.
        /// </value>
        [XmlElement("issuerBank")]
        public string IssuerBank { get; set; }

        /// <summary>
        /// Gets or sets the card holder namer
        /// </summary>
        /// <value>
        /// The card holder namer
        /// </value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the card holder identification document number
        /// </summary>
        /// <value>
        /// The card holder identification document number
        /// </value>
        [XmlElement("document")]
        public string Document { get; set; }

        /// <summary>
        /// Gets or sets the credit card billing address
        /// </summary>
        /// <value>
        /// The credit card billing address
        /// </value>
        [XmlElement("address")]
        public Address Address { get; set; }

        /// <summary>
        /// Validates the specified validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="brokenRules">The broken rules.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool Validate(IValidator<CreditCard> validator, out IEnumerable<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return validator.IsValid(this);
        }
    }
}

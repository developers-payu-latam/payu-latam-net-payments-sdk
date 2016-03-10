// <copyright file="CreditCard.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Payments
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a credit card.
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the security code.
        /// </summary>
        /// <value>
        /// The security code.
        /// </value>
        [XmlElement("securityCode")]
        public string SecurityCode { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        [XmlElement("expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the issuer bank.
        /// </summary>
        /// <value>
        /// The issuer bank.
        /// </value>
        [XmlElement("issuerBank")]
        public string IssuerBank { get; set; }

        /// <summary>
        /// Gets or sets the masked number.
        /// </summary>
        /// <value>
        /// The masked number.
        /// </value>
        [XmlElement("maskedNumber")]
        public string MaskedNumber { get; set; }

        /// <summary>
        /// Gets or sets the process without CVV2.
        /// </summary>
        /// <value>
        /// The process without CVV2.
        /// </value>
        [XmlElement("processWithoutCvv2")]
        public bool? ProcessWithoutCvv2 { get; set; }
        public bool ShouldSerializeProcessWithoutCvv2() { return ProcessWithoutCvv2.HasValue; }
    }
}

// <copyright file="CreditCardSwipe.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.PaymentMethods
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a credit card swipe
    /// </summary>
    [XmlRoot("creditCardSwipe")]
    public class CreditCardSwipe
    {

        /// <summary>
        /// Gets or sets the encrypted information obtained from the credit card.
        /// </summary>
        /// <value>
        /// The encrypted information obtained from the credit card.
        /// </value>
        [XmlElement("cryptogram", IsNullable = false)]
        public string Cryptogram { get; set; }

        /// <summary>
        /// Gets or sets the issuer bank of the credit card.
        /// </summary>
        /// <value>
        /// The issuer bank of the credit card.
        /// </value>
        [XmlElement("issuerBank")]
        public string IssuerBank { get; set; }

        /// <summary>
        /// Gets or sets the credit card security code.
        /// </summary>
        /// <value>
        /// The credit card security code..
        /// </value>
        [XmlElement("securityCode")]
        public string SecurityCode { get; set; }
    }
}

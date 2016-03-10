// <copyright file="Payer.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Personal
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a payer.
    /// </summary>
    public class Payer : Person
    {
        /// <summary>
        /// Gets or sets the merchant payer identifier.
        /// </summary>
        /// <value>
        /// The merchant payer identifier.
        /// </value>
        [XmlElement("merchantPayerId")]
        public string MerchantPayerId { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [XmlElement("billingAddress")]
        public Address Address { get; set; }
    }
}

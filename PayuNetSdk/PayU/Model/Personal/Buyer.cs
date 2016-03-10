// <copyright file="Buyer.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Personal
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a buyer.
    /// </summary>
    public class Buyer : Person
    {
        /// <summary>
        /// Gets or sets the merchant buyer identifier.
        /// </summary>
        /// <value>
        /// The merchant buyer identifier.
        /// </value>
        [XmlElement("merchantBuyerId")]
        public string MerchantBuyerId { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [XmlElement("shippingAddress")]
        public Address Address { get; set; }
    }
}

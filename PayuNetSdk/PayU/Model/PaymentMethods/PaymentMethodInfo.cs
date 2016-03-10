// <copyright file="PaymentMethodInfo.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.PaymentMethods
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a payment method info.
    /// </summary>
    [XmlType(TypeName = "paymentMethodComplete")]
    public class PaymentMethodInfo
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [XmlElement("country")]
        public string Country { get; set; }
    }
}

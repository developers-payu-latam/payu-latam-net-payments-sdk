// <copyright file="OrderReport.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Reports
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Payments;

    /// <summary>
    /// Represents an order result
    /// </summary>
    public class OrderReport
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [XmlElement(ElementName = "payload")]
        public Order Order { get; set; }
    }
}

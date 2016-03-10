// <copyright file="OrderReportList.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Reports
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Payments;
    using System.Collections.Generic;

    /// <summary>
    /// Represents an order result
    /// </summary>
    public class OrderReportList
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [XmlArray(ElementName = "payload")]
        [XmlArrayItem(ElementName = "order")]
        public List<Order> Orders { get; set; }
    }
}

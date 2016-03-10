// <copyright file="OrderReportRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Util.DataStructures;

    /// <summary>
    /// Order report request to PayU Latam.
    /// </summary>
    [XmlRoot(ElementName = "request")]
    public class OrderReportRequest : AbstractRequest
    {

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        [XmlElement("details")]
        public SerializableDictionary<string, object> Details { get; set; }
    }
}

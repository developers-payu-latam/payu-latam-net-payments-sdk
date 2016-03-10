
namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Reports;

    /// <summary>
    /// Order report response from PayU Latam. 
    /// </summary>
    [XmlRoot(ElementName = "reportingResponse")]
    public class OrderReportResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [XmlElement(ElementName = "result")]
        public OrderReport Order { get; set; }
    }
}

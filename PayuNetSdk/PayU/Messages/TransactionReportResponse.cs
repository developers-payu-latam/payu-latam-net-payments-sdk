
namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Reports;

    /// <summary>
    /// Transaction report response from PayU Latam. 
    /// </summary>
    [XmlRoot(ElementName = "reportingResponse")]
    public class TransactionReportResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        [XmlElement(ElementName = "result")]
        public TransactionReport Result { get; set; }
    }
}

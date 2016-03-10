// <copyright file="TransactionReport.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Reports
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Payments;
    using PayuNetSdk.PayU.Messages;

    /// <summary>
    /// Represents an transaction result
    /// </summary>
    public class TransactionReport
    {
        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        [XmlElement(ElementName = "payload")]
        public TransactionResponse Transaction { get; set; }
    }
}

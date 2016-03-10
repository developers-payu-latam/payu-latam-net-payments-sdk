// <copyright file="PaymentRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Payments;

    /// <summary>
    /// Payment method request to PayU Latam. 
    /// </summary>
    [XmlRoot(ElementName = "request")]
    public class PaymentRequest : AbstractRequest
    {
        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        [XmlElement("transaction")]
        public Transaction Transaction { get; set; }
    }
}

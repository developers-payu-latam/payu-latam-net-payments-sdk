// <copyright file="PaymentResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;

    /// <summary>
    /// Payment method response from PayU Latam. 
    /// </summary>
    [XmlRoot(ElementName = "paymentResponse")]
    public class PaymentResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the transaction response.
        /// </summary>
        /// <value>
        /// The transaction response.
        /// </value>
        [XmlElement("transactionResponse")]
        public TransactionResponse TransactionResponse { get; set; }
    }
}

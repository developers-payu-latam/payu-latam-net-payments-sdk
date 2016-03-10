// <copyright file="BankInfoRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Payments;

    /// <summary>
    /// Bank info request to PayU Latam.
    /// </summary>
    [XmlRoot(ElementName = "request")]
    public class BankInfoRequest : AbstractRequest
    {
        /// <summary>
        /// Gets or sets the bank list information.
        /// </summary>
        /// <value>
        /// The bank list information.
        /// </value>
        [XmlElement(ElementName = "bankListInformation")]
        public BankListInformation BankListInformation { get; set; }
    }
}

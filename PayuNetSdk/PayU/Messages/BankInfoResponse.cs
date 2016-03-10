// <copyright file="BankInfoResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.PaymentMethods;

    /// <summary>
    /// Bank info response from PayU Latam.
    /// </summary>
    [XmlRoot(ElementName = "bankListResponse")]
    public class BankInfoResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the banks information.
        /// </summary>
        /// <value>
        /// The banks information.
        /// </value>
        [XmlArray("banks")]
        public List<BankInfo> BanksInfo { get; set; }


        /// <summary>
        /// Gets or sets the alternative error.
        /// Esto es debido a la falta de coherencia en la respuesta del API de PayU
        /// </summary>
        /// <value>
        /// The alternative error.
        /// </value>
        [XmlIgnore]
        public PaymentResponse AlternativeError{ get; set; } 
    }
}

// <copyright file="TokenInfoResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Token;
    using System.Collections.Generic;

    /// <summary>
    /// Token response to PayU Latam.  
    /// </summary>
    [XmlRoot(ElementName = "creditCardTokenListResponse")]
    public class TokenInfoResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the credit card tokens.
        /// </summary>
        /// <value>
        /// The credit card tokens.
        /// </value>
        [XmlArray("creditCardTokenList")]
        [XmlArrayItem("creditCardToken")]
        public List<CreditCardToken> CreditCardTokens { get; set; } 
    }
}

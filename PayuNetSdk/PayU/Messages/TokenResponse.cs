// <copyright file="TokenResponse.cs" company="PayU Latam">
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
    [XmlRoot(ElementName = "creditCardTokenResponse")]
    public class TokenResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the credit card token.
        /// </summary>
        /// <value>
        /// The credit card token.
        /// </value>
        [XmlElement("creditCardToken")]
        public CreditCardToken CreditCardToken { get; set; }
    }
}

// <copyright file="TokenRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.Token;

    /// <summary>
    /// Token request to PayU Latam.  
    /// </summary>
    [XmlRoot(ElementName = "request")]
    public class TokenRequest : AbstractRequest<TokenResponse>
    {
        /// <summary>
        /// Gets or sets the credit card token.
        /// </summary>
        /// <value>
        /// The credit card token.
        /// </value>
        [XmlElement("creditCardToken")]
        public CreditCardToken CreditCardToken { get; set; }

        /// <summary>
        /// Gets or sets the credit card token.
        /// 
        /// NOTA: Se hubise podido usar TokenResponse para TokenInfoResponse pero no fue posible 
        /// ya que no existe consistencia en los tags de request-response del API DE PAYU.
        /// </summary>
        /// <value>
        /// The credit card token.
        /// </value>
        [XmlElement("creditCardTokenInformation")]
        public CreditCardToken CreditCardTokenInfo { get; set; }

        /// <summary>
        /// Gets or sets the credit card token.
        /// 
        /// NOTA: Se hubise podido usar TokenResponse para CreditCardTokenRemove pero no fue posible 
        /// ya que no existe consistencia en los tags de request-response del API DE PAYU.
        /// </summary>
        /// <value>
        /// The credit card token.
        /// </value>
        [XmlElement("removeCreditCardToken")]
        public CreditCardToken CreditCardTokenRemove { get; set; }
    }
}

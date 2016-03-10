// <copyright file="PaymentMethodsResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Model.PaymentMethods;

    /// <summary>
    /// Payment method response from PayU Latam. 
    /// </summary>
    [XmlRoot(ElementName = "paymentMethodsResponse")]
    public class PaymentMethodsResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the payment methods.
        /// </summary>
        /// <value>
        /// The payment methods.
        /// </value>
        [XmlArray("paymentMethods")]
        public List<PaymentMethodInfo> PaymentMethods { get; set; }
    }
}

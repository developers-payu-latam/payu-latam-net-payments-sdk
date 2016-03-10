// <copyright file="PaymentMethodsRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;

    /// <summary>
    /// Payment method request to PayU Latam.
    /// </summary>
    [XmlRoot(ElementName = "request")]
    public class PaymentMethodsRequest : AbstractRequest
    {
    }
}

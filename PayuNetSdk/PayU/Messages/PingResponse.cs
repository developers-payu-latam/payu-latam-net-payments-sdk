// <copyright file="PingResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;

    /// <summary>
    /// Ping response from PayU Latam.  
    /// </summary>
    [XmlRoot(ElementName = "paymentResponse")]
    public class PingResponse : AbstractResponse
    {
    }
}

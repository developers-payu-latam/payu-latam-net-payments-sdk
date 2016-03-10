// <copyright file="PingRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;

    /// <summary>
    /// Ping request to PayU Latam.  
    /// </summary>
    [XmlRoot(ElementName= "request")]
    public class PingRequest : AbstractRequest
    {
    }
}

// <copyright file="AbstractResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;

    /// <summary>
    /// Base class for common response from PayU Latam.
    /// </summary>
    public abstract class AbstractResponse
    {
        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>
        /// The response code.
        /// </value>
        [XmlElement("code")]
        public ResponseCode ResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the message error.
        /// </summary>
        /// <value>
        /// The message error.
        /// </value>
        [XmlElement("error")]
        public string MessageError { get; set; }

        /// <summary>
        /// Gets or sets the SDK error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [XmlIgnore]
        public SdkError Error { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        [XmlIgnore]
        public CommonResponse Response { get; set; } 
    }
}

// <copyright file="AbstractRequest.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;

    /// <summary>
    /// Base class for common request to PayU Latam.
    /// </summary>
    public abstract class AbstractRequest
    {
        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        [XmlElement("command")]
        public Command Command { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [XmlElement("language")]
        public Language Language { get; set; }

        /// <summary>
        /// Gets or sets the merchant.
        /// </summary>
        /// <value>
        /// The merchant.
        /// </value>
        [XmlElement("merchant")]
        public Merchant Merchant { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether request is in test mode.
        /// </summary>
        /// <value>
        ///   <c>true</c> if request is in test mode; otherwise, <c>false</c>.
        /// </value>
        [XmlElement("isTest")]
        public bool IsTest { get; set; }

        /// <summary>
        /// Gets or sets the URL to service.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [XmlIgnore]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the internal parameters. 
        /// For internal purposes.
        /// </summary>
        /// <value>
        /// The internal parameters.
        /// </value>
        [XmlIgnore]
        public IDictionary<string, string> InternalParameters { get; set; }
    }

    /// <summary>
    /// Base class for common request to PayU Latam.
    /// </summary>
    public abstract class AbstractRequest<T> : AbstractRequest
    {
        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public T Entity { get; set; }
    }
}

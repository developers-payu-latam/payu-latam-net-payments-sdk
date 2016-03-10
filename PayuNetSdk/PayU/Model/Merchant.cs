// <copyright file="Merchant.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a merchant.
    /// </summary>
    public class Merchant
    {
        /// <summary>
        /// Gets or sets the API login.
        /// </summary>
        /// <value>
        /// The API login.
        /// </value>
        [XmlElement("apiLogin")]
        public string ApiLogin { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>
        /// The API key.
        /// </value>
        [XmlElement("apiKey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlIgnore]
        public int Id { get; set; }

    }
}

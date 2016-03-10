// <copyright file="BankInfo.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.PaymentMethods
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a bank
    /// </summary>
    [XmlType(TypeName = "bank")]
    public class BankInfo
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [XmlElement("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the pse code.
        /// </summary>
        /// <value>
        /// The pse code.
        /// </value>
        [XmlElement("pseCode")]
        public string PseCode { get; set; }
    }
}

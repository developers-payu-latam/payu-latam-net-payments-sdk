// <copyright file="Person.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Personal
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a person.
    /// </summary>
    public abstract class Person
    {
        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        [XmlElement("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        [XmlElement("emailAddress")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the contact phone.
        /// </summary>
        /// <value>
        /// The contact phone.
        /// </value>
        [XmlElement("contactPhone")]
        public string ContactPhone { get; set; }

        /// <summary>
        /// Gets or sets the dni number.
        /// </summary>
        /// <value>
        /// The dni number.
        /// </value>
        [XmlElement("dniNumber")]
        public string DniNumber { get; set; }

        /// <summary>
        /// Gets or sets the CNPJ.
        /// </summary>
        /// <value>
        /// The CNPJ.
        /// </value>
        [XmlElement("CNPJ")]
        public string CNPJ { get; set; }
    }
}

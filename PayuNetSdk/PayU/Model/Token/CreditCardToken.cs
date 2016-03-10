// <copyright file="CreditCardToken.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Token
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;
    using System;

    public class CreditCardToken
    {
        /// <summary>
        /// Gets or sets the credit card token identifier.
        /// </summary>
        /// <value>
        /// The token identifier.
        /// </value>
        [XmlElement("creditCardTokenId")]
        public string TokenId { get; set; }

        /// <summary>
        /// Gets or sets the name on the credit card.
        /// </summary>
        /// <value>
        /// The name on the credit card.
        /// </value>
        [XmlElement("name", IsNullable = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the credit card token payer id
        /// </summary>
        /// <value>
        /// The credit card token payer id
        /// </value>
        [XmlElement("payerId", IsNullable = false)]
        public string PayerId { get; set; }

        /// <summary>
        /// Gets or sets the document on the credit card.
        /// </summary>
        /// <value>
        /// The document on the credit card.
        /// </value>
        [XmlElement("identificationNumber")]
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Gets or sets the credit card token payment method
        /// </summary>
        /// <value>
        /// The credit card token payment method
        /// </value>
        [XmlElement("paymentMethod")]
        public PaymentMethod? PaymentMethod { get; set; }
        public bool ShouldSerializePaymentMethod() { return PaymentMethod.HasValue; }

        /// <summary>
        /// Gets or sets the credit card number.
        /// </summary>
        /// <value>
        /// The credit card number.
        /// </value>
        [XmlElement("number")]
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the credit card expiration date.
        /// </summary>
        /// <value>
        /// The credit card expiration date.
        /// </value>
        [XmlElement("expirationDate")]
        public string ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the masked credit card number.
        /// </summary>
        /// <value>
        /// The masked credit card number.
        /// </value>
        [XmlElement("maskedNumber")]
        public string MaskedNumber { get; set; }

        /// <summary>
        /// Gets or sets the credit card token error description
        /// </summary>
        /// <value>
        /// The credit card token error description
        /// </value>
        [XmlElement("errorDescription")]
        public string ErrorDescription { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        [XmlElement("startDate")]
        public DateTime? StartDate { get; set; }
        public bool ShouldSerializeStartDate() { return StartDate.HasValue; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        [XmlElement("endDate")]
        public DateTime? EndDate { get; set; }
        public bool ShouldSerializeEndDate() { return EndDate.HasValue; }

        [XmlElement("creationDate")]
        public DateTime? CreationDate { get; set; }
        public bool ShouldSerializeCreationDate() { return CreationDate.HasValue; }
    }
}

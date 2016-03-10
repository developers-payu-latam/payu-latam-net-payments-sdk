// <copyright file="Order.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Payments
{
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Util.DataStructures;

    /// <summary>
    /// Represents an order
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the identifier of the order.
        /// </summary>
        /// <value>
        /// The identifier of the order.
        /// </value>
        [XmlElement("id")]
        public int? Id { get; set; }
        public bool ShouldSerializeId() { return Id.HasValue; }

        /// <summary>
        /// Gets or sets the account identifier
        /// </summary>
        /// <value>
        /// The account identifier.
        /// </value>
        [XmlElement("accountId")]
        public int? AccountId { get; set; }
        public bool ShouldSerializeAccountId() { return AccountId.HasValue; }

        /// <summary>
        /// Gets or sets the status of the order
        /// </summary>
        /// <value>
        /// The status of the order.
        /// </value>
        [XmlElement("status")]
        public OrderStatus? Status { get; set; }
        public bool ShouldSerializeStatus() { return Status.HasValue; }

        /// <summary>
        /// Gets or sets order's cancellation code
        /// </summary>
        /// <value>
        /// The order's cancellation code
        /// </value>
        [XmlElement("cancellationCode")]
        public OrderCancellationCode? CancellationCode { get; set; }
        public bool ShouldSerializeCancellationCode() { return CancellationCode.HasValue; }

        /// <summary>
        /// Gets or sets the reference code of the order. 
        /// This is the identifier that the merchant assigns to the order.
        /// </summary>
        /// <value>
        /// The reference code.
        /// </value>
        [XmlElement("referenceCode")]
        public string ReferenceCode { get; set; }

        /// <summary>
        /// Gets or sets the description of the order.
        /// </summary>
        /// <value>
        /// The description of the order.
        /// </value>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the airline code related to this order.
        /// </summary>
        /// <value>
        /// The airline code related to this order.
        /// </value>
        [XmlElement("airlineCode")]
        public string AirlineCode { get; set; }

        /// <summary>
        /// Gets or sets the ISO 639-1 language of the order.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        [XmlElement("language")]
        public Language? Language { get; set; }
        public bool ShouldSerializeLanguage() { return Language.HasValue; }

        /// <summary>
        /// Gets or sets the notify URL of the order.
        /// </summary>
        /// <value>
        /// The notify URL.
        /// </value>
        [XmlElement("notifyUrl")]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        [XmlElement("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the buyer.
        /// </summary>
        /// <value>
        /// The buyer.
        /// </value>
        [XmlElement("buyer")]
        public Buyer Buyer { get; set; }

        /// <summary>
        /// Gets or sets the transactions.
        /// </summary>
        /// <value>
        /// The transactions.
        /// </value>
        [XmlArray("transactions")]
        public List<Transaction> Transactions { get; set; }

        /// <summary>
        /// Gets or sets the additional values.
        /// </summary>
        /// <value>
        /// The additional values.
        /// </value>
        [XmlElement("additionalValues")]
        public SerializableDictionary<string, AdditionalValue> AdditionalValues { get; set; }
    }
}

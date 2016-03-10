// <copyright file="Transaction.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Payments
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model.PaymentMethods;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Util.DataStructures;
    using PayuNetSdk.PayU.Validators.Base;

    /// <summary>
    /// Represents a transaction
    /// </summary>
    //[XmlRoot(ElementName = "transaction")]
    [XmlType(TypeName = "transaction")]
    public class Transaction : IValidatable<Transaction>
    {
        /// <summary>
        /// Gets or sets the transaction order
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        [XmlElement("order")]
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the credit card.
        /// </summary>
        /// <value>
        /// The credit card.
        /// </value>
        [XmlElement("creditCard")]
        public CreditCard CreditCard { get; set; }

        /// <summary>
        /// Gets or sets the credit card swipe.
        /// </summary>
        /// <value>
        /// The credit card swipe.
        /// </value>
        [XmlElement("creditCardSwipe")]
        public CreditCardSwipe CreditCardSwipe { get; set; }

        /// <summary>
        /// Gets or sets the credit card token identifier.
        /// </summary>
        /// <value>
        /// The credit card token identifier.
        /// </value>
        [XmlElement("creditCardTokenId")]
        public string CreditCardTokenId { get; set; }

        /// <summary>
        /// Gets or sets the create credit card token.
        /// </summary>
        /// <value>
        /// The create credit card token.
        /// </value>
        [XmlElement("createCreditCardToken")]
        public bool? CreateCreditCardToken { get; set; }
        public bool ShouldSerializeCreateCreditCardToken() { return CreateCreditCardToken.HasValue; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of the transaction.
        /// </value>
        [XmlElement("type")]
        public TransactionType? TransactionType { get; set; }
        public bool ShouldSerializeType() { return TransactionType.HasValue; }

        /// <summary>
        /// Gets or sets the parent transaction identifier.
        /// </summary>
        /// <value>
        /// The parent transaction identifier.
        /// </value>
        [XmlElement("parentTransactionId")]
        public string ParentTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the payment method.
        /// </summary>
        /// <value>
        /// The payment method.
        /// </value>
        [XmlElement("paymentMethod")]
        public PaymentMethod? PaymentMethod { get; set; }
        public bool ShouldSerializePaymentMethod() { return PaymentMethod.HasValue; }

        /// <summary>
        /// Gets or sets the payment method main.
        /// </summary>
        /// <value>
        /// The payment method main.
        /// </value>
        [XmlElement("paymentMethodMain")]
        public PaymentMethodMain? PaymentMethodMain { get; set; }
        public bool ShouldSerializePaymentMethodMain() { return PaymentMethodMain.HasValue; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        [XmlElement("source")]
        public TransactionSource? Source { get; set; }
        public bool ShouldSerializeSource() { return Source.HasValue; }

        /// <summary>
        /// Gets or sets the payment country.
        /// </summary>
        /// <value>
        /// The payment country.
        /// </value>
        [XmlElement("paymentCountry")]
        public PaymentCountry? PaymentCountry { get; set; }
        public bool ShouldSerializePaymentCountry() { return PaymentCountry.HasValue; }

        /// <summary>
        /// Gets or sets the transaction response.
        /// </summary>
        /// <value>
        /// The transaction response.
        /// </value>
        [XmlElement("transactionResponse")]
        public TransactionResponse TransactionResponse { get; set; }

        /// <summary>
        /// Gets or sets the payer.
        /// </summary>
        /// <value>
        /// The payer.
        /// </value>
        [XmlElement("payer")]
        public Payer Payer { get; set; }

        /// <summary>
        /// Gets or sets the device session identifier.
        /// </summary>
        /// <value>
        /// The device session identifier.
        /// </value>
        [XmlElement("deviceSessionId")]
        public string DeviceSessionId { get; set; }

        /// <summary>
        /// Gets or sets the ip address.
        /// </summary>
        /// <value>
        /// The ip address.
        /// </value>
        [XmlElement("ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the cookie.
        /// </summary>
        /// <value>
        /// The cookie.
        /// </value>
        [XmlElement("cookie")]
        public string Cookie { get; set; }

        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        [XmlElement("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the expiration date.
        /// </summary>
        /// <value>
        /// The expiration date.
        /// </value>
        [XmlElement("expirationDate")]
        public DateTime? ExpirationDate { get; set; }
        public bool ShouldSerializeExpirationDate() { return ExpirationDate.HasValue; }

        /// <summary>
        /// Gets or sets the additional values.
        /// </summary>
        /// <value>
        /// The additional values.
        /// </value>
        [XmlElement("additionalValues")]
        public SerializableDictionary<string, AdditionalValue> AdditionalValues { get; set; }

        /// <summary>
        /// Gets or sets the extra parameters.
        /// </summary>
        /// <value>
        /// The extra parameters.
        /// </value>
        [XmlElement("extraParameters")]
        public SerializableDictionary<string, string> ExtraParameters { get; set; }
        public bool ShouldSerializeExtraParameters() { return ExtraParameters != null; }

        /// <summary>
        /// Validates the specified validator.
        /// </summary>
        /// <param name="validator">The validator.</param>
        /// <param name="brokenRules">The broken rules.</param>
        /// <returns></returns>
        public bool Validate(IValidator<Transaction> validator, out IEnumerable<string> brokenRules)
        {
            brokenRules = validator.BrokenRules(this);
            return validator.IsValid(this);
        }
    }
}

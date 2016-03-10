// <copyright file="BankListInformation.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Payments
{
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;

    /// <summary>
    /// 
    /// </summary>
    public class BankListInformation
    {
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
        /// Gets or sets the payment country.
        /// </summary>
        /// <value>
        /// The payment country.
        /// </value>
        [XmlElement("paymentCountry")]
        public PaymentCountry? PaymentCountry { get; set; }
        public bool ShouldSerializePaymentCountry() { return PaymentCountry.HasValue; }
    }
}

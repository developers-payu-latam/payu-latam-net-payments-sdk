// <copyright file="CreditCardResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Model.RecurringPayments;

    /// <summary>
    /// Credit card response from PayU Latam.
    /// </summary>
    public class CreditCardResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the credit card.
        /// </summary>
        /// <value>
        /// The credit card.
        /// </value>
        public CreditCard CreditCard { get; set; }        
    }
}

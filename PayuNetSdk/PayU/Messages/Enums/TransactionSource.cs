// <copyright file="TransactionSource.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents the transaction source in the PayU SDK.
    /// </summary>
    public enum TransactionSource
    {
        /// <summary>
        /// The default transaction source in the PayU SDK.
        /// </summary>
        PAYU_SDK,

        /// <summary>
        /// An online transaction (ecommerce).
        /// </summary>
        WEB,

        /// <summary>
        /// Mail Order/Telephone Order.
        /// </summary>
        MOTO,

        /// <summary>
        /// Retail transaction.
        /// </summary>
        RETAIL,

        /// <summary>
        /// Mobile device transaction.
        /// </summary>
        MOBILE,
        
        /// <summary>
        /// Online processing
        /// </summary>
        ONLINE_PROCESSING,

        /// <summary>
        /// Recurring Payments
        /// </summary>
        RECURRING_PAYMENTS,

        /// <summary>
        /// Payment request
        /// </summary>
        PAYMENT_REQUEST,
        
        /// <summary>
        /// Payment button 
        /// </summary>
        PAYMENT_BUTTON,
    }
}

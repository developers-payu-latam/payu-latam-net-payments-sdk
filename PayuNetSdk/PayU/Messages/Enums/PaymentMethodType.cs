// <copyright file="PaymentMethodType.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a payment method type in the PayU SDK.
    /// </summary>
    public enum PaymentMethodType
    {

        /// <summary>
        /// Payment with credit card.
        /// </summary>
        CREDIT_CARD,

        /// <summary>
        /// Payment using PSE.
        /// </summary>
        PSE,

        /// <summary>
        /// Cash Payment 
        /// </summary>
        CASH,

        /// <summary>
        /// Referenced payment.
        /// </summary>
        REFERENCED,

        /// <summary>
        /// Payment with check account.
        /// </summary>
        CHECK_ACCOUNT,

        /// <summary>
        /// Payment using verified by visa.
        /// </summary>
        VERIFIED_BY_VISA,

        /// <summary>
        /// Payment using ACH debit.
        /// </summary>
        ACH_DEBIT,

        /// <summary>
        /// Payment using debit card.
        /// </summary>
        DEBIT_CARD,

        /// <summary>
        /// Payment with Special card.
        /// </summary>
        SPECIAL_CARD,
    }
}

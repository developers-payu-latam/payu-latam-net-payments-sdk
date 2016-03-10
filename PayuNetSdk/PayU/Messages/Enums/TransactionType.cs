// <copyright file="TransactionType.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a transaction type in the PayU SDK.
    /// </summary>
    public enum TransactionType
    {
        /// <summary>
        /// Only authorization transaction.
        /// </summary>
        AUTHORIZATION,

        /// <summary>
        /// Authorization and capture transaction.
        /// </summary>
        AUTHORIZATION_AND_CAPTURE,

        /// <summary>
        /// Only capture transaction.
        /// </summary>
        CAPTURE,

        /// <summary>
        /// Cancel transaction.
        /// </summary>
        CANCELLATION,

        /// <summary>
        /// Void transaction.
        /// </summary>
        VOID,

        /// <summary>
        /// Refund transaction.
        /// </summary>
        REFUND,

        /// <summary>
        /// Credit transaction.
        /// </summary>
        CREDIT
    }
}

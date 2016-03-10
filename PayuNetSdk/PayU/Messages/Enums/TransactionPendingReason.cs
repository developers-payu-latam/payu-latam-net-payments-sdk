// <copyright file="TransactionPendingReason.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents an error code for transactions in the PayU SDK.
    /// </summary>
    public enum TransactionPendingReason
    {
        /// <summary>
        /// Used when a Transaction is waiting for a notification.
        /// </summary>
        AWAITING_NOTIFICATION,

        /// <summary>
        /// Used when a Transaction is waiting for a review.
        /// </summary>
        PENDING_REVIEW,

        /// <summary>
        /// Used when a Transaction is waiting for a transmission.
        /// </summary>
        PENDING_TRANSMISSION,
    }
}

// <copyright file="TransactionState.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a transaction state in the PayU SDK.
    /// </summary>
    public enum TransactionState
    {
        /// <summary>
        /// Approved transaction
        /// </summary>
        APPROVED,
        
        /// <summary>
        /// Declined transaction 
        /// </summary>
        DECLINED,

        /// <summary>
        /// Error in transaction
        /// </summary>
        ERROR,

        /// <summary>
        /// Pending transaction 
        /// </summary>
        PENDING,

        /// <summary>
        /// Expired transaction
        /// </summary>
        EXPIRED,
        
        /// <summary>
        /// Submitted transaction
        /// </summary>
        SUBMITTED,
    }
}

// <copyright file="TransactionErrorCode.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents an error code for transactions in the PayU SDK.
    /// </summary>
    public enum TransactionErrorCode
    {
        /// <summary>
        /// Error associated with an internal problem in the server
        /// </summary>
        INTERNAL_ERROR,

        /// <summary>
        /// Error associated with not having response from the server
        /// </summary>
        ENTITY_NO_RESPONSE,
        
        /// <summary>
        /// Error associated with a bad response from the payment network
        /// </summary>
        PAYMENT_NETWORK_BAD_RESPONSE,

        /// <summary>
        /// Error associated with a connection failure with the payment network
        /// </summary>
        PAYMENT_NETWORK_NO_CONNECTION,

        /// <summary>
        /// Error associated with not having response from the payment network
        /// </summary>
        PAYMENT_NETWORK_NO_RESPONSE,
    }
}

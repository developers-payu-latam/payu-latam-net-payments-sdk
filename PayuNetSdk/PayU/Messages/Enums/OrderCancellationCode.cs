// <copyright file="OrderCancellationCode.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a order cancellation code in the PayU SDK.
    /// </summary>
    public enum OrderCancellationCode
    {
        /// <summary>
        /// The order expired
        /// </summary>
        EXPIRED,

        /// <summary>
        /// Could not verify the order and can probably be a fraud.
        /// </summary>
        UNABLE_TO_VERIFY,

        /// <summary>
        /// The merchant requested to cancel the order.
        /// </summary>
        REQUESTED_BY_MERCHANT,

        /// <summary>
        /// The buyer requested to cancel the order.
        /// </summary>
        REQUESTED_BY_BUYER,

        /// <summary>
        /// The order is fraudulent and must not be processed anymore.
        /// </summary>
        FRAUDULENT,

        /// <summary>
        /// The order was disputed by the buyer.
        /// </summary>
        DISPUTED
    }
}

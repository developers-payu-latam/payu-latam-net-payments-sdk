// <copyright file="OrderStatus.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents an order status in the PayU SDK.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Status for an order recently created.
        /// </summary>
        NEW,

        /// <summary>
        /// Status for an order being processed.
        /// </summary>
        IN_PROGRESS,

        /**
         * Status for an authorized order.
         */
        AUTHORIZED,

        /**
         * Status for a captured order.
         */
        CAPTURED,

        /**
         * Status for an order that was cancelled.
         */
        CANCELLED,

        /**
         * Status for an order that was declined.
         */
        DECLINED,

        /**
         * Status for a refunded order.
         */
        REFUNDED

    }
}

// <copyright file="OrderBuilderFactory.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders.Factories
{
    using System;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;

    /// <summary>
    /// Factory for build <see cref="Order"/> objects for Authorization, 
    /// Capture, Authorizatin and Capture, Void and Refund operations.
    /// </summary>
    internal class OrderBuilderFactory
    {
        /// <summary>
        /// Gets the order builder.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Occurs when TransactionType is not AUTHORIZATION, 
        /// AUTHORIZATION_AND_CAPTURE, CAPTURE, VOID neither REFUND.</exception>
        public static AbstractOrderBuilder GetOrderBuilder(AbstractRequest request, int? orderId, TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.AUTHORIZATION:
                case TransactionType.AUTHORIZATION_AND_CAPTURE:
                    if (!orderId.HasValue)
                    {
                        return new AuthCaptureNewOrderBuilder(request);
                    }
                    else
                    {
                        return new AuthCaptureExistingOrderBuilder(request);
                    }
                case TransactionType.CAPTURE:
                case TransactionType.VOID:
                case TransactionType.REFUND:
                    return new ExistingOrderBuilder(request);
                default:
                    throw new NotImplementedException(
                        string.Format("OrderBuilder not implemented for: ", transactionType));
            }
        }

    }
}

// <copyright file="AuthAndCaptureAuthTransactionBuilderFactory.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders.Factories
{
    using System;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.Resources;

    /// <summary>
    /// Factory for build <see cref="Transaction"/> objects for Authorization
    /// and Authorizatin and Capture operations.
    /// </summary>
    internal class AuthAndCaptureAuthTransactionBuilderFactory
    {
        /// <summary>
        /// Gets the transaction builder for Authorization and Authorizatin and Capture operations. 
        /// See <see cref="TransactionType"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <returns><see cref="AbstractTransactionBuilder"/> instance for build <see cref="Transaction"/> objects.</returns>
        /// <exception cref="System.NotImplementedException">Occurs when PaymentMethodMain is not CREDIT_CARD neither 
        /// CASH neither REFERENCED.</exception>
        /// <exception cref="System.NotSupportedException">Occurs when TransactionType is not AUTHORIZATION neither 
        /// AUTHORIZATION_AND_CAPTURE.</exception>
        public static AbstractTransactionBuilder GetTransactionBuilder(AbstractRequest request, 
            TransactionType transactionType)
        {
            string value;
            if (DataConverter.TryGetValue(request.InternalParameters, PayUParameterName.PAYMENT_METHOD, out value))
            {
                return GetTransactionBuilderWithPaymentMethod(request, transactionType);
            }
            if (DataConverter.TryGetValue(request.InternalParameters, PayUParameterName.TOKEN_ID, out value))
            {
                return GetTransactionBuilderWithToken(request, transactionType);
            }

            throw new ArgumentNullException(string.Format(PayUSdkMessages.RequiredParameter, "PAYMENT_METHOD | TOKEN_ID"));
        }

        /// <summary>
        /// Gets the transaction builder with payment method.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        private static AbstractTransactionBuilder GetTransactionBuilderWithPaymentMethod(AbstractRequest request,
            TransactionType transactionType)
        {
            PaymentMethod paymentMethod = DataConverter.GetEnumValue<PaymentMethod>(
                request.InternalParameters, PayUParameterName.PAYMENT_METHOD);

            PaymentMethodType paymentMethodType = PaymentMethodTypeReference.GetPaymentMethodType(paymentMethod);

            switch (transactionType)
            {
                case TransactionType.AUTHORIZATION:
                    if (PaymentMethodType.CREDIT_CARD.Equals(paymentMethodType))
                    {
                        return new CreditCardAuthAndCaptureAuthTransactionBuilder(request, transactionType);
                    }
                    break;
                case TransactionType.AUTHORIZATION_AND_CAPTURE:
                    if (PaymentMethodType.CREDIT_CARD.Equals(paymentMethodType))
                    {
                        return new CreditCardAuthAndCaptureAuthTransactionBuilder(request, transactionType);
                    }
                    if (PaymentMethodType.CASH.Equals(paymentMethodType) || PaymentMethodType.REFERENCED.Equals(paymentMethodType))
                    {
                        return new CashRefAuthAndCaptureAuthTransactionBuilder(request, transactionType);
                    }
                    throw new NotImplementedException(string.Format("TransactionBuilder not implemented for: ", paymentMethodType));
            }
            throw new NotSupportedException(string.Format("Not supported {0} for {1}", transactionType, paymentMethodType));
        }

        /// <summary>
        /// Gets the transaction builder with token.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException"></exception>
        private static AbstractTransactionBuilder GetTransactionBuilderWithToken(AbstractRequest request,
            TransactionType transactionType)
        {
            string tokenId = DataConverter.GetValue(request.InternalParameters, PayUParameterName.TOKEN_ID);

            switch (transactionType)
            {
                case TransactionType.AUTHORIZATION:
                case TransactionType.AUTHORIZATION_AND_CAPTURE:
                    return new CreditCardAuthAndCaptureAuthWithTokenTransactionBuilder(request, transactionType);
            }
            throw new NotSupportedException(string.Format("Not supported {0} for token operation", transactionType));
        }
    }
}

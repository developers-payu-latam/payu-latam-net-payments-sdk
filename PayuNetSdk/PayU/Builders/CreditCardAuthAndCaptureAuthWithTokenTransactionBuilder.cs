// <copyright file="CreditCardAuthAndCaptureAuthWithTokenTransactionBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Builders.Factories;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.PayU.Util.DataStructures;

    /// <summary>
    /// Builder class for build new <see cref="Transaction"/> objects for AUTHORIZATION AND CAPTURE, 
    /// AUTHORIZATION for credit card payments methods with token.
    /// </summary>
    internal class CreditCardAuthAndCaptureAuthWithTokenTransactionBuilder : CreditCardAuthAndCaptureAuthTransactionBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardAuthAndCaptureAuthTransactionBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        public CreditCardAuthAndCaptureAuthWithTokenTransactionBuilder(AbstractRequest request,
            TransactionType transactionType)
            : base(request, transactionType)
        {
            base.transaction.CreditCardTokenId = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.TOKEN_ID);
        }

        /// <summary>
        /// Builds the payment method.
        /// </summary>
        public override void BuildPaymentMethod()
        {
            // Do nothing
            // Must override base method.
        }
    }
}

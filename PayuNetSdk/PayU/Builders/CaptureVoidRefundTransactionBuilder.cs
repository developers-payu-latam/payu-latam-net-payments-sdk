// <copyright file="CaptureVoidRefundTransactionBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Builders.Factories;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Builder class for build new <see cref="Transaction"/> objects for CAPTURE, VOID and REFUND.
    /// </summary>
    internal class CaptureVoidRefundTransactionBuilder : AbstractTransactionBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaptureVoidRefundTransactionBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        public CaptureVoidRefundTransactionBuilder(AbstractRequest request,
            TransactionType transactionType)
            : base(request, transactionType)
        {
        }

        /// <summary>
        /// Builds the additional information.
        /// </summary>
        public override void BuildAdditionalInformation()
        {
            base.transaction.ParentTransactionId = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.TRANSACTION_ID);
        }

        /// <summary>
        /// Builds the order.
        /// </summary>
        public override void BuildOrder()
        {
            int? orderId = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.ORDER_ID);

            AbstractOrderBuilder orderBuilder = OrderBuilderFactory.GetOrderBuilder(
                base.request, orderId, base.transaction.TransactionType.Value);
            base.transaction.Order = orderBuilder.Order;
        }

        /// <summary>
        /// Builds the buyer.
        /// </summary>
        public override void BuildBuyer()
        {
            // Do nothing :)
        }

        /// <summary>
        /// Builds the payer.
        /// </summary>
        public override void BuildPayer()
        {
            // Do nothing :)
        }

        /// <summary>
        /// Builds the credit card.
        /// </summary>
        public override void BuildCreditCard()
        {
            // Do nothing :)
        }

        /// <summary>
        /// Builds the payment method.
        /// </summary>
        public override void BuildPaymentMethod()
        {
            // Do nothing :)
        }

        /// <summary>
        /// Builds the additional values.
        /// </summary>
        public override void BuildAdditionalValues()
        {
            // Do nothing :)
        }
    }
}

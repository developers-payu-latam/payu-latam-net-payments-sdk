// <copyright file="CashRefAuthAndCaptureAuthTransactionBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

using PayuNetSdk.PayU.Builders.Factories;
using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.Messages.Enums;
using PayuNetSdk.PayU.Util;

namespace PayuNetSdk.PayU.Builders
{
    /// <summary>
    /// Builder class for build new <see cref="Transaction"/> objects for AUTHORIZATION AND CAPTURE, 
    /// AUTHORIZATION for cash and reference payments methods.
    /// </summary>
    internal class CashRefAuthAndCaptureAuthTransactionBuilder : AbstractTransactionBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CashRefAuthAndCaptureAuthTransactionBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        public CashRefAuthAndCaptureAuthTransactionBuilder(AbstractRequest request,
            TransactionType transactionType)
            : base(request, transactionType)
        {
        }

        /// <summary>
        /// Builds the additional information.
        /// </summary>
        public override void BuildAdditionalInformation() {
            base.transaction.ExpirationDate = DataConverter.GetDateTimeValue(
                base.request.InternalParameters, PayUParameterName.EXPIRATION_DATE); 
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
            base.transaction.Order.Buyer = new BuyerPersonBuilder(base.request).Person;
        }

        /// <summary>
        /// Builds the payer.
        /// </summary>
        public override void BuildPayer()
        {
            base.transaction.Payer = new PayerPersonBuilder(base.request).Person;
        }

        /// <summary>
        /// Builds the credit card.
        /// </summary>
        public override void BuildCreditCard()
        {
            // Do nothing
        }

        /// <summary>
        /// Builds the payment method.
        /// </summary>
        public override void BuildPaymentMethod()
        {
            base.transaction.PaymentMethod = DataConverter.GetEnumValue<PaymentMethod>(
                base.request.InternalParameters, PayUParameterName.PAYMENT_METHOD);
        }

        /// <summary>
        /// Builds the additional values.
        /// </summary>
        public override void BuildAdditionalValues()
        {
            // Do Nothing
        }
    }
}

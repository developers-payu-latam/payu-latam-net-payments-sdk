// <copyright file="CreditCardAuthAndCaptureAuthTransactionBuilder.cs" company="PayU Latam">
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
    /// AUTHORIZATION for credit card payments methods.
    /// </summary>
    internal class CreditCardAuthAndCaptureAuthTransactionBuilder : AbstractTransactionBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardAuthAndCaptureAuthTransactionBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        public CreditCardAuthAndCaptureAuthTransactionBuilder(AbstractRequest request,
            TransactionType transactionType)
            : base(request, transactionType)
        {
        }

        /// <summary>
        /// Builds the additional information.
        /// </summary>
        public override void BuildAdditionalInformation() {

            this.AddPaymentCountry();
            this.AddExtraParameters();

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
            base.transaction.CreditCard = new CreditCardBuilder(
                base.request).CreditCard;
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

        /// <summary>
        /// Adds the extra parameters.
        /// </summary>
        private void AddExtraParameters()
        {
            string installmentsNumber = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.INSTALLMENTS_NUMBER);

            if (!string.IsNullOrEmpty(installmentsNumber) )
            {
                if (base.transaction.ExtraParameters == null)
                {
                    base.transaction.ExtraParameters = new SerializableDictionary<string, string>();
                }

                base.transaction.ExtraParameters.Add("INSTALLMENTS_NUMBER", installmentsNumber);
            }
        }

        /// <summary>
        /// Adds the payment country.
        /// </summary>
        private void AddPaymentCountry()
        {
            try
            {
                base.transaction.PaymentCountry = DataConverter.GetEnumValue<PaymentCountry>(
                    base.request.InternalParameters, PayUParameterName.COUNTRY);
            }
            catch
            {
                // Do Nothing. Sure!!! :D
            }
        }
    }
}

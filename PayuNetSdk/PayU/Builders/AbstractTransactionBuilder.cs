// <copyright file="AbstractTransactionBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;
    using PayuNetSdk.PayU.Model.Payments;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.PayU.Util.Network;

    /// <summary>
    /// Base class for build <see cref="Transaction"/> objects.
    /// </summary>
    internal abstract class AbstractTransactionBuilder
    {
        protected Transaction transaction;

        protected AbstractRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractTransactionBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        public AbstractTransactionBuilder(AbstractRequest request, TransactionType transactionType)
        {
            this.transaction = new Transaction();
            this.transaction.TransactionType = transactionType;
            this.request = request;
        }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        public Transaction Transaction
        {
            get
            {
                this.Build();
                return this.transaction;
            }
        }

        /// <summary>
        /// Builds the additional information.
        /// </summary>
        public abstract void BuildAdditionalInformation();

        /// <summary>
        /// Builds the order.
        /// </summary>
        public abstract void BuildOrder();

        /// <summary>
        /// Builds the buyer.
        /// </summary>
        public abstract void BuildBuyer();

        /// <summary>
        /// Builds the payer.
        /// </summary>
        public abstract void BuildPayer();

        /// <summary>
        /// Builds the credit card.
        /// </summary>
        public abstract void BuildCreditCard();

        /// <summary>
        /// Builds the payment method.
        /// </summary>
        public abstract void BuildPaymentMethod();

        /// <summary>
        /// Builds the additional values.
        /// </summary>
        public abstract void BuildAdditionalValues();

        /// <summary>
        /// Creates the additional value.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <param name="value">The value.</param>
        /// <returns><see cref="AdditionalValue"/> instance.</returns>
        protected AdditionalValue CreateAdditionalValue(Currency currency, decimal value)
        {
            AdditionalValue additional = new AdditionalValue();

            additional.Currency = currency;
            additional.Value = value;

            return additional;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            // Adds basic information
            this.transaction.Cookie = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.COOKIE);
            this.transaction.IpAddress = IpAddress.GetInstance().GetLocalIPAddress();
            this.transaction.UserAgent = PayU.Api.PayU.API_NAME;
            this.transaction.Source = TransactionSource.PAYU_SDK;

            this.BuildAdditionalInformation();
            this.BuildOrder();
            this.BuildBuyer();
            this.BuildPayer();
            this.BuildCreditCard();
            this.BuildPaymentMethod();
            this.BuildAdditionalValues();
        }
    }
}

// <copyright file="TokenBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model.Token;
    using PayuNetSdk.PayU.Util;
    using System;

    /// <summary>
    /// Builder class for build <see cref="CreditCardToken"/> objects.
    /// </summary>
    internal class CreditCardTokenBuilder
    {
        private CreditCardToken creditCardToken;

        protected AbstractRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardTokenBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreditCardTokenBuilder(AbstractRequest request)
        {
            this.request = request;
            this.creditCardToken = new CreditCardToken();
        }

        /// <summary>
        /// Gets the credit card token.
        /// </summary>
        /// <value>
        /// The credit card token.
        /// </value>
        public CreditCardToken CreditCardToken
        {
            get
            {
                this.Build();
                return this.creditCardToken;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            // Adds basic info
            this.creditCardToken.PayerId = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_ID);
            this.creditCardToken.Name = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_NAME);
            this.creditCardToken.Number = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.CREDIT_CARD_NUMBER);
            this.creditCardToken.ExpirationDate = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.CREDIT_CARD_EXPIRATION_DATE);
            
            this.creditCardToken.TokenId = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.TOKEN_ID);

            try
            {
                this.creditCardToken.PaymentMethod = DataConverter.GetEnumValue<PaymentMethod>(
                        this.request.InternalParameters, PayUParameterName.PAYMENT_METHOD);

                this.creditCardToken.StartDate  = DataConverter.GetDateTimeValue(
                    this.request.InternalParameters, PayUParameterName.START_DATE);

                this.creditCardToken.EndDate = DataConverter.GetDateTimeValue(
                    this.request.InternalParameters, PayUParameterName.END_DATE);
            }
            catch (ArgumentNullException)
            {
                // To do nothing
            }
        }
    }
}

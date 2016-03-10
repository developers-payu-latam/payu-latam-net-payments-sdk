// <copyright file="CreditCardBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Payments;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Builder class for build new <see cref="CreditCard"/>.
    /// </summary>
    internal class CreditCardBuilder
    {
        private CreditCard creditCard;
        protected AbstractRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreditCardBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreditCardBuilder(AbstractRequest request)
        {
            this.creditCard = new CreditCard();
            this.request = request;
        }

        /// <summary>
        /// Gets the credit card.
        /// </summary>
        /// <value>
        /// The credit card.
        /// </value>
        public CreditCard CreditCard
        {
            get
            {
                this.Build();
                return this.creditCard;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            this.creditCard.Name = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_NAME);
            this.creditCard.Number = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.CREDIT_CARD_NUMBER);
            this.creditCard.ExpirationDate = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.CREDIT_CARD_EXPIRATION_DATE);
            this.creditCard.ProcessWithoutCvv2 = DataConverter.GetBooleanValue(
                this.request.InternalParameters, PayUParameterName.PROCESS_WITHOUT_CVV2);
            this.creditCard.SecurityCode = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.CREDIT_CARD_SECURITY_CODE);
        }
    }
}

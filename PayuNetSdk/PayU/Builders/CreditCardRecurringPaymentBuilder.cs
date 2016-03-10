// <copyright file="CreditCardRecurringPaymentBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Util;
    using System.Text.RegularExpressions;
    using System;

    /// <summary>
    /// Builder class for build new <see cref="CreditCardRecurringPaymentBuilder"/>.
    /// </summary>
    internal class CreditCardRecurringPaymentBuilder : AbstractBuilder<CreditCard>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreditCardRecurringPaymentBuilder(AbstractRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public override void Build()
        {

            this.Entity.Token = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.TOKEN_ID);
            this.Entity.CustomerId = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CUSTOMER_ID);
            this.Entity.Number = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CREDIT_CARD_NUMBER);
            this.Entity.Name = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.PAYER_NAME);
            this.Entity.Type = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.PAYMENT_METHOD);

            string expirationDate = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CREDIT_CARD_EXPIRATION_DATE);

            if (expirationDate != null)
            {
                Regex regex = new Regex(@"(\d{4})[/](\d{2})");
                Match match = regex.Match(expirationDate);

                if (match.Success)
                {
                    try
                    {
                        this.Entity.ExpYear = int.Parse(match.Groups[1].Value);
                        this.Entity.ExpMonth = int.Parse(match.Groups[2].Value);
                    }
                    catch (Exception)
                    {
                        // Do nothing. Expect validation from the server
                    }
                }
            }

            AddressBuilder addressBuilder = new AddressBuilder(base.request, AddressBuilderType.Rest);
            this.Entity.Address = addressBuilder.Address;

        }
    }
}

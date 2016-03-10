// <copyright file="CustomerBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Util;
using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Model.Personal;
    using System.Text.RegularExpressions;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Builder class for build new <see cref="CustomerWithCreditCardBuilder"/>.
    /// </summary>
    internal class CustomerWithCreditCardBuilder : CustomerBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerWithCreditCardBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CustomerWithCreditCardBuilder(AbstractRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public override void Build()
        {
            base.Build();

            base.Entity.CreditCards = new List<CreditCard>();
            CreditCardRecurringPaymentBuilder creditCardBuilder = new CreditCardRecurringPaymentBuilder(base.request);
            base.Entity.CreditCards.Add(creditCardBuilder.Entity);
        }
    }
}

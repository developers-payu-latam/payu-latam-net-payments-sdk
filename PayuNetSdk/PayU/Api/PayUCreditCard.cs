// <copyright file="PayUCreditCard.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

using PayuNetSdk.PayU.Messages;
using System.Collections.Generic;
using PayuNetSdk.PayU.Builders;
using PayuNetSdk.PayU.Services;
using PayuNetSdk.PayU.Messages.Enums;
namespace PayuNetSdk.PayU.Api
{
    public sealed class PayUCreditCard : PayU
    {
        /// <summary>
        /// PayUCreditCard instance for singleton pattern.
        /// </summary>
        private static PayUCreditCard instance;

        private static object syncLock = new object();

        /// <summary>
        /// The recurring payment service
        /// </summary>
        private RecurringPaymentService recurringPaymentService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUCreditCard"/> class from being created.
        /// </summary>
        private PayUCreditCard()
        {
            recurringPaymentService = new RecurringPaymentService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUCreditCard Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUCreditCard();
                        }
                    }
                }
                return instance;
            }
        }

        ////////////////////////////////////////////////////////////////
        //// PUBLIC OPERATIONS
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates a CreditCard with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CreditCardResponse Create(IDictionary<string, string> parameters)
        {
            CreditCardRequest request = base.CreateBaseRequest<CreditCardRequest>(ServerType.RecurringPayment, parameters);

            CreditCardRecurringPaymentBuilder builder = new CreditCardRecurringPaymentBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.CreateCreditCard(request);
        }

        /// <summary>
        /// Updates a CreditCard with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CreditCardResponse Update(IDictionary<string, string> parameters)
        {
            CreditCardRequest request = base.CreateBaseRequest<CreditCardRequest>(ServerType.RecurringPayment, parameters);

            CreditCardRecurringPaymentBuilder builder = new CreditCardRecurringPaymentBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.UpdateCreditCard(request);
        }

        /// <summary>
        /// Finds a CreditCard with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CreditCardResponse Find(IDictionary<string, string> parameters)
        {
            CreditCardRequest request = base.CreateBaseRequest<CreditCardRequest>(ServerType.RecurringPayment, parameters);

            CreditCardRecurringPaymentBuilder builder = new CreditCardRecurringPaymentBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.GetCreditCard(request);
        }

        /// <summary>
        /// Deletes a CreditCard with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CreditCardResponse Delete(IDictionary<string, string> parameters)
        {
            CreditCardRequest request = base.CreateBaseRequest<CreditCardRequest>(ServerType.RecurringPayment, parameters);

            CreditCardRecurringPaymentBuilder builder = new CreditCardRecurringPaymentBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.DeleteCreditCard(request);
        }
    }
}

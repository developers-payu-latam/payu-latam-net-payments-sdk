// The MIT License (MIT)
//
// Copyright (c) 2016 PayU Latam
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
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

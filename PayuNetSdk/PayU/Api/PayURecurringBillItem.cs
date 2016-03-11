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
using PayuNetSdk.PayU.Builders;
using System.Collections.Generic;
using PayuNetSdk.PayU.Services;
using PayuNetSdk.PayU.Messages.Enums;
namespace PayuNetSdk.PayU.Api
{
    public sealed class PayURecurringBillItem : PayU
    {
        /// <summary>
        /// PayURecurringBillItem instance for singleton pattern.
        /// </summary>
        private static PayURecurringBillItem instance;

        private static object syncLock = new object();

        /// <summary>
        /// The recurring payment service
        /// </summary>
        private RecurringPaymentService recurringPaymentService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayURecurringBillItem"/> class from being created.
        /// </summary>
        private PayURecurringBillItem()
        {
            recurringPaymentService = new RecurringPaymentService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayURecurringBillItem Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayURecurringBillItem();
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
        /// Creates a recurring bill item plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public RecurringBillItemResponse Create(IDictionary<string, string> parameters)
        {
            RecurringBillItemRequest request = base.CreateBaseRequest<RecurringBillItemRequest>(ServerType.RecurringPayment, parameters);

            RecurringBillItemBuilder builder = new RecurringBillItemBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.CreateRecurringBillItem(request);
        }

        /// <summary>
        /// Updates a recurring bill item plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public RecurringBillItemResponse Update(IDictionary<string, string> parameters)
        {
            RecurringBillItemRequest request = base.CreateBaseRequest<RecurringBillItemRequest>(ServerType.RecurringPayment, parameters);

            RecurringBillItemBuilder builder = new RecurringBillItemBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.UpdateRecurringBillItem(request);
        }

        /// <summary>
        /// Finds a recurring bill item plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public RecurringBillItemResponse Find(IDictionary<string, string> parameters)
        {
            RecurringBillItemRequest request = base.CreateBaseRequest<RecurringBillItemRequest>(ServerType.RecurringPayment, parameters);

            RecurringBillItemBuilder builder = new RecurringBillItemBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.GetRecurringBillItem(request);
        }

        /// <summary>
        /// Deletes a recurring bill item plan with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public RecurringBillItemResponse Delete(IDictionary<string, string> parameters)
        {
            RecurringBillItemRequest request = base.CreateBaseRequest<RecurringBillItemRequest>(ServerType.RecurringPayment, parameters);

            RecurringBillItemBuilder builder = new RecurringBillItemBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.DeleteRecurringBillItem(request);
        }
    }
}

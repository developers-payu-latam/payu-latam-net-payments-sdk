// <copyright file="PayURecurringBillItem.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
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

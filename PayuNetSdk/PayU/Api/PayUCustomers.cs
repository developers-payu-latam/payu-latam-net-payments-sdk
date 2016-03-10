// <copyright file="PayUCustomers.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Api
{
    using PayuNetSdk.PayU.Messages;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Services;
    using PayuNetSdk.PayU.Builders;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Messages.Enums;

    /// <summary>
    /// 
    /// </summary>
    public sealed class PayUCustomers : PayU
    {
        /// <summary>
        /// PayUCustomers instance for singleton pattern.
        /// </summary>
        private static PayUCustomers instance;

        private static object syncLock = new object();

        /// <summary>
        /// The recurring payment service
        /// </summary>
        private RecurringPaymentService recurringPaymentService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUCustomers"/> class from being created.
        /// </summary>
        private PayUCustomers() 
        {
            recurringPaymentService = new RecurringPaymentService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUCustomers Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUCustomers();
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
        /// Creates a customer with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CustomerResponse Create(IDictionary<string, string> parameters)
        {
            CustomerRequest request = base.CreateBaseRequest<CustomerRequest>(ServerType.RecurringPayment, parameters);

            CustomerBuilder builder = new CustomerBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.CreateCustomer(request);            
        }

        /// <summary>
        /// Creates a customer with credit card with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CustomerResponse CreateCustomerWithCreditCard(IDictionary<string, string> parameters)
        {
            CustomerRequest request = base.CreateBaseRequest<CustomerRequest>(ServerType.RecurringPayment, parameters);

            CustomerWithCreditCardBuilder builder = new CustomerWithCreditCardBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.CreateCustomer(request);
        }

        /// <summary>
        /// Updates a customer with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CustomerResponse Update(IDictionary<string, string> parameters)
        {
            CustomerRequest request = base.CreateBaseRequest<CustomerRequest>(ServerType.RecurringPayment, parameters);

            CustomerBuilder builder = new CustomerBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.UpdateCustomer(request);
        }

        /// <summary>
        /// Finds a customer with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CustomerResponse Find(IDictionary<string, string> parameters)
        {
            CustomerRequest request = base.CreateBaseRequest<CustomerRequest>(ServerType.RecurringPayment, parameters);

            CustomerBuilder builder = new CustomerBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.GetCustomer(request);
        }

        /// <summary>
        /// Deletes a customer with the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public CustomerResponse Delete(IDictionary<string, string> parameters)
        {
            CustomerRequest request = base.CreateBaseRequest<CustomerRequest>(ServerType.RecurringPayment, parameters);

            CustomerBuilder builder = new CustomerBuilder(request);
            request.Entity = builder.Entity;

            return this.recurringPaymentService.DeleteCustomer(request);
        }
    }
}

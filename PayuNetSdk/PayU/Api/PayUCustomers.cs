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

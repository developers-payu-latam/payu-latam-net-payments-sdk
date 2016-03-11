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
// <author>Jorge D. Porras</author>using System;

using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.RequestStrategies;
using PayuNetSdk.PayU.Model.Customers;
using PayuNetSdk.PayU.Model;
using PayuNetSdk.PayU.Model.Plans;
using PayuNetSdk.PayU.Model.Subscriptions;
using PayuNetSdk.PayU.RequestStrategies.Customers;
using PayuNetSdk.PayU.RequestStrategies.Plans;
using PayuNetSdk.PayU.RequestStrategies.Subscriptions;
using PayuNetSdk.PayU.Model.RecurringPayments;
using PayuNetSdk.PayU.RequestStrategies.CreditCards;
using PayuNetSdk.PayU.RequestStrategies.RecurringBillItems;
using PayuNetSdk.PayU.Model.RecurringBillItems;
using PayuNetSdk.PayU.Validators;
using PayuNetSdk.PayU.Validators.Base;
using System.Collections.Generic;
namespace PayuNetSdk.PayU.Services
{
    /// <summary>
    ///
    /// </summary>
    internal class RecurringPaymentService : AbstractService
    {

        /////////////////////////////////////////////////////////////////
        ///// Customers operations
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CustomerResponse CreateCustomer(CustomerRequest request)
        {
            AbstractRestRequestStrategy<CustomerRequest, Customer, SdkError> requestStrategy =
                new CreateCustomerStrategy(request);

            requestStrategy.SendRequest();

            CustomerResponse response = new CustomerResponse();
            response.Customer = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CustomerResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Updates the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CustomerResponse UpdateCustomer(CustomerRequest request)
        {
            base.Validate<Customer, CustomerRequest>(request, ValidatorContext.UPDATE);

            AbstractRestRequestStrategy<CustomerRequest, Customer, SdkError> requestStrategy =
                new UpdateCustomerStrategy(request);

            requestStrategy.SendRequest();

            CustomerResponse response = new CustomerResponse();
            response.Customer = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CustomerResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Gets the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CustomerResponse GetCustomer(CustomerRequest request)
        {
            base.Validate<Customer, CustomerRequest>(request, ValidatorContext.GET);

            AbstractRestRequestStrategy<CustomerRequest, Customer, SdkError> requestStrategy =
                new GetCustomerStrategy(request);

            requestStrategy.SendRequest();

            CustomerResponse response = new CustomerResponse();
            response.Customer = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CustomerResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Deletes the customer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CustomerResponse DeleteCustomer(CustomerRequest request)
        {
            base.Validate<Customer, CustomerRequest>(request, ValidatorContext.DELETE);

            AbstractRestRequestWithAlternativeDataStrategy<CustomerRequest, Customer, SdkError, CommonResponse> requestStrategy =
                new DeleteCustomerStrategy(request);

            requestStrategy.SendRequest();

            CustomerResponse response = new CustomerResponse();
            response.Customer = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;
            response.Response = requestStrategy.RestResponse.ExtraData;

            return (CustomerResponse)PrepareComposeResponse(response);
        }

        /////////////////////////////////////////////////////////////////
        ///// Subscription Plans operations
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the SubscriptionPlan.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse CreateSubscriptionPlan(SubscriptionPlanRequest request)
        {
            AbstractRestRequestStrategy<SubscriptionPlanRequest, SubscriptionPlan, SdkError> requestStrategy =
                new CreateSubscriptionPlanStrategy(request);

            requestStrategy.SendRequest();

            SubscriptionPlanResponse response = new SubscriptionPlanResponse();
            response.SubscriptionPlan = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (SubscriptionPlanResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Updates the SubscriptionPlan.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse UpdateSubscriptionPlan(SubscriptionPlanRequest request)
        {
            base.Validate<SubscriptionPlan, SubscriptionPlanRequest>(request, ValidatorContext.UPDATE);

            AbstractRestRequestStrategy<SubscriptionPlanRequest, SubscriptionPlan, SdkError> requestStrategy =
                new UpdateSubscriptionPlanStrategy(request);

            requestStrategy.SendRequest();

            SubscriptionPlanResponse response = new SubscriptionPlanResponse();
            response.SubscriptionPlan = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (SubscriptionPlanResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Gets the SubscriptionPlan.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse GetSubscriptionPlan(SubscriptionPlanRequest request)
        {
            base.Validate<SubscriptionPlan, SubscriptionPlanRequest>(request, ValidatorContext.GET);

            AbstractRestRequestStrategy<SubscriptionPlanRequest, SubscriptionPlan, SdkError> requestStrategy =
                new GetSubscriptionPlanStrategy(request);

            requestStrategy.SendRequest();

            SubscriptionPlanResponse response = new SubscriptionPlanResponse();
            response.SubscriptionPlan = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (SubscriptionPlanResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Deletes the SubscriptionPlan.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SubscriptionPlanResponse DeleteSubscriptionPlan(SubscriptionPlanRequest request)
        {
            base.Validate<SubscriptionPlan, SubscriptionPlanRequest>(request, ValidatorContext.DELETE);

            AbstractRestRequestStrategy<SubscriptionPlanRequest, SubscriptionPlan, SdkError> requestStrategy =
                new DeleteSubscriptionPlanStrategy(request);

            requestStrategy.SendRequest();

            SubscriptionPlanResponse response = new SubscriptionPlanResponse();
            response.SubscriptionPlan = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (SubscriptionPlanResponse)PrepareComposeResponse(response);
        }

        /////////////////////////////////////////////////////////////////
        ///// Subscription operations
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the Subscription.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SubscriptionResponse CreateSubscription(SubscriptionRequest request)
        {
            AbstractRestRequestStrategy<SubscriptionRequest, Subscription, SdkError> requestStrategy =
                new CreateSubscriptionStrategy(request);

            requestStrategy.SendRequest();

            SubscriptionResponse response = new SubscriptionResponse();
            response.Subscription = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (SubscriptionResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Deletes the Subscription.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public SubscriptionResponse DeleteSubscription(SubscriptionRequest request)
        {
            base.Validate<Subscription, SubscriptionRequest>(request, ValidatorContext.DELETE);

            AbstractRestRequestWithAlternativeDataStrategy<SubscriptionRequest, Subscription, SdkError, CommonResponse> requestStrategy =
                new DeleteSubscriptionStrategy(request);

            requestStrategy.SendRequest();

            SubscriptionResponse response = new SubscriptionResponse();
            response.Subscription = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (SubscriptionResponse)PrepareComposeResponse(response);
        }

        /////////////////////////////////////////////////////////////////
        ///// Credit cards operations
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the Credit Card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CreditCardResponse CreateCreditCard(CreditCardRequest request)
        {
            base.Validate<CreditCard, CreditCardRequest>(request, ValidatorContext.CREATE);

            AbstractRestRequestStrategy<CreditCardRequest, CreditCard, SdkError> requestStrategy =
                new CreateCreditCardStrategy(request);

            requestStrategy.SendRequest();

            CreditCardResponse response = new CreditCardResponse();
            response.CreditCard = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CreditCardResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Updates the Credit Card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CreditCardResponse UpdateCreditCard(CreditCardRequest request)
        {
            base.Validate<CreditCard, CreditCardRequest>(request, ValidatorContext.UPDATE);

            AbstractRestRequestStrategy<CreditCardRequest, CreditCard, SdkError> requestStrategy =
                new UpdateCreditCardStrategy(request);

            requestStrategy.SendRequest();

            CreditCardResponse response = new CreditCardResponse();
            response.CreditCard = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CreditCardResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Gets the Credit Card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CreditCardResponse GetCreditCard(CreditCardRequest request)
        {
            base.Validate<CreditCard, CreditCardRequest>(request, ValidatorContext.GET);

            AbstractRestRequestStrategy<CreditCardRequest, CreditCard, SdkError> requestStrategy =
                new GetCreditCardStrategy(request);

            requestStrategy.SendRequest();

            CreditCardResponse response = new CreditCardResponse();
            response.CreditCard = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CreditCardResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Deletes the Credit Card.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public CreditCardResponse DeleteCreditCard(CreditCardRequest request)
        {
            base.Validate<CreditCard, CreditCardRequest>(request, ValidatorContext.DELETE);

            AbstractRestRequestWithAlternativeDataStrategy<CreditCardRequest, CreditCard, SdkError, CommonResponse> requestStrategy =
                new DeleteCreditCardStrategy(request);

            requestStrategy.SendRequest();

            CreditCardResponse response = new CreditCardResponse();
            response.CreditCard = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (CreditCardResponse)PrepareComposeResponse(response);
        }
        /////////////////////////////////////////////////////////////////
        ///// Recurring Bill Item operations
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the Recurring Bill Item.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RecurringBillItemResponse CreateRecurringBillItem(RecurringBillItemRequest request)
        {
            base.Validate<RecurringBillItem, RecurringBillItemRequest>(request, ValidatorContext.CREATE);

            AbstractRestRequestStrategy<RecurringBillItemRequest, RecurringBillItem, SdkError> requestStrategy =
                new CreateRecurringBillItemStrategy(request);

            requestStrategy.SendRequest();

            RecurringBillItemResponse response = new RecurringBillItemResponse();
            response.RecurringBillItem = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (RecurringBillItemResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Updates the Recurring Bill Item.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RecurringBillItemResponse UpdateRecurringBillItem(RecurringBillItemRequest request)
        {
            base.Validate<RecurringBillItem, RecurringBillItemRequest>(request, ValidatorContext.UPDATE);

            AbstractRestRequestStrategy<RecurringBillItemRequest, RecurringBillItem, SdkError> requestStrategy =
                new UpdateRecurringBillItemStrategy(request);

            requestStrategy.SendRequest();

            RecurringBillItemResponse response = new RecurringBillItemResponse();
            response.RecurringBillItem = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (RecurringBillItemResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Gets the Recurring Bill Item.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RecurringBillItemResponse GetRecurringBillItem(RecurringBillItemRequest request)
        {
            base.Validate<RecurringBillItem, RecurringBillItemRequest>(request, ValidatorContext.GET);

            AbstractRestRequestStrategy<RecurringBillItemRequest, RecurringBillItem, SdkError> requestStrategy =
                new GetRecurringBillItemStrategy(request);

            requestStrategy.SendRequest();

            RecurringBillItemResponse response = new RecurringBillItemResponse();
            response.RecurringBillItem = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (RecurringBillItemResponse)PrepareComposeResponse(response);
        }

        /// <summary>
        /// Deletes the Recurring Bill Item.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public RecurringBillItemResponse DeleteRecurringBillItem(RecurringBillItemRequest request)
        {
            base.Validate<RecurringBillItem, RecurringBillItemRequest>(request, ValidatorContext.DELETE);

            AbstractRestRequestWithAlternativeDataStrategy<RecurringBillItemRequest, RecurringBillItem, SdkError, CommonResponse> requestStrategy =
                new DeleteRecurringBillItemStrategy(request);

            requestStrategy.SendRequest();

            RecurringBillItemResponse response = new RecurringBillItemResponse();
            response.RecurringBillItem = requestStrategy.RestResponse.Data;
            response.Error = requestStrategy.RestResponse.Error;

            return (RecurringBillItemResponse)PrepareComposeResponse(response);
        }
    }
}

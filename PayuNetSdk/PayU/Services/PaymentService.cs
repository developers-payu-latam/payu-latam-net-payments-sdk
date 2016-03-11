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

namespace PayuNetSdk.PayU.Services
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.RequestStrategies;

    /// <summary>
    /// Services to process payments.
    /// </summary>
    internal class PaymentService : AbstractService
    {
        /// <summary>
        /// Does the authorization.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoAuthorization(PaymentRequest paymentRequest)
        {
            AbstractPostRequestStrategy<PaymentRequest, PaymentResponse> requestStrategy =
                new SubmitTransactionStrategy(paymentRequest);

            requestStrategy.SendRequest();

            return (PaymentResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }

        /// <summary>
        /// Does the authorization and capture.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoAuthorizationAndCapture(PaymentRequest paymentRequest)
        {
            AbstractPostRequestStrategy<PaymentRequest, PaymentResponse> requestStrategy =
                new SubmitTransactionStrategy(paymentRequest);

            requestStrategy.SendRequest();

            return (PaymentResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }

        /// <summary>
        /// Does the capture.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoCapture(PaymentRequest paymentRequest)
        {
            AbstractPostRequestStrategy<PaymentRequest, PaymentResponse> requestStrategy =
                new SubmitTransactionStrategy(paymentRequest);

            requestStrategy.SendRequest();

            return (PaymentResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }

        /// <summary>
        /// Does the void.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoVoid(PaymentRequest paymentRequest)
        {
            AbstractPostRequestStrategy<PaymentRequest, PaymentResponse> requestStrategy =
                new SubmitTransactionStrategy(paymentRequest);

            requestStrategy.SendRequest();

            return (PaymentResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }

        /// <summary>
        /// Does the refund.
        /// </summary>
        /// <param name="paymentRequest">The payment request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoRefund(PaymentRequest paymentRequest)
        {
            AbstractPostRequestStrategy<PaymentRequest, PaymentResponse> requestStrategy =
                new SubmitTransactionStrategy(paymentRequest);

            requestStrategy.SendRequest();

            return (PaymentResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }

        /// <summary>
        /// Gets the payment methods.
        /// </summary>
        /// <param name="paymentMethodsRequest">The payment methods request.</param>
        /// <returns><see cref="PaymentMethodsResponse"/> instance that contains the operation result.</returns>
        public PaymentMethodsResponse GetPaymentMethods(PaymentMethodsRequest paymentMethodsRequest)
        {
            AbstractPostRequestWithAlternativeDataStrategy<PaymentMethodsRequest, PaymentMethodsResponse, PaymentResponse> requestStrategy =
                new PaymentMethodsStrategy(paymentMethodsRequest);

            requestStrategy.SendRequest();

            return (PaymentMethodsResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }

        /// <summary>
        /// Gets the banks list.
        /// </summary>
        /// <param name="banksRequest">The banks request.</param>
        /// <returns><see cref="BankInfoResponse"/> instance that contains the operation result.</returns>
        public BankInfoResponse GetBanksList(BankInfoRequest banksRequest)
        {
            AbstractPostRequestWithAlternativeDataStrategy<BankInfoRequest, BankInfoResponse, PaymentResponse> requestStrategy =
                new BanksInformationStrategy(banksRequest);

            requestStrategy.SendRequest();

            return (BankInfoResponse)PrepareResponse(requestStrategy.RestResponse.Data);
        }
    }
}

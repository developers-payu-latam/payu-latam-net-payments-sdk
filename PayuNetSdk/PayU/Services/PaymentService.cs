// <copyright file="PaymentService.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
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

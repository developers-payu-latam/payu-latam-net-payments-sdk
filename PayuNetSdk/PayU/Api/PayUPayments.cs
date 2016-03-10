// <copyright file="PayUPayments.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Api
{
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Builders;
    using PayuNetSdk.PayU.Builders.Factories;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Services;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.Resources;
    using System.Globalization;

    /// <summary>
    /// Manages all PAYU payments operations.
    /// </summary>
    public sealed class PayUPayments : PayU
    {
        /// <summary>
        /// PayUPayments instance for singleton pattern.
        /// </summary>
        private static PayUPayments instance; 

        private static object syncLock = new object();

        /// <summary>
        /// The payment service instance.
        /// </summary>
        private PaymentService paymentService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUPayments"/> class from being created.
        /// </summary>
        private PayUPayments() 
        {
            this.paymentService = new PaymentService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUPayments Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUPayments();
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
        /// Does the ping request to payment service.
        /// </summary>
        /// <returns><see cref="PingResponse"/> instance that contains the operation result.</returns>
        public PingResponse DoPing()
        {
            PingRequest request = base.CreateBaseRequest<PingRequest>(ServerType.Payments);
            return this.paymentService.Ping(request);
        }

        /// <summary>
        /// Does authorization request to payment service.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about authorization request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoAuthorization(IDictionary<string, string> parameters)
        {
            PaymentRequest request = base.CreateBaseRequest<PaymentRequest>(ServerType.Payments, parameters);

            AbstractTransactionBuilder builder =
                AuthAndCaptureAuthTransactionBuilderFactory.GetTransactionBuilder(
                    request, TransactionType.AUTHORIZATION);

            request.Transaction = builder.Transaction;

            return this.paymentService.DoAuthorization(request);
        }

        /// <summary>
        /// Does authorization and capture request to payment service.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about authorization and capture request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoAuthorizationAndCapture(IDictionary<string, string> parameters)
        {
            PaymentRequest request = base.CreateBaseRequest<PaymentRequest>(ServerType.Payments, parameters);

            AbstractTransactionBuilder builder = 
                AuthAndCaptureAuthTransactionBuilderFactory.GetTransactionBuilder(
                    request, TransactionType.AUTHORIZATION_AND_CAPTURE);

            request.Transaction = builder.Transaction;

            return this.paymentService.DoAuthorizationAndCapture(request);
        }

        /// <summary>
        /// Does capture request to payment service.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about capture request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoCapture(IDictionary<string, string> parameters)
        {
            PaymentRequest request = base.CreateBaseRequest<PaymentRequest>(ServerType.Payments, parameters);

            AbstractTransactionBuilder builder = new CaptureVoidRefundTransactionBuilder(
                request, TransactionType.CAPTURE);

            request.Transaction = builder.Transaction;

            return this.paymentService.DoCapture(request);
        }

        /// <summary>
        /// Does void request to payment service.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about void request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoVoid(IDictionary<string, string> parameters)
        {
            PaymentRequest request = base.CreateBaseRequest<PaymentRequest>(ServerType.Payments, parameters);

            AbstractTransactionBuilder builder = new CaptureVoidRefundTransactionBuilder(
                request, TransactionType.VOID);

            request.Transaction = builder.Transaction;

            return this.paymentService.DoVoid(request);
        }

        /// <summary>
        /// Does refund request to payment service.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about refund request.</param>
        /// <returns><see cref="PaymentResponse"/> instance that contains the operation result.</returns>
        public PaymentResponse DoRefund(IDictionary<string, string> parameters)
        {
            PaymentRequest request = base.CreateBaseRequest<PaymentRequest>(ServerType.Payments, parameters);

            AbstractTransactionBuilder builder = new CaptureVoidRefundTransactionBuilder(
                request, TransactionType.REFUND);

            request.Transaction = builder.Transaction;

            return this.paymentService.DoRefund(request);
        }

        /// <summary>
        /// Gets the payment methods.
        /// </summary>
        /// <returns><see cref="PaymentMethodsResponse"/> instance that contains the operation result.</returns>
        public PaymentMethodsResponse GetPaymentMethods() 
        { 
            PaymentMethodsRequest request = base.CreateBaseRequest<PaymentMethodsRequest>(ServerType.Payments);

            return this.paymentService.GetPaymentMethods(request);
        }

        /// <summary>
        /// Gets the pse banks.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about PseBankInfo request.</param>
        /// <returns><see cref="BankInfoResponse"/> instance that contains the operation result.</returns>
        public BankInfoResponse GetPseBanks(IDictionary<string, string> parameters)
        {
            BankInfoRequest request = base.CreateBaseRequest<BankInfoRequest>(ServerType.Payments, parameters);

            BanksInformationBuilder builder = new BanksInformationBuilder(request);
            request.BankListInformation = builder.BankListInformation;

            return this.paymentService.GetBanksList(request);
        }
    }
}

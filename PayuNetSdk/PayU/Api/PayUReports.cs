// <copyright file="PayUReports.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Api
{
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Builders;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Services;
    using PayuNetSdk.PayU.Messages.Enums;

    /// <summary>
    /// Manages all PAYU reports operations.
    /// </summary>
    public sealed class PayUReports : PayU
    {
        /// <summary>
        /// PayUReports instance for singleton pattern.
        /// </summary>
        private static PayUReports instance;

        private static object syncLock = new object();

        /// <summary>
        /// The report service instance.
        /// </summary>
        private ReportService reportService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUReports"/> class from being created.
        /// </summary>
        private PayUReports()
        {
            reportService = new ReportService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUReports Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUReports();
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
        /// Does the ping request to report service.
        /// </summary>
        /// <returns><see cref="PingResponse"/> instance that contains the operation result.</returns>
        public PingReportResponse DoPing()
        {
            PingRequest request = base.CreateBaseRequest<PingRequest>(ServerType.Reports);
            return reportService.Ping(request);
        }

        /// <summary>
        /// Gets the order detail.
        /// </summary>
        /// <param name="parameters">The parameters that contains information 
        /// about order detail request.</param>
        /// <returns><see cref="OrderReportResponse"/> instance that contains the operation result.</returns>
        public OrderReportResponse GetOrderDetail(IDictionary<string, string> parameters)
        {
            OrderReportRequest request = base.CreateBaseRequest<OrderReportRequest>(ServerType.Reports, parameters);

            ReportDetailsBuilder builder = new ReportDetailsBuilder(request);
            request.Details = builder.Details;

            return reportService.GetOrderDetail(request);
        }

        /// <summary>
        /// Gets the order detail by reference code.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public OrderReportListResponse GetOrderDetailByReferenceCode(IDictionary<string, string> parameters)
        {
             OrderReportRequest request = base.CreateBaseRequest<OrderReportRequest>(ServerType.Reports, parameters);

            ReportDetailsBuilder builder = new ReportDetailsBuilder(request);
            request.Details = builder.Details;

            return reportService.GetOrderDetailByReferenceCode(request);
        }

        /// <summary>
        /// Gets the transaction response.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public TransactionReportResponse GetTransactionResponse(IDictionary<string, string> parameters)
        {
            TransactionReportRequest request = base.CreateBaseRequest<TransactionReportRequest>(ServerType.Reports, parameters);

            ReportDetailsBuilder builder = new ReportDetailsBuilder(request);
            request.Details = builder.Details;

            return reportService.GetTransactionResponse(request);
        }
    }
}

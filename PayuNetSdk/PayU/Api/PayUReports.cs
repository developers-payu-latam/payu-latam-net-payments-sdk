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

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
    /// Services to query data.
    /// </summary>
    internal class ReportService : AbstractService
    {
        /// <summary>
        /// Pings the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><see cref="PingResponse"/> instance that contains the operation result.</returns>
        public new PingReportResponse Ping(PingRequest request)
        {
            PingReportResponse response = new PingReportResponse();

            AbstractPostRequestStrategy<PingRequest, PingReportResponse> requestStrategy =
                new PingReportRequestStrategy(request);

            requestStrategy.SendRequest();
            response = requestStrategy.RestResponse.Data;

            return response;
        }

        /// <summary>
        /// Gets the order detail.
        /// </summary>
        /// <param name="reportRequest">The report request.</param>
        /// <returns><see cref="OrderReportResponse"/> instance that contains the operation result.</returns>
        public OrderReportResponse GetOrderDetail(OrderReportRequest reportRequest)
        {
            AbstractPostRequestStrategy<OrderReportRequest, OrderReportResponse> requestStrategy =
                new OrderDetailReportStrategy(reportRequest);

            requestStrategy.SendRequest();

            return requestStrategy.RestResponse.Data;
        }

        /// <summary>
        /// Gets the order detail by reference code.
        /// </summary>
        /// <param name="reportRequest">The report request.</param>
        /// <returns></returns>
        public OrderReportListResponse GetOrderDetailByReferenceCode(OrderReportRequest reportRequest)
        {
            AbstractPostRequestStrategy<OrderReportRequest, OrderReportListResponse> requestStrategy =
                new OrderDetailByReferenceCodeStrategy(reportRequest);

            requestStrategy.SendRequest();

            return requestStrategy.RestResponse.Data;
        }

        /// <summary>
        /// Gets the transaction response.
        /// </summary>
        /// <param name="reportRequest">The report request.</param>
        /// <returns></returns>
        public TransactionReportResponse GetTransactionResponse(TransactionReportRequest reportRequest)
        {
            AbstractPostRequestStrategy<TransactionReportRequest, TransactionReportResponse> requestStrategy =
                new TransactionDetailReportStrategy(reportRequest);

            requestStrategy.SendRequest();

            return requestStrategy.RestResponse.Data;
        }
    }
}

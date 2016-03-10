// <copyright file="ReportService.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
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

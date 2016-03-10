// <copyright file="OrderDetailByReferenceCodeStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;

    /// <summary>
    /// Strategy for generate POST Order detail information request.
    /// </summary>
    internal class OrderDetailByReferenceCodeStrategy :
        AbstractPostRequestStrategy<OrderReportRequest, OrderReportListResponse>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailReportStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public OrderDetailByReferenceCodeStrategy(OrderReportRequest request)
            : base(request)
        {
            request.Command = Command.ORDER_DETAIL_BY_REFERENCE_CODE;
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest(Method.POST);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<OrderReportListResponse> CreateResponse()
        {
            IRestResponse<OrderReportListResponse> response = new RestResponse<OrderReportListResponse>();
            return response;
        }
    }
}

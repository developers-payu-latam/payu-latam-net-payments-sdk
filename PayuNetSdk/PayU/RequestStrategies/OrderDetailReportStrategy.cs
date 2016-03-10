// <copyright file="OrderDetailReportStrategy.cs" company="PayU Latam">
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
    internal class OrderDetailReportStrategy : 
        AbstractPostRequestStrategy<OrderReportRequest, OrderReportResponse>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailReportStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public OrderDetailReportStrategy(OrderReportRequest request)
            : base(request)
        {
            request.Command = Command.ORDER_DETAIL;
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
        public override IRestResponse<OrderReportResponse> CreateResponse()
        {
            IRestResponse<OrderReportResponse> response = new RestResponse<OrderReportResponse>();
            return response;
        }
    }
}

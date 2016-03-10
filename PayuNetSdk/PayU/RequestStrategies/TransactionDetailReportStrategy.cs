// <copyright file="TransactionDetailReportStrategy.cs" company="PayU Latam">
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
    internal class TransactionDetailReportStrategy : 
        AbstractPostRequestStrategy<TransactionReportRequest, TransactionReportResponse>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionDetailReportStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public TransactionDetailReportStrategy(TransactionReportRequest request)
            : base(request)
        {
            request.Command = Command.TRANSACTION_RESPONSE_DETAIL;
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
        public override IRestResponse<TransactionReportResponse> CreateResponse()
        {
            IRestResponse<TransactionReportResponse> response = new RestResponse<TransactionReportResponse>();
            return response;
        }
    }
}

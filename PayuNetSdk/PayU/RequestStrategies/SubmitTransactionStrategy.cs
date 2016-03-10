// <copyright file="SubmitTransactionStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;

    /// <summary>
    /// Strategy for generate POST payment request. 
    /// </summary>
    internal class SubmitTransactionStrategy : 
        AbstractPostRequestStrategy<PaymentRequest, PaymentResponse>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SubmitTransactionStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public SubmitTransactionStrategy(PaymentRequest request)
            : base(request)
        {
            request.Command = Command.SUBMIT_TRANSACTION;
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
        public override IRestResponse<PaymentResponse> CreateResponse()
        {
            IRestResponse<PaymentResponse> response = new RestResponse<PaymentResponse>();
            return response;
        }
    }
}

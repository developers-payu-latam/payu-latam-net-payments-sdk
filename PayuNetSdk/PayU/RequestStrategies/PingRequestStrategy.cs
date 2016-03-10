// <copyright file="PingRequestStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;

    /// <summary>
    /// Strategy for generate POST ping request. 
    /// </summary>
    internal class PingRequestStrategy :
        AbstractPostRequestStrategy<PingRequest, PingResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PingRequestStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public PingRequestStrategy(PingRequest request)
            : base(request)
        {
            request.Command = Command.PING;
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
        public override IRestResponse<PingResponse> CreateResponse()
        {
            return new RestResponse<PingResponse>();
        }
    }
}

// <copyright file="GetTokenRequestStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    internal class GetTokenRequestStrategy :
        AbstractPostRequestWithAlternativeDataStrategy<TokenRequest, TokenInfoResponse, PaymentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTokenRequestStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public GetTokenRequestStrategy(TokenRequest request)
            : base(request)
        {
            request.Command = Command.GET_TOKENS;
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
        public override IRestResponse<TokenInfoResponse, PaymentResponse> CreateResponse()
        {
            IRestResponse<TokenInfoResponse, PaymentResponse> response = new RestResponse<TokenInfoResponse, PaymentResponse>();
            return response;
        }
    }
}

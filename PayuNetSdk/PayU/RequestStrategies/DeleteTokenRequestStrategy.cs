// <copyright file="TokenRequestStrategy.cs" company="PayU Latam">
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
    internal class DeleteTokenRequestStrategy :
        AbstractPostRequestWithAlternativeDataStrategy<TokenRequest, TokenResponse, PaymentResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTokenRequestStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public DeleteTokenRequestStrategy(TokenRequest request)
            : base(request)
        {
            request.Command = Command.REMOVE_TOKEN;
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
        public override IRestResponse<TokenResponse, PaymentResponse> CreateResponse()
        {
            IRestResponse<TokenResponse, PaymentResponse> response = new RestResponse<TokenResponse, PaymentResponse>();
            return response;
        }
    }
}

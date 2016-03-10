// <copyright file="BanksInformationStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;

    /// <summary>
    /// Strategy for generate POST Banks information request.
    /// </summary>
    internal class BanksInformationStrategy :
        AbstractPostRequestWithAlternativeDataStrategy<BankInfoRequest, BankInfoResponse, PaymentResponse>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BanksInformationStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public BanksInformationStrategy(BankInfoRequest request)
            : base(request)
        {
            request.Command = Command.GET_BANKS_LIST;
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
        public override IRestResponse<BankInfoResponse, PaymentResponse> CreateResponse()
        {
            IRestResponse<BankInfoResponse, PaymentResponse> response = new RestResponse<BankInfoResponse, PaymentResponse>();
            return response;
        }
    }
}

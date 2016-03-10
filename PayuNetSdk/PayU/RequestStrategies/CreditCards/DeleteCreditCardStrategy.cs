// <copyright file="DeleteCreditCardStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies.CreditCards
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    internal class DeleteCreditCardStrategy :
        AbstractRestRequestWithAlternativeDataStrategy<CreditCardRequest, CreditCard, SdkError, CommonResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCreditCardStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public DeleteCreditCardStrategy(CreditCardRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("customers/{customerId}/creditCards/{token}", Method.DELETE);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<CreditCard, SdkError, CommonResponse> CreateResponse()
        {
            IRestResponse<CreditCard, SdkError, CommonResponse> response = new RestResponse<CreditCard, SdkError, CommonResponse>();
            return response;
        }

        /// <summary>
        /// Sets the URL segment.
        /// </summary>
        public override void SetUrlSegment()
        {
            base.AddUrlSegment("token", base.Entity.Token);
            base.AddUrlSegment("customerId", base.Entity.CustomerId);
        }
    }
}

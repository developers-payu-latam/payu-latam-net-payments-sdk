// <copyright file="UpdateCreditCardStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies.CreditCards
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Model;
using PayuNetSdk.PayU.Model.RecurringPayments;

    /// <summary>
    /// 
    /// </summary>
    internal class UpdateCreditCardStrategy :
        AbstractRestRequestStrategy<CreditCardRequest, CreditCard, SdkError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCreditCardStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public UpdateCreditCardStrategy(CreditCardRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("creditCards/{token}", Method.PUT);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<CreditCard, SdkError> CreateResponse()
        {
            IRestResponse<CreditCard, SdkError> response = new RestResponse<CreditCard, SdkError>();
            return response;
        }

        /// <summary>
        /// Sets the URL segment.
        /// </summary>
        public override void SetUrlSegment()
        {
            base.AddUrlSegment("token", base.Entity.Token);
        }
    }
}

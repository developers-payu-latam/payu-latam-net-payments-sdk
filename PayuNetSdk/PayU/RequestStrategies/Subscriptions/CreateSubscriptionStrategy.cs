// <copyright file="CreateSusbcriptionStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies.Subscriptions
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Model;
    using RestSharp;
    using PayuNetSdk.PayU.Model.Subscriptions;

    /// <summary>
    /// 
    /// </summary>
    internal class CreateSubscriptionStrategy :
        AbstractRestRequestStrategy<SubscriptionRequest, Subscription, SdkError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateSubscriptionStrategy(SubscriptionRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("subscriptions", Method.POST);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<Subscription, SdkError> CreateResponse()
        {
            IRestResponse<Subscription, SdkError> response = new RestResponse<Subscription, SdkError>();
            return response;
        }

        /// <summary>
        /// Sets the URL segment.
        /// </summary>
        public override void SetUrlSegment() 
        { 
            // Do Nothing
        }
    }
}

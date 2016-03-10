// <copyright file="GetSusbcriptionPlanStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies.Plans
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Model;
    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    internal class GetSubscriptionPlanStrategy :
        AbstractRestRequestStrategy<SubscriptionPlanRequest, SubscriptionPlan, SdkError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionPlanStrategy "/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public GetSubscriptionPlanStrategy(SubscriptionPlanRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("plans/{planCode}", Method.GET);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<SubscriptionPlan, SdkError> CreateResponse()
        {
            IRestResponse<SubscriptionPlan, SdkError> response = new RestResponse<SubscriptionPlan, SdkError>();
            return response;
        }

        /// <summary>
        /// Sets the URL segment.
        /// </summary>
        public override void SetUrlSegment()
        {
            base.AddUrlSegment("planCode", base.Entity.PlanCode);
        }
    }
}

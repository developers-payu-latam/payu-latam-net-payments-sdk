// <copyright file="CreateRecurringBillItemStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies.RecurringBillItems
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model;
    using PayuNetSdk.PayU.Model.RecurringBillItems;
    using RestSharp;

    /// <summary>
    /// 
    /// </summary>
    internal class CreateRecurringBillItemStrategy :
        AbstractRestRequestStrategy<RecurringBillItemRequest, RecurringBillItem, SdkError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRecurringBillItemStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateRecurringBillItemStrategy(RecurringBillItemRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("subscriptions/{subscriptionId}/recurringBillItems", Method.POST);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<RecurringBillItem, SdkError> CreateResponse()
        {
            IRestResponse<RecurringBillItem, SdkError> response = new RestResponse<RecurringBillItem, SdkError>();
            return response;
        }

        /// <summary>
        /// Sets the URL segment.
        /// </summary>
        public override void SetUrlSegment() 
        {
            base.AddUrlSegment("subscriptionId", base.Entity.SubscriptionId); 
        }
    }
}

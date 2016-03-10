// <copyright file="DeleteRecurringBillItemStrategy.cs" company="PayU Latam">
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
    internal class DeleteRecurringBillItemStrategy :
        AbstractRestRequestWithAlternativeDataStrategy<RecurringBillItemRequest, RecurringBillItem, SdkError, CommonResponse>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRecurringBillItemStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public DeleteRecurringBillItemStrategy(RecurringBillItemRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("recurringBillItems/{id}", Method.DELETE);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<RecurringBillItem, SdkError, CommonResponse> CreateResponse()
        {
            IRestResponse<RecurringBillItem, SdkError, CommonResponse> response = new RestResponse<RecurringBillItem, SdkError, CommonResponse>();
            return response;
        }

        /// <summary>
        /// Sets the URL segment.
        /// </summary>
        public override void SetUrlSegment()
        {
            base.AddUrlSegment("id", base.Entity.Id);
        }
    }
}

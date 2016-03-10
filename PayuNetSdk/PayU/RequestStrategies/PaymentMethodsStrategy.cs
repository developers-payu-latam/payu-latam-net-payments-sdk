// <copyright file="PaymentMethodsStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;

    /// <summary>
    /// Strategy for generate POST payment method information request.
    /// </summary>
    internal class PaymentMethodsStrategy :
        AbstractPostRequestWithAlternativeDataStrategy<PaymentMethodsRequest, PaymentMethodsResponse, PaymentResponse>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentMethodsStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public PaymentMethodsStrategy(PaymentMethodsRequest request)
            : base(request)
        {
            request.Command = Command.GET_PAYMENT_METHODS;
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
        public override IRestResponse<PaymentMethodsResponse, PaymentResponse> CreateResponse()
        {
            IRestResponse<PaymentMethodsResponse, PaymentResponse> response = new RestResponse<PaymentMethodsResponse, PaymentResponse>();
            return response;
        }
    }
}

// <copyright file="CreateCustomerStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies.Customers
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using RestSharp;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Model;

    /// <summary>
    /// 
    /// </summary>
    internal class CreateCustomerStrategy :
        AbstractRestRequestStrategy<CustomerRequest, Customer, SdkError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCustomerStrategy"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CreateCustomerStrategy(CustomerRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public override IRestRequest CreateRequest()
        {
            return new RestRequest("customers", Method.POST);
        }

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public override IRestResponse<Customer, SdkError> CreateResponse()
        {
            IRestResponse<Customer, SdkError> response = new RestResponse<Customer, SdkError>();
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

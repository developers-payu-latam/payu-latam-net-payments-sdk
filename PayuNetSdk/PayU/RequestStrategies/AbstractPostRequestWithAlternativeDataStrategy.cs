// <copyright file="AbstractPostRequestStrategy.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.RequestStrategies
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Security;
    using PayuNetSdk.PayU.Services;
    using RestSharp;
    using RestSharp.Serializers;

    /// <summary>
    /// Strategy for generate POST request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V"></typeparam>
    internal abstract class AbstractPostRequestWithAlternativeDataStrategy<T, V, E>
        where T : AbstractRequest where V : new() where E : new()
    {

        private IRestRequest restRequest;
        private IRestResponse<V, E> restResponse;
        private IRestClient restClient;
        private T request;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractPostRequestStrategy{T, V}"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AbstractPostRequestWithAlternativeDataStrategy(T request)
        {
            ServerCertificateValidation.ValidateServerCertificate();
            this.request = request;
            restClient = new RestClient(request.Url);
        }

        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>
        /// The rest response.
        /// </value>
        public IRestResponse<V, E> RestResponse
        {
            get { return restResponse; }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        public void SendRequest()
        {
            SetRequest();
            SetResponse();
            SetObject();
            Execute();
            ValidateResponse();
        }

        /// <summary>
        /// Sets the header.
        /// </summary>
        public virtual void SetHeader()
        {
            restRequest.AddHeader("Accept", "application/xml");
        }

        /// <summary>
        /// Sets the serializer parameters.
        /// </summary>
        public virtual void SetSerializer() {

            restRequest.RequestFormat = DataFormat.Xml;
            restRequest.XmlSerializer = new DotNetXmlSerializer();
            restRequest.XmlSerializer.ContentType = "application/xml; charset=utf-8";
            restRequest.XmlSerializer.RootElement = "request";
        }

        /// <summary>
        /// Configures the client HTTP.
        /// </summary>
        public virtual void ConfigureClient() {

            restClient.AddDefaultHeader("Content-Type", "application/xml; charset=utf-8");
            restClient.AddDefaultHeader("Accept", "application/xml");
            //restClient.Authenticator = new HttpBasicAuthenticator(request.Merchant.ApiKey, request.Merchant.ApiLogin);
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <returns><see cref="IRestRequest"/> instance that contains the request.</returns>
        public abstract IRestRequest CreateRequest();

        /// <summary>
        /// Creates the response.
        /// </summary>
        /// <returns><see cref="IRestResponse"/> instance that contains the response.</returns>
        public abstract IRestResponse<V, E> CreateResponse();

        /// <summary>
        /// Sets the request.
        /// </summary>
        private void SetRequest()
        {
            restRequest = CreateRequest();
            SetHeader();
            SetSerializer();
        }

        /// <summary>
        /// Sets the response.
        /// </summary>
        private void SetResponse()
        {
            restResponse = CreateResponse();
        }

        /// <summary>
        /// Sets the object to request.
        /// </summary>
        private void SetObject()
        {
            restRequest.AddBody(request);
        }

        /// <summary>
        /// Executes the request.
        /// </summary>
        private void Execute()
        {
            restResponse = restClient.Execute<V, E>(restRequest);
        }

        /// <summary>
        /// Validates the response.
        /// </summary>
        private void ValidateResponse()
        {
            restResponse.ValidateResponse();
        }
    }
}

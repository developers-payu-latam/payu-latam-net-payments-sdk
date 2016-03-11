// The MIT License (MIT)
//
// Copyright (c) 2016 PayU Latam
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Services
{
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Linq;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.RequestStrategies;
    using PayuNetSdk.Resources;
    using RestSharp;
    using PayuNetSdk.PayU.Exceptions;
    using System.Net;
    using System.Xml;
    using PayuNetSdk.PayU.Model;
using PayuNetSdk.PayU.Validators.Base;
    using PayuNetSdk.PayU.Model.Customers;

    /// <summary>
    ///
    /// </summary>
    public static class RestResponseExtensionsUtils
    {

        /// <summary>
        /// Validates the response.
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <typeparam name="C"></typeparam>
        /// <param name="restResponse">The rest response.</param>
        /// <exception cref="PayUException"></exception>
        public static void ValidateResponse<V, E, C>(this IRestResponse<V, E, C> restResponse)
        {
            if (restResponse.Error != null)
            {
                if (restResponse.Error is SdkError)
                {
                    SdkError sdkError = restResponse.Error as SdkError;
                    RestResponseExtensionsUtils.FormatSdkError(sdkError);
                }
            }

            RestResponseExtensionsUtils.ValidateResponseCommon(restResponse);
        }

        /// <summary>
        /// Validates the response.
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="restResponse">The rest response.</param>
        public static void ValidateResponse<V, E>(this IRestResponse<V, E> restResponse)
        {
            if (restResponse.Error != null)
            {
                if (restResponse.Error is SdkError)
                {
                    SdkError sdkError = restResponse.Error as SdkError;
                    RestResponseExtensionsUtils.FormatSdkError(sdkError);
                }
                if (restResponse.Error is PaymentResponse)
                {
                    PaymentResponse paymentResponse = restResponse.Error as PaymentResponse;

                    throw new PayUException(ErrorCode.INVALID_PARAMETERS,
                        string.Format("{0} {1} {2}", paymentResponse.ResponseCode, paymentResponse.Error, paymentResponse.MessageError));
                }
            }

            RestResponseExtensionsUtils.ValidateResponseCommon(restResponse);
        }

        /// <summary>
        /// Validates the response.
        /// </summary>
        /// <param name="restResponse">The rest response.</param>
        /// <exception cref="PayUException">
        /// </exception>
        public static void ValidateResponse(this IRestResponse restResponse)
        {
            RestResponseExtensionsUtils.ValidateResponseCommon(restResponse);
        }

        /// <summary>
        /// Formats the SDK error.
        /// </summary>
        /// <param name="sdkError">The SDK error.</param>
        /// <exception cref="PayUException"></exception>
        private static void FormatSdkError(SdkError sdkError)
        {
            StringBuilder errorList = new StringBuilder() ;
            if (sdkError.ErrorList != null && sdkError.ErrorList.Count > 0)
            {
                foreach (string error in sdkError.ErrorList)
                {
                    errorList.AppendLine(error);
                }
            }

            throw new PayUException(ErrorCode.INVALID_PARAMETERS,
                string.Format(PayUSdkMessages.FormatErrorSdkException, sdkError.ErrorType,
                sdkError.Description, errorList));
        }

        /// <summary>
        /// Validates the response common.
        /// </summary>
        /// <param name="restResponse">The rest response.</param>
        /// <exception cref="PayUException">
        /// </exception>
        private static void ValidateResponseCommon(this IRestResponse restResponse)
        {
            if (restResponse.StatusCode.Equals(HttpStatusCode.NotFound))
            {
                throw new PayUException(ErrorCode.CONNECTION_EXCEPTION, restResponse.StatusCode.ToString());
            }

            switch (restResponse.ResponseStatus)
            {
                case ResponseStatus.Error:
                    if (restResponse.ErrorException is WebException)
                    {
                        throw new PayUException(ErrorCode.CONNECTION_EXCEPTION, restResponse.ErrorMessage);
                    }
                    if (restResponse.ErrorException is XmlException)
                    {
                        throw new PayUException(ErrorCode.XML_DESERIALIZATION_ERROR);
                    }
                    throw new PayUException(ErrorCode.API_ERROR, restResponse.ErrorMessage);
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Base class for invoke PAYU Service.
    /// </summary>
    internal abstract class AbstractService
    {
        private static Regex extractNullPropertyRegex = new Regex(@"property:\s*(.*)[,]{1}\s*\w*message:\s*(.*)");
        //...

        /// <summary>
        /// Extractor message
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        private delegate string MessageExtractor(Match match);

        /// <summary>
        /// Pings the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><see cref="PingResponse"/> instance that contains the operation result.</returns>
        public virtual PingResponse Ping(PingRequest request)
        {
            PingResponse response = new PingResponse();

            AbstractPostRequestStrategy<PingRequest, PingResponse> requestStrategy =
                new PingRequestStrategy(request);

            requestStrategy.SendRequest();
            response = requestStrategy.RestResponse.Data;

            return response;
        }

        /// <summary>
        /// Wraps the error.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="REQUEST">The type of the equest.</typeparam>
        /// <typeparam name="RESPONSE">The type of the esponse.</typeparam>
        /// <param name="request">The request.</param>
        /// <param name="response">The response.</param>
        /// <param name="context">The context.</param>
        /// <exception cref="PayUException"></exception>
        /*protected AbstractResponse WrapError<REQUEST, RESPONSE>(
            AbstractPostRequestStrategy<REQUEST, RESPONSE> requestStrategy)
            where RESPONSE : AbstractResponse
        {
            requestStrategy.SendRequest();
            RESPONSE response = requestStrategy.RestResponse.Data;

            response

            return null;
        }*/


        public void Validate<T, REQUEST>(REQUEST request, ValidatorContext context)
            where REQUEST : AbstractRequest<T>
            where T : IValidatable<T>
        {
            IEnumerable<string> brokenRules;
            if (!request.Entity.Validate<T>(out brokenRules, context))
            {
                StringBuilder msg = new StringBuilder();
                foreach (var brokeRule in brokenRules)
                {
                    msg.AppendLine(brokeRule);
                }

                throw new PayUException(ErrorCode.INVALID_PARAMETERS, FormatErrorMessage(msg.ToString()));
            }
        }

        public AbstractResponse PrepareResponse(AbstractResponse response)
        {
            response.MessageError = response.MessageError != null ? FormatErrorMessage(response.MessageError) : null;
            return response;
        }

        public AbstractResponse PrepareComposeResponse(AbstractResponse response)
        {
            response.MessageError = response.Error != null ? FormatErrorMessage(response.Error.Description) : null;
            response.ResponseCode = response.Error != null ? ResponseCode.ERROR : ResponseCode.SUCCESS;
            return response;
        }

        /// <summary>
        /// Formats the error message.
        /// </summary>
        /// <param name="originalError">The original error.</param>
        /// <returns></returns>
        private string FormatErrorMessage(string originalError)
        {
            if (!string.IsNullOrEmpty(originalError))
            {
                StringBuilder msg = new StringBuilder(originalError);
                while (IsThereDirtyMessages(extractNullPropertyRegex, msg.ToString()))
                {
                    CleanDirtyMessage(extractNullPropertyRegex, msg, MessageForNullProperty);
                }
                // ...
                return msg.ToString();
            }
            return null;
        }

        /// <summary>
        /// Extracts the message.
        /// </summary>
        /// <param name="regex">The regex.</param>
        /// <param name="input">The input.</param>
        /// <param name="extractor">The extractor.</param>
        /// <returns></returns>
        private static StringBuilder CleanDirtyMessage(Regex regex, StringBuilder input, MessageExtractor extractor)
        {
            Match match = regex.Match(input.ToString());
            return match.Success ?
                input.Replace(match.Groups[0].Value, extractor.Invoke(match)) :
                input;
        }

        private static bool IsThereDirtyMessages(Regex regex, string input)
        {
            Match match = regex.Match(input);
            return match.Success;
        }

        /// <summary>
        /// Messages for null property.
        /// </summary>
        /// <param name="match">The match.</param>
        /// <returns></returns>
        private string MessageForNullProperty(Match match)
        {
            return string.Format(PayUSdkMessages.PropertyErrorFromApi, match.Groups[1], match.Groups[2]);
        }
    }
}

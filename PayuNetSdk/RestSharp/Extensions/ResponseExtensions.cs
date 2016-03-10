using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestSharp.Extensions
{
	public static class ResponseExtensions
	{
		public static IRestResponse<T> toAsyncResponse<T>(this IRestResponse response)
		{
			return new RestResponse<T>
			{
				ContentEncoding = response.ContentEncoding,
				ContentLength = response.ContentLength,
				ContentType = response.ContentType,
				Cookies = response.Cookies,
				ErrorMessage = response.ErrorMessage,
				Headers = response.Headers,
				RawBytes = response.RawBytes,
				ResponseStatus = response.ResponseStatus,
				ResponseUri = response.ResponseUri,
				Server = response.Server,
				StatusCode = response.StatusCode,
				StatusDescription = response.StatusDescription
			};
		}

        public static IRestResponse<T, E> toAsyncResponse<T, E>(this IRestResponse response)
        {
            return new RestResponse<T, E>
            {
                ContentEncoding = response.ContentEncoding,
                ContentLength = response.ContentLength,
                ContentType = response.ContentType,
                Cookies = response.Cookies,
                ErrorMessage = response.ErrorMessage,
                Headers = response.Headers,
                RawBytes = response.RawBytes,
                ResponseStatus = response.ResponseStatus,
                ResponseUri = response.ResponseUri,
                Server = response.Server,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription
            };
        }

        public static IRestResponse<T, E, C> toAsyncResponse<T, E, C>(this IRestResponse response)
        {
            return new RestResponse<T, E, C>
            {
                ContentEncoding = response.ContentEncoding,
                ContentLength = response.ContentLength,
                ContentType = response.ContentType,
                Cookies = response.Cookies,
                ErrorMessage = response.ErrorMessage,
                Headers = response.Headers,
                RawBytes = response.RawBytes,
                ResponseStatus = response.ResponseStatus,
                ResponseUri = response.ResponseUri,
                Server = response.Server,
                StatusCode = response.StatusCode,
                StatusDescription = response.StatusDescription
            };
        }
	}
}

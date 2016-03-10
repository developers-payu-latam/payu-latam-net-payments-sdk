// <copyright file="ErrorType.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    public enum ErrorType
    {
        /// <summary>
        /// Bad request: The request can not be parsed (Malformed request).
        /// </summary>
        MALFORMED_REQUEST,

        /// <summary>
        /// Not found: If the requested content was not found on the 
        /// server or there is no controller able to process the requested URI.
        /// </summary>
        NOT_FOUND,

        /// <summary>
        /// Bad request: Errors arise when the client request has invalid parameters.
        /// </summary>
        BAD_REQUEST,

        /// <summary>
        /// Internal server error: Any type of error that is not included in the previous types
        /// </summary>
        INTERNAL_SERVER_ERROR,

        /// <summary>
        /// Authorization Error
        /// </summary>
        UNAUTHORIZED
    }
}

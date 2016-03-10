// <copyright file="ErrorCode.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    public enum ErrorCode
    {
        /// <summary>
        /// Error associated to a problem serializing an object.
        /// </summary>
        XML_SERIALIZATION_ERROR,

        /// <summary>
        /// Error associated to a problem deserializing an object.
        /// </summary>
        XML_DESERIALIZATION_ERROR,

        /// <summary>
        /// Error associated to an invalid parameter sent.
        /// </summary>
        INVALID_PARAMETERS,

        /// <summary>
        /// Error associated to a connection problem with the server.
        /// </summary>
        CONNECTION_EXCEPTION,

        /// <summary>
        /// Error associated to an internal API error.
        /// </summary>
        API_ERROR
    }
}

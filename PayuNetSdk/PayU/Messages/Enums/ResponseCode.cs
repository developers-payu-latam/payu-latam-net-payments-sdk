// <copyright file="ResponseCode.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a response code in the PayU SDK.
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Internal purpose. DON'T USE.
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// Success response code
        /// </summary>
        SUCCESS,

        /// <summary>
        ///  Error response core
        /// </summary>
        ERROR
    }
}

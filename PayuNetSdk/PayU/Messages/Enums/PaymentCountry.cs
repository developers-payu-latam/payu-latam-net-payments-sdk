// <copyright file="PaymentCountry.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a payment country in the PayU SDK. Sometimes when a payment
    /// method is processed by several countries is necessary to specify the country
    /// due currency issues.
    /// </summary>
    public enum PaymentCountry
    {
        /// <summary>
        /// Argentina
        /// </summary>
        AR,

        /// <summary>
        /// Brazil
        /// </summary>
        BR,

        /// <summary>
        /// Chile
        /// </summary>
        CL,

        /// <summary>
        /// Colombia
        /// </summary>
        CO,

        /// <summary>
        /// Mexico
        /// </summary>
        MX,

        /// <summary>
        /// Panama
        /// </summary>
        PA,

        /// <summary>
        /// Peru
        /// </summary>
        PE,

        /// <summary>
        /// United States
        /// </summary>
        US
    }
}

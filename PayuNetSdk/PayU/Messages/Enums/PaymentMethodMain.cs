// <copyright file="PaymentMethodMain.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a payment method main in the PayU SDK.
    /// </summary>
    public enum PaymentMethodMain
    {
        /// <summary>
        /// When the payment method is American Express.
        /// </summary>
        AMEX,

        /// <summary>
        /// When the payment method is via Baloto.
        /// </summary>
        BALOTO,
        
        /// <summary>
        /// When the payment method is a bank reference.
        /// </summary>
        BANK_REFERENCED,
        
        /// <summary>
        /// When the payment method is Bapro.
        /// </summary>
        BAPRO,

        /// <summary>
        /// When the payment method is bcp.
        /// </summary>
        BCP,

        /// <summary>
        /// When the payment method is a boleto bancario.
        /// </summary>
        BOLETO_BANCARIO,
        
        /// <summary>
        /// When the payment method is an express charge.
        /// </summary>
        COBRO_EXPRESS,

        /// <summary>
        /// When the payment method is Diners.
        /// </summary>
        DINERS,

        /// <summary>
        /// When the payment method is Discover.
        /// </summary>
        DISCOVER,

        /// <summary>
        /// When the payment method is ELO.
        /// </summary>
        ELO,

        /// <summary>
        /// When the payment method is MasterCard. 
        /// </summary>
        MASTERCARD,

        /// <summary>
        /// When the payment method is OXXO. 
        /// </summary>
        OXXO,

        /// <summary>
        /// When the payment method is via PagoFacil.
        /// </summary>
        PAGOFACIL,

        /// <summary>
        /// When the payment method is via RapiPago.
        /// </summary>
        RAPIPAGO,

        /// <summary>
        /// When the payment method is via PSE.
        /// </summary>
        PSE,

        /// <summary>
        /// When the payment method is via ServiPag.
        /// </summary>
        SERVIPAG,

        /// <summary>
        /// When the payment method is via Seven Eleven.
        /// </summary>
        SEVEN_ELEVEN,

        /// <summary>
        /// When the payment method is Visa. 
        /// </summary>
        VISA,
    }
}

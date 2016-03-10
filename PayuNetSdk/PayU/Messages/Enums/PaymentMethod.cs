// <copyright file="PaymentMethod.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    using System;

    /// <summary>
    /// Represents a payment method in the PayU SDK.
    /// </summary>
    public enum PaymentMethod
    {
        VISA,

        AMEX,

        DINERS,

        MASTERCARD,

        DISCOVER,

        ELO,

        SHOPPING,

        NARANJA,

        CABAL,

        ARGENCARD,

        PRESTO,

        RIPLEY,

        PSE,

        BALOTO,

        EFECTY,

        BCP,

        SEVEN_ELEVEN,

        OXXO,

        BOLETO_BANCARIO,

        RAPIPAGO,

        PAGOFACIL,

        BAPRO,

        COBRO_EXPRESS,

        SERVIPAG,

        SENCILLITO,

        BAJIO,

        BANAMEX,

        BANCOMER,

        HSBC,

        IXE,

        SANTANDER,

        SCOTIABANK,
    }

    /// <summary>
    /// Determines the type of means of payment.
    /// </summary>
    public static class PaymentMethodTypeReference
    {
        /// <summary>
        /// Gets the type of the payment method.
        /// </summary>
        /// <param name="paymentMethod">The payment method.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Payment Method Type not defined.</exception>
        public static PaymentMethodType GetPaymentMethodType(PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.VISA:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.AMEX:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.DINERS:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.MASTERCARD:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.DISCOVER:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.ELO:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.SHOPPING:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.NARANJA:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.CABAL:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.ARGENCARD:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.PRESTO:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.RIPLEY:
                    return PaymentMethodType.CREDIT_CARD;

                case PaymentMethod.PSE:
                    return PaymentMethodType.CASH;

                case PaymentMethod.BALOTO:
                    return PaymentMethodType.CASH;

                case PaymentMethod.EFECTY:
                    return PaymentMethodType.CASH;

                case PaymentMethod.BCP:
                    return PaymentMethodType.CASH;

                case PaymentMethod.SEVEN_ELEVEN:
                    return PaymentMethodType.REFERENCED;

                case PaymentMethod.OXXO:
                    return PaymentMethodType.REFERENCED;

                case PaymentMethod.BOLETO_BANCARIO:
                    return PaymentMethodType.CASH;

                case PaymentMethod.RAPIPAGO:
                    return PaymentMethodType.CASH;

                case PaymentMethod.PAGOFACIL:
                    return PaymentMethodType.CASH;

                case PaymentMethod.BAPRO:
                    return PaymentMethodType.CASH;

                case PaymentMethod.COBRO_EXPRESS:
                    return PaymentMethodType.CASH;

                case PaymentMethod.SERVIPAG:
                    return PaymentMethodType.CASH;

                case PaymentMethod.SENCILLITO:
                    return PaymentMethodType.CASH;

                case PaymentMethod.BAJIO:
                    return PaymentMethodType.CASH;

                case PaymentMethod.BANAMEX:
                    return PaymentMethodType.CASH;

                case PaymentMethod.BANCOMER:
                    return PaymentMethodType.CASH;

                case PaymentMethod.HSBC:
                    return PaymentMethodType.CASH;

                case PaymentMethod.IXE:
                    return PaymentMethodType.CASH;

                case PaymentMethod.SANTANDER:
                    return PaymentMethodType.CASH;

                case PaymentMethod.SCOTIABANK:
                    return PaymentMethodType.CASH;
                default:
                    throw new ArgumentException("Payment Method Type not defined.");
            }
        }
    }
}

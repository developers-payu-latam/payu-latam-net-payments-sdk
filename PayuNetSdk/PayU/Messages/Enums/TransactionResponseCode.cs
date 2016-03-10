// <copyright file="TransactionResponseCode.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a response code for a transaction in the PayU SDK.
    /// </summary>
    public enum TransactionResponseCode
    {
        /// <summary>
        /// Error transaction code 
        /// </summary>
        ERROR,

        /// <summary>
        /// Approved transaction code 
        /// </summary>
        APPROVED,

        /// <summary>
        /// Transaction declined by the entity code 
        /// </summary>
        ENTITY_DECLINED,

        /// <summary>
        /// Transaction rejected by anti fraud system code 
        /// </summary>
        ANTIFRAUD_REJECTED,

        /// <summary>
        /// Transaction review pending code 
        /// </summary>
        PENDING_TRANSACTION_REVIEW,

        /// <summary>
        /// Transaction expired code 
        /// </summary>
        EXPIRED_TRANSACTION,

        /// <summary>
        /// The payment provider had an internal error code 
        /// </summary>
        INTERNAL_PAYMENT_PROVIDER_ERROR,

        /// <summary>
        /// The payment provider is not active code 
        /// </summary>
        INACTIVE_PAYMENT_PROVIDER,

        /// <summary>
        /// The digital certificate could not be found code 
        /// </summary>
        DIGITAL_CERTIFICATE_NOT_FOUND,

        /// <summary>
        /// Transaction rejected by payment network 
        /// </summary>
        PAYMENT_NETWORK_REJECTED,

        /// <summary>
        /// Invalid data code 
        /// </summary>
        INVALID_EXPIRATION_DATE_OR_SECURITY_CODE,

        /// <summary>
        /// Insufficient funds code 
        /// </summary>
        INSUFFICIENT_FUNDS,

        /// <summary>
        /// Credit card not authorized code 
        /// </summary>
        CREDIT_CARD_NOT_AUTHORIZED_FOR_INTERNET_TRANSACTIONS,

        /// <summary>
        /// Transaction is not valid code 
        /// </summary>
        INVALID_TRANSACTION,

        /// <summary>
        /// Credit card is not valid code 
        /// </summary>
        INVALID_CARD,

        /// <summary>
        /// Credit card expired code 
        /// </summary>
        EXPIRED_CARD,

        /// <summary>
        /// Credit card is restricted code 
        /// </summary>
        RESTRICTED_CARD,

        /// <summary>
        /// Need to contact the entity code 
        /// </summary>
        CONTACT_THE_ENTITY,

        /// <summary>
        /// Need to repeat transaction code 
        /// </summary>
        REPEAT_TRANSACTION,

        /// <summary>
        /// Entity sent an error message code 
        /// </summary>
        ENTITY_MESSAGING_ERROR,

        /// <summary>
        /// Transaction confirmation is pending code 
        /// </summary>
        PENDING_TRANSACTION_CONFIRMATION,

        /// <summary>
        /// Bank could not be reached code 
        /// </summary>
        BANK_UNREACHABLE,

        /// <summary>
        /// Amount not valid code 
        /// </summary>
        EXCEEDED_AMOUNT,

        /// <summary>
        /// Transaction not accepted code 
        /// </summary>
        NOT_ACCEPTED_TRANSACTION,

        /// <summary>
        /// Transaction amounts could not be converted code 
        /// </summary>
        ERROR_CONVERTING_TRANSACTION_AMOUNTS,

        /// <summary>
        /// Transaction transmission is pending code 
        /// </summary>
        PENDING_TRANSACTION_TRANSMISSION,

        /// <summary>
        /// Bad response from the payment network code 
        /// </summary>
        PAYMENT_NETWORK_BAD_RESPONSE,

        /// <summary>
        /// Connection failure with the payment network code 
        /// </summary>
        PAYMENT_NETWORK_NO_CONNECTION,

        /// <summary>
        /// Payment network not sending response code 
        /// </summary>
        PAYMENT_NETWORK_NO_RESPONSE,

        /// <summary>
        /// Fix was not required code 
        /// </summary>
        FIX_NOT_REQUIRED,

        /// <summary>
        /// Transaction was automatically fixed  and could make a reversal code 
        /// </summary>
        AUTOMATICALLY_FIXED_AND_SUCCESS_REVERSAL,

        /// <summary>
        /// Transaction was automatically fixed  and couldn't make a reversal code 
        /// </summary>
        AUTOMATICALLY_FIXED_AND_UNSUCCESS_REVERSAL,

        /// <summary>
        /// Transaction can't be automatically fixed code 
        /// </summary>
        AUTOMATIC_FIXED_NOT_SUPPORTED,

        /// <summary>
        /// Transaction was not fixed due to an error state code 
        /// </summary>
        NOT_FIXED_FOR_ERROR_STATE,

        /// <summary>
        /// Transaction could not be fixed and reversed code 
        /// </summary>
        ERROR_FIXING_AND_REVERSING,

        /// <summary>
        /// Transaction was not fixed due to incomplete data code 
        /// </summary>
        ERROR_FIXING_INCOMPLETE_DATA,
    }
}

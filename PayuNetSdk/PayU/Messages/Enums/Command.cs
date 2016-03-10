// <copyright file="Command.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages.Enums
{
    /// <summary>
    /// Represents a command in the PayU SDK.
    /// </summary>
    public enum Command
    {
        /// <summary>
        /// Internal purpose. DON'T USE.
        /// </summary>
        UNKNOWN,

        /// <summary>
        /// Makes a ping to the server testing connectivity.
        /// </summary>
        PING,

        /// <summary>
        /// Sends a transaction to process.
        /// </summary>
        SUBMIT_TRANSACTION,

        /// <summary>
        /// Returns the active payment methods for a merchant.
        /// </summary>
        GET_PAYMENT_METHODS,

        /// <summary>
        /// Returns the active banks.
        /// </summary>
        GET_BANKS_LIST,

        /// <summary>
        /// Create token.
        /// </summary>
        CREATE_TOKEN,

        /// <summary>
        /// Remove token.
        /// </summary>
        REMOVE_TOKEN,

        /// <summary>
        /// Create batch tokens.
        /// </summary>
        CREATE_BATCH_TOKENS,

        /// <summary>
        /// Process the batch of transactions with tokens.
        /// </summary>
        PROCESS_BATCH_TRANSACTIONS_TOKEN,

        /// <summary>
        /// Returns an order detail report.
        /// </summary>
        ORDER_DETAIL,

        /// <summary>
        /// Returns a transaction detail report.
        /// </summary>
        TRANSACTION_RESPONSE_DETAIL,

        /// <summary>
        /// Returns all orders with matching reference code.
        /// </summary>
        ORDER_DETAIL_BY_REFERENCE_CODE,

        /// <summary>
        /// Search batch credit card token.
        /// </summary>
        BATCH_CREDIT_CARD_TOKEN,

        /// <summary>
        /// Finds all tokens by payer.
        /// </summary>
        GET_TOKENS
    }
}

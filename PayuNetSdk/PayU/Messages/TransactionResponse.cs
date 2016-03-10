// <copyright file="TransactionResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using System;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Util.DataStructures;

    /// <summary>
    /// Transaction response from PayU Latam.  
    /// </summary>
    public class TransactionResponse
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>
        /// The order identifier.
        /// </value>
        [XmlElement("orderId")]
        public int? OrderId { get; set; }
        public bool ShouldSerializeOrderId() { return OrderId.HasValue; }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        [XmlElement("transactionId")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [XmlElement("state")]
        public TransactionState? State { get; set; }
        public bool ShouldSerializeState() { return State.HasValue; }

        /// <summary>
        /// Gets or sets the payment network response code.
        /// </summary>
        /// <value>
        /// The payment network response code.
        /// </value>
        [XmlElement("paymentNetworkResponseCode")]
        public string PaymentNetworkResponseCode { get; set; }

        /// <summary>
        /// Gets or sets the payment network response error message.
        /// </summary>
        /// <value>
        /// The payment network response error message.
        /// </value>
        [XmlElement("paymentNetworkResponseErrorMessage")]
        public string PaymentNetworkResponseErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the trazability code.
        /// </summary>
        /// <value>
        /// The trazability code.
        /// </value>
        [XmlElement("trazabilityCode")]
        public string TrazabilityCode { get; set; }

        /// <summary>
        /// Gets or sets the authorization code.
        /// </summary>
        /// <value>
        /// The authorization code.
        /// </value>
        [XmlElement("authorizationCode")]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the pending reason.
        /// </summary>
        /// <value>
        /// The pending reason.
        /// </value>
        [XmlElement("pendingReason")]
        public TransactionPendingReason? PendingReason { get; set; }
        public bool ShouldSerializePendingReason() { return PendingReason.HasValue; }

        /// <summary>
        /// Gets or sets the response code.
        /// </summary>
        /// <value>
        /// The response code.
        /// </value>
        [XmlElement("responseCode")]
        public TransactionResponseCode? ResponseCode { get; set; }
        public bool ShouldSerializeResponseCode() { return ResponseCode.HasValue; }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        [XmlElement("errorCode")]
        public TransactionErrorCode? ErrorCode { get; set; }
        public bool ShouldSerializeErrorCode() { return ErrorCode.HasValue; }

        /// <summary>
        /// Gets or sets the response message.
        /// </summary>
        /// <value>
        /// The response message.
        /// </value>
        [XmlElement("responseMessage")]
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        [XmlElement("transactionDate ")]
        public string TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the transaction time.
        /// </summary>
        /// <value>
        /// The transaction time.
        /// </value>
        [XmlElement("transactionTime")]
        public string TransactionTime { get; set; }

        /// <summary>
        /// Gets or sets the operation date.
        /// </summary>
        /// <value>
        /// The operation date.
        /// </value>
        [XmlElement("operationDate")]
        public DateTime? OperationDate { get; set; }
        public bool ShouldSerializeOperationDate() { return OperationDate.HasValue; }

        /// <summary>
        /// Gets or sets the extra parameters.
        /// </summary>
        /// <value>
        /// The extra parameters.
        /// </value>
        [XmlElement("extraParameters")]
        public SerializableDictionary<string, object> ExtraParameters { get; set; }
    }
}


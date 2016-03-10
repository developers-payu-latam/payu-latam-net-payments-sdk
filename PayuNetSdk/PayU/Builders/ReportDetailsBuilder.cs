// <copyright file="ReportDetailsBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.PayU.Util.DataStructures;

    /// <summary>
    /// Builder class for build existing <see cref="SerializableDictionary<string, object>"/> objects.
    /// </summary>
    internal class ReportDetailsBuilder
    {
        private AbstractRequest request;

        private SerializableDictionary<string, object> details;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDetailsBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public ReportDetailsBuilder(AbstractRequest request)
        {
            this.details = new SerializableDictionary<string, object>();
            this.request = request;
        }

        /// <summary>
        /// Gets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public SerializableDictionary<string, object> Details
        {
            get
            {
                this.Build();
                return this.details;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            int? orderId =  DataConverter.GetIntegerValue(
                this.request.InternalParameters, PayUParameterName.ORDER_ID);

            if (orderId.HasValue)
            {
                this.details.Add(PayUParameterName.ORDER_ID, orderId);
            }

            string referenceCode = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.REFERENCE_CODE);

            if (referenceCode != null)
            {
                this.details.Add(PayUParameterName.REFERENCE_CODE, referenceCode);
            }

            string transactionId = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.TRANSACTION_ID);

            if (transactionId != null)
            {
                this.details.Add(PayUParameterName.TRANSACTION_ID, transactionId);
            }

        }
    }
}

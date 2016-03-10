// <copyright file="ExistingOrderBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Builder class for build existing <see cref="Order"/> objects.
    /// </summary>
    internal class ExistingOrderBuilder : AbstractOrderBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExistingOrderBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public ExistingOrderBuilder(AbstractRequest request)
            : base(request) { }

        /// <summary>
        /// Builds the additional information of the order.
        /// </summary>
        public override void BuildAdditionalInfo()
        {
            base.order.Language = request.Language;
            base.order.Id = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.ORDER_ID);
            base.order.Description = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.DESCRIPTION);
            base.order.ReferenceCode = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.REFERENCE_CODE);
        }

        /// <summary>
        /// Builds the signature or the order.
        /// </summary>
        public override void BuildSignature()
        {
            // Do nothing :)
        }
    }
}

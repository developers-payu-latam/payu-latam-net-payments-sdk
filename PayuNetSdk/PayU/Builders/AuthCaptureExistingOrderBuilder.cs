// <copyright file="AuthCaptureExistingOrderBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Builder class for build existing <see cref="Order"/> objects for AUTHORIZATION and CAPTURE.
    /// </summary>
    internal class AuthCaptureExistingOrderBuilder : AbstractOrderBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthCaptureExistingOrderBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AuthCaptureExistingOrderBuilder(AbstractRequest request)
            : base(request) { }

        /// <summary>
        /// Builds the additional information of the order.
        /// </summary>
        public override void BuildAdditionalInfo()
        {
            base.order.Id = DataConverter.GetIntegerValue(
                base.request.InternalParameters, PayUParameterName.ORDER_ID);
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

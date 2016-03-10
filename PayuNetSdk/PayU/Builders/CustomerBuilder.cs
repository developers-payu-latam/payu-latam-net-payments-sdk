// <copyright file="CustomerBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Builder class for build new <see cref="SubscriptionPlanBuilder"/>.
    /// </summary>
    internal class CustomerBuilder : AbstractBuilder<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public CustomerBuilder(AbstractRequest request)
            : base(request)
        {

        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public override void Build()
        {
            base.Entity.Id = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CUSTOMER_ID);
            base.Entity.FullName = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CUSTOMER_NAME);
            base.Entity.Email = DataConverter.GetValue(
                base.request.InternalParameters, PayUParameterName.CUSTOMER_EMAIL);

        }
    }
}

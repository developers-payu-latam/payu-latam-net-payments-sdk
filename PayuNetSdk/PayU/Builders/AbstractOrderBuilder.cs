// <copyright file="AbstractOrderBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Payments;

    /// <summary>
    /// Base class for build <see cref="Order"/> objects.
    /// </summary>
    internal abstract class AbstractOrderBuilder
    {
        protected Order order;

        protected AbstractRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractOrderBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AbstractOrderBuilder(AbstractRequest request)
        {
            this.order = new Order();
            this.request = request;
        }

        /// <summary>
        /// Gets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public Order Order
        {
            get
            {
                this.Build();
                return this.order;
            }
        }

        /// <summary>
        /// Builds the additional information of the order.
        /// </summary>
        public abstract void BuildAdditionalInfo();

        /// <summary>
        /// Builds the signature or the order.
        /// </summary>
        public abstract void BuildSignature();

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            this.BuildAdditionalInfo();
            this.BuildSignature();
        }
    }
}

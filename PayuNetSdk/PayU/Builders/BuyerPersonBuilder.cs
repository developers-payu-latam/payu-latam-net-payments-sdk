// <copyright file="BuyerPersonBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Personal;

    /// <summary>
    /// Builder class for build <see cref="Buyer"/> objects.
    /// </summary>
    internal class BuyerPersonBuilder : AbstractPersonBuilder<Buyer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyerPersonBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public BuyerPersonBuilder(AbstractRequest request)
            : base(request)
        {
            base.person = new Buyer();
        }

        /// <summary>
        /// Builds the additional information.
        /// </summary>
        public override void BuildAdditionalInfo()
        {
            // Adds Address info
            AddressBuilder addressBuilder = new AddressBuilder(base.request, AddressBuilderType.Post);
            base.person.Address = addressBuilder.Address;
        }
    }
}

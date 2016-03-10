// <copyright file="ExistingOrderBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Personal;

    /// <summary>
    /// Builder class for build existing <see cref="Payer"/> objects.
    /// </summary>
    internal class PayerPersonBuilder : AbstractPersonBuilder<Payer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayerPersonBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public PayerPersonBuilder(AbstractRequest request)
            : base(request)
        {
            base.person = new Payer();
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

// <copyright file="BanksInformationBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model.Payments;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Builder class for build <see cref="BankListInformation"/> objects.
    /// </summary>
    internal class BanksInformationBuilder
    {
        protected AbstractRequest request;
        private BankListInformation bankListInformation;

        /// <summary>
        /// Initializes a new instance of the <see cref="BanksInformationBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public BanksInformationBuilder(AbstractRequest request)
        {
            this.request = request;
            this.bankListInformation = new BankListInformation();
        }

        /// <summary>
        /// Gets the bank list information.
        /// </summary>
        /// <value>
        /// The bank list information.
        /// </value>
        public BankListInformation BankListInformation
        {
            get
            {
                this.Build();
                return this.bankListInformation;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            this.bankListInformation.PaymentCountry = DataConverter.GetEnumValue<PaymentCountry>(
                this.request.InternalParameters, PayUParameterName.COUNTRY);
            this.bankListInformation.PaymentMethod = PaymentMethod.PSE;
        }
    }
}

// <copyright file="AddressBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Address builder type for post or rest request.
    /// </summary>
    internal enum AddressBuilderType
    { 
        Post,
        Rest,
    }

    /// <summary>
    /// Builder class for build <see cref="Address"/> objects.
    /// </summary>
    internal class AddressBuilder
    {
        private Address address;
        
        protected AbstractRequest request;

        private AddressBuilderType addressBuilderType;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressBuilder" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="addressBuilderType">Type of the address builder.</param>
        public AddressBuilder(AbstractRequest request, AddressBuilderType addressBuilderType)
        {
            this.address = new Address();
            this.request = request;
            this.addressBuilderType = addressBuilderType;
        }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public Address Address
        {
            get
            {
                this.Build();
                return this.address;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            // Adds basic info
            this.address.City = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_CITY);
            this.address.Country = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_COUNTRY);
            this.address.Phone = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_PHONE);
            this.address.PostalCode = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_POSTAL_CODE);
            this.address.State = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_STATE);

            this.SetStreets();
        }

        /// <summary>
        /// Sets the streets.
        /// </summary>
        private void SetStreets()
        {
            switch (addressBuilderType)
            {
                case AddressBuilderType.Post:
                    this.address.Street1 = DataConverter.GetValue(
                        this.request.InternalParameters, PayUParameterName.PAYER_STREET);
                    this.address.Street2 = DataConverter.GetValue(
                        this.request.InternalParameters, PayUParameterName.PAYER_STREET_2);
                    this.address.Street3 = DataConverter.GetValue(
                        this.request.InternalParameters, PayUParameterName.PAYER_STREET_3);
                    break;
                case AddressBuilderType.Rest:
                    this.address.Line1 = DataConverter.GetValue(
                        this.request.InternalParameters, PayUParameterName.PAYER_STREET);
                    this.address.Line2 = DataConverter.GetValue(
                        this.request.InternalParameters, PayUParameterName.PAYER_STREET_2);
                    this.address.Line3 = DataConverter.GetValue(
                        this.request.InternalParameters, PayUParameterName.PAYER_STREET_3);
                    break;
            }
        }
    }
}

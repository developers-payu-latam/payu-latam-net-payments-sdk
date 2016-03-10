// <copyright file="AbstractPersonBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Util;

    /// <summary>
    /// Base class for build <see cref="Person"/> objects or inherited.
    /// </summary>
    /// <typeparam name="T">Classes that inherit from <see cref="Person"/></typeparam>
    internal abstract class AbstractPersonBuilder<T> where T : Person
    {
        protected T person;

        protected AbstractRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractPersonBuilder{T}"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AbstractPersonBuilder(AbstractRequest request)
        {
            this.request = request;
        }

        /// <summary>
        /// Gets the person.
        /// </summary>
        /// <value>
        /// The person.
        /// </value>
        public T Person
        {
            get
            {
                this.Build();
                return this.person;
            }
        }

        /// <summary>
        /// Builds the additional information of the person.
        /// </summary>
        public abstract void BuildAdditionalInfo();

        /// <summary>
        /// Builds this instance.
        /// </summary>
        private void Build()
        {
            // Adds basic info
            this.person.EmailAddress = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_EMAIL);
            this.person.FullName = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_NAME);
            this.person.CNPJ = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_CNPJ);
            this.person.ContactPhone = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_CONTACT_PHONE);
            this.person.DniNumber = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.PAYER_DNI);

            // Adds additional info
            this.BuildAdditionalInfo();
        }
    }
}

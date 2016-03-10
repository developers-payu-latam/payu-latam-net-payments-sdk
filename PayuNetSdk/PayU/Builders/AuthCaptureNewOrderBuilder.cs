// <copyright file="AuthCaptureNewOrderBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;
    using PayuNetSdk.PayU.Util;
    using PayuNetSdk.PayU.Util.DataStructures;

    /// <summary>
    /// Builder class for build new <see cref="Order"/> objects for AUTHORIZATION and CAPTURE.
    /// </summary>
    internal class AuthCaptureNewOrderBuilder : AbstractOrderBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthCaptureNewOrderBuilder"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AuthCaptureNewOrderBuilder(AbstractRequest request)
            : base(request) { }

        /// <summary>
        /// Builds the additional information of the order.
        /// </summary>
        public override void BuildAdditionalInfo()
        {
            this.order.Language = this.request.Language;

            this.order.Description = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.DESCRIPTION);
            this.order.ReferenceCode = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.REFERENCE_CODE);
            this.order.AccountId = DataConverter.GetIntegerValue(
                this.request.InternalParameters, PayUParameterName.ACCOUNT_ID);
            
            Currency txCurrency = DataConverter.GetEnumValue<Currency>(
                this.request.InternalParameters, PayUParameterName.CURRENCY);

            this.order.AdditionalValues = new SerializableDictionary<string, AdditionalValue>();
            this.AddAdditionalValue("TX_VALUE", DataConverter.GetDecimalValue(
                this.request.InternalParameters, PayUParameterName.VALUE), txCurrency);
            this.AddAdditionalValue("TX_TAX", DataConverter.GetDecimalValue(
                this.request.InternalParameters, PayUParameterName.TAX_VALUE), txCurrency);
            this.AddAdditionalValue("TX_TAX_RETURN_BASE", DataConverter.GetDecimalValue(
                this.request.InternalParameters, PayUParameterName.TAX_RETURN_BASE), txCurrency);          
        }

        /// <summary>
        /// Builds the signature or the order.
        /// </summary>
        public override void BuildSignature()
        {
            this.order.Signature = DataConverter.GetValue(
                this.request.InternalParameters, PayUParameterName.SIGNATURE);

            if (string.IsNullOrEmpty(this.order.Signature))
            {
                this.order.Signature = SignatureBuilder.BuildSignature(
                    this.order, this.request.Merchant.Id, this.request.Merchant.ApiKey,
                    this.request.Merchant.ApiLogin);
            }
        }

        /// <summary>
        /// Adds the additional value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="currency">The currency.</param>
        private void AddAdditionalValue(string key, decimal? parameter, Currency currency)
        {
            if (parameter.HasValue)
            {
                AdditionalValue additionalValue = new AdditionalValue();
                additionalValue.Currency = currency;
                additionalValue.Value = parameter.Value;
                this.order.AdditionalValues.Add(key, additionalValue);
            }
        }
    }
}

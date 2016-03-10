// <copyright file="PayUTokens.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Api
{
    using PayuNetSdk.PayU.Services;
    using System.Collections.Generic;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Builders;
    using PayuNetSdk.PayU.Messages.Enums;

    /// <summary>
    /// Manages all PAYU tokens operations.
    /// </summary>
    public sealed class PayUTokens : PayU
    {
        /// <summary>
        /// PayUTokens instance for singleton pattern.
        /// </summary>
        private static PayUTokens instance; 

        private static object syncLock = new object();

        /// <summary>
        /// The token service instance.
        /// </summary>
        private TokenService tokenService;

        /// <summary>
        /// Prevents a default instance of the <see cref="PayUTokens"/> class from being created.
        /// </summary>
        private PayUTokens() 
        {
            this.tokenService = new TokenService();
        }

        /// <summary>
        /// Gets the current instance.
        /// </summary>
        /// <value>
        /// Current instance.
        /// </value>
        public static PayUTokens Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new PayUTokens();
                        }
                    }
                }
                return instance;
            }
        }

        ////////////////////////////////////////////////////////////////
        //// PUBLIC OPERATIONS
        ////////////////////////////////////////////////////////////////

        /// <summary>
        /// Creates the token.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public TokenResponse Create(IDictionary<string, string> parameters)
        {
            TokenRequest request = base.CreateBaseRequest<TokenRequest>(ServerType.Payments, parameters);

            CreditCardTokenBuilder builder = new CreditCardTokenBuilder(request);
            request.CreditCardToken = builder.CreditCardToken;

            return this.tokenService.CreateToken(request);
        }

        /// <summary>
        /// Gets the credit card token.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public TokenInfoResponse Find(IDictionary<string, string> parameters)
        {
            TokenRequest request = base.CreateBaseRequest<TokenRequest>(ServerType.Payments, parameters);

            CreditCardTokenBuilder builder = new CreditCardTokenBuilder(request);
            request.CreditCardTokenInfo = builder.CreditCardToken;

            return this.tokenService.GetCreditCardToken(request);
        }

        /// <summary>
        /// Removes a credit card token.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public TokenResponse Remove(IDictionary<string, string> parameters)
        {
            TokenRequest request = base.CreateBaseRequest<TokenRequest>(ServerType.Payments, parameters);

            CreditCardTokenBuilder builder = new CreditCardTokenBuilder(request);
            request.CreditCardTokenRemove = builder.CreditCardToken;

            return this.tokenService.DeleteToken(request);
        }
    }
}

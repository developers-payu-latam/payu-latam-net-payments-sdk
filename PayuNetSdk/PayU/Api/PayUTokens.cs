// The MIT License (MIT)
//
// Copyright (c) 2016 PayU Latam
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
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

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
// <author>Jorge D. Porras</author>using System;

namespace PayuNetSdk.PayU.Services
{
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.RequestStrategies;

    /// <summary>
    /// Services to process tokens
    /// </summary>
    internal class TokenService : AbstractService
    {
        /// <summary>
        /// Creates the token.
        /// </summary>
        /// <param name="tokenRequest">The token request.</param>
        /// <returns></returns>
        public TokenResponse CreateToken(TokenRequest tokenRequest)
        {
            AbstractPostRequestWithAlternativeDataStrategy<TokenRequest, TokenResponse, PaymentResponse> requestStrategy =
                new CreateTokenRequestStrategy(tokenRequest);

            requestStrategy.SendRequest();

            // requestStrategy.RestResponse.Error

            return requestStrategy.RestResponse.Data;
        }

        /// <summary>
        /// Gets the credit card token.
        /// </summary>
        /// <param name="tokenRequest">The token request.</param>
        /// <returns></returns>
        public TokenInfoResponse GetCreditCardToken(TokenRequest tokenRequest)
        {
            AbstractPostRequestWithAlternativeDataStrategy<TokenRequest, TokenInfoResponse, PaymentResponse> requestStrategy =
                new GetTokenRequestStrategy(tokenRequest);

            requestStrategy.SendRequest();

            // todo lanzar error y así en todos los post

            return requestStrategy.RestResponse.Data;
        }

        public TokenResponse DeleteToken(TokenRequest tokenRequest)
        {
            AbstractPostRequestWithAlternativeDataStrategy<TokenRequest, TokenResponse, PaymentResponse> requestStrategy =
                new DeleteTokenRequestStrategy(tokenRequest);

            requestStrategy.SendRequest();

            // requestStrategy.RestResponse.Error

            return requestStrategy.RestResponse.Data;
        }
    }
}

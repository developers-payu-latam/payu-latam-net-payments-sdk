// <copyright file="TokenService.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
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

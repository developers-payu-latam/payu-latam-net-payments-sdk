// <copyright file="SubscriptionResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using PayuNetSdk.PayU.Model.Plans;
    using PayuNetSdk.PayU.Model.Subscriptions;

    /// <summary>
    /// Subscription response from PayU Latam.
    /// </summary>
    public class SubscriptionResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the subscription.
        /// </summary>
        /// <value>
        /// The subscription.
        /// </value>
        public Subscription Subscription { get; set; }        
    }
}

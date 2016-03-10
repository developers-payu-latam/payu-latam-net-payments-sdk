// <copyright file="SubscriptionPlan.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using PayuNetSdk.PayU.Model.Plans;

    /// <summary>
    /// Plan response from PayU Latam.
    /// </summary>
    public class SubscriptionPlanResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the subscription plan.
        /// </summary>
        /// <value>
        /// The subscription plan.
        /// </value>
        public SubscriptionPlan SubscriptionPlan { get; set; }        
    }
}

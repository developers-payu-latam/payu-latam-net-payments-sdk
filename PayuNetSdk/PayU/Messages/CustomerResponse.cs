// <copyright file="CustomerResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using PayuNetSdk.PayU.Model.Customers;

    /// <summary>
    /// Customer response from PayU Latam.
    /// </summary>
    public class CustomerResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public Customer Customer { get; set; }        
    }
}

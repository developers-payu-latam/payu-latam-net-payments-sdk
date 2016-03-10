// <copyright file="RecurringBillItemResponse.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Messages
{
    using PayuNetSdk.PayU.Model.RecurringBillItems;

    /// <summary>
    /// Recurring Bill response from PayU Latam.
    /// </summary>
    public class RecurringBillItemResponse : AbstractResponse
    {
        /// <summary>
        /// Gets or sets the recurring bill item.
        /// </summary>
        /// <value>
        /// The recurring bill item.
        /// </value>
        public RecurringBillItem RecurringBillItem { get; set; }        
    }
}

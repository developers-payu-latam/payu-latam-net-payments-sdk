
namespace PayuNetSdk.PayU.Validators
{
    using System.Collections.Generic;
    using System.Linq;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Validators.Base;
    using PayuNetSdk.Resources;
    using PayuNetSdk.PayU.Model.RecurringBillItems;

    public class RecurringBillItemIdRecurringBillItemValidator : IValidator<RecurringBillItem>
    {
        /// <summary>
        /// Determines whether the specified entity is valid.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool IsValid(RecurringBillItem entity)
        {
            return BrokenRules(entity).Count() == 0;
        }

        /// <summary>
        /// Brokens the rules.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public IEnumerable<string> BrokenRules(RecurringBillItem entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                yield return string.Format(PayUSdkMessages.RequiredParameter, "RECURRING_BILL_ITEM_ID");
            }
        }
    }
}

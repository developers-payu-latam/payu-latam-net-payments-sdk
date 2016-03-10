
namespace PayuNetSdk.PayU.Validators
{
    using System.Collections.Generic;
    using System.Linq;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Validators.Base;
    using PayuNetSdk.Resources;
    using PayuNetSdk.PayU.Model.Plans;

    public class PlanCodeSubscriptionPlanValidator : IValidator<SubscriptionPlan>
    {
        /// <summary>
        /// Determines whether the specified entity is valid.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool IsValid(SubscriptionPlan entity)
        {
            return BrokenRules(entity).Count() == 0;
        }

        /// <summary>
        /// Brokens the rules.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public IEnumerable<string> BrokenRules(SubscriptionPlan entity)
        {
            if (string.IsNullOrEmpty(entity.PlanCode))
            {
                yield return string.Format(PayUSdkMessages.RequiredParameter, "PLAN_CODE");
            }
        }
    }
}

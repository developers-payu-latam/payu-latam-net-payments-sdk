
namespace PayuNetSdk.PayU.Validators
{
    using System.Collections.Generic;
    using System.Linq;
    using PayuNetSdk.PayU.Model.Customers;
    using PayuNetSdk.PayU.Model.RecurringPayments;
    using PayuNetSdk.PayU.Validators.Base;
    using PayuNetSdk.Resources;

    public class TokenCreditCardValidator : IValidator<CreditCard>
    {
        /// <summary>
        /// Determines whether the specified entity is valid.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool IsValid(CreditCard entity)
        {
            return BrokenRules(entity).Count() == 0;
        }

        /// <summary>
        /// Brokens the rules.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public IEnumerable<string> BrokenRules(CreditCard entity)
        {
            if (string.IsNullOrEmpty(entity.Token))
            {
                yield return string.Format(PayUSdkMessages.RequiredParameter, "TOKEN_ID");
            }
        }
    }
}

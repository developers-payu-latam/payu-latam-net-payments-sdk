
namespace PayuNetSdk.PayU.Validators
{
    using System.Collections.Generic;
    using System.Linq;
    using PayuNetSdk.PayU.Model.Payments;
    using PayuNetSdk.PayU.Validators.Base;
    using PayuNetSdk.Resources;

    internal class CreateAuthTransactionValidator : IValidator<Transaction>
    {
        /// <summary>
        /// Determines whether the specified entity is valid.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public bool IsValid(Transaction entity)
        {
            return BrokenRules(entity).Count() == 0;
        }

        /// <summary>
        /// Brokens the rules.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public IEnumerable<string> BrokenRules(Transaction entity)
        {
            if (!entity.PaymentMethod.HasValue)
            {
                yield return string.Format(PayUSdkMessages.RequiredParameter, "PAYMENT_METHOD");
            }
        }
    }
}

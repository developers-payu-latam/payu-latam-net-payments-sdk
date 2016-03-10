using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayuNetSdk.PayU.Model.Payments;
using PayuNetSdk.PayU.Validators.Base;

namespace PayuNetSdk.PayU.Validators
{
    class AuthCreditCardValidator : IValidator<CreditCard>
    {
        public bool IsValid(CreditCard entity)
        {
            return BrokenRules(entity).Count() > 0;
        }

        public IEnumerable<string> BrokenRules(CreditCard entity)
        {
            if (string.IsNullOrEmpty(entity.ExpirationDate))
            {
                yield return "CREDIT_CARD_EXPIRATION_DATE";
            }
            if (string.IsNullOrEmpty(entity.Name))
            {
                yield return "CREDIT_CARD_NAME";
            }

        }
    }
}

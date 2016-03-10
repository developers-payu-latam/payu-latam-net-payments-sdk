using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayuNetSdk.PayU.Validators.Base;
using PayuNetSdk.PayU.Model.Payments;

namespace PayuNetSdk.PayU.Validators
{
    internal class AuthOrderValidator : IValidator<Order>
    {
        public bool IsValid(Order entity)
        {
            return BrokenRules(entity).Count() > 0;
        }

        public IEnumerable<string> BrokenRules(Order entity)
        {
            if (!entity.AccountId.HasValue)
            {
                yield return "ACCOUNT ID";
            }
            if (string.IsNullOrEmpty(entity.ReferenceCode))
            {
                yield return "PARAMETERS.REFERENCE_CODE";
            }
            if (!string.IsNullOrEmpty(entity.ReferenceCode) && entity.ReferenceCode.Length > 100)
            {
                yield return "PARAMETERS.REFERENCE_CODE Largo";
            }
            if (string.IsNullOrEmpty(entity.Description))
            {
                yield return "PARAMETERS.DESCRIPTION";
            }
            if (!string.IsNullOrEmpty(entity.Description) && entity.Description.Length > 255)
            {
                yield return "PARAMETERS.DESCRIPTION Largo";
            }
        }
    }
}

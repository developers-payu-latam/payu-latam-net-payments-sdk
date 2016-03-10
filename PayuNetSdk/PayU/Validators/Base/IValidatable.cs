using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayuNetSdk.PayU.Validators.Base
{
    // PROXIMO SPRINT :p
    public interface IValidatable<T>
    {
        bool Validate(IValidator<T> validator, out IEnumerable<string> brokenRules);
    }
}

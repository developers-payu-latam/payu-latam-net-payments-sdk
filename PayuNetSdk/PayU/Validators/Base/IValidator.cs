using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayuNetSdk.PayU.Validators.Base
{
    // PROXIMO SPRINT :p
    public interface IValidator<T>
    {
        bool IsValid(T entity);
        IEnumerable<string> BrokenRules(T entity);
    }
}

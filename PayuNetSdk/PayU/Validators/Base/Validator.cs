

namespace PayuNetSdk.PayU.Validators.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public enum ValidatorContext
    {
        NONE,
        CREATE,
        UPDATE,
        DELETE,
        GET,
    }

    /// <summary>
    /// 
    /// </summary>
    class ValidatorKey
    {
        public ValidatorContext ValidatorContext { get; set; }
        public Type EntityType { get; set; }
    }

    /// <summary>
    /// Validator
    /// </summary>
    public static class Validator
    {
        private const string KEY = "{0}-{1}";

        /// <summary>
        /// The validators
        /// </summary>
        private static IDictionary<string, object> validators = new Dictionary<string, object>();

        /// <summary>
        /// Registers the validator for.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="validator">The validator.</param>
        public static void RegisterValidatorFor<T>(IValidator<T> validator, ValidatorContext context)
            where T : IValidatable<T>
        {
            ValidatorKey key = new ValidatorKey();
            key.EntityType = typeof(T);
            key.ValidatorContext = context;
            validators.Add(string.Format(KEY, key.EntityType.ToString(), 
                key.ValidatorContext.ToString()), validator);
        }

        /// <summary>
        /// Gets the validator for.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IValidator<T> GetValidatorFor<T>(T entity, ValidatorContext context)
            where T : IValidatable<T>
        {
            ValidatorKey key = new ValidatorKey();
            key.EntityType = typeof(T);
            key.ValidatorContext = context;

            return validators[string.Format(KEY, key.EntityType.ToString(), 
                key.ValidatorContext.ToString())] as IValidator<T>;
        }

        /// <summary>
        /// Validates the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="brokenRules">The broken rules.</param>
        /// <returns></returns>
        public static bool Validate<T>(this T entity, out IEnumerable<string> brokenRules, ValidatorContext context)
            where T : IValidatable<T>
        {
            IValidator<T> validator = Validator.GetValidatorFor(entity, context);

            return entity.Validate(validator, out brokenRules);
        }
    }
}

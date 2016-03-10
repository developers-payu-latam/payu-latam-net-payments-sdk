using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayuNetSdk.PayU.Model.Payments;
using PayuNetSdk.PayU.Model.Customers;
using PayuNetSdk.PayU.Model.Plans;
using PayuNetSdk.PayU.Model.Subscriptions;
using PayuNetSdk.PayU.Model.RecurringBillItems;

namespace PayuNetSdk.PayU.Validators.Base
{
    /// <summary>
    /// 
    /// </summary>
    internal class ValidatorLoader
    {
        /// <summary>
        /// The instance
        /// </summary>
        private static ValidatorLoader instance;

        /// <summary>
        /// The synchronize lock
        /// </summary>
        private static object syncLock = new object();

        /// <summary>
        /// Prevents a default instance of the <see cref="ValidatorLoader"/> class from being created.
        /// </summary>
        private ValidatorLoader() { }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <returns></returns>
        public static ValidatorLoader Load()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new ValidatorLoader();
                        instance.RegisterValidators();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Registers the validators.
        /// </summary>
        private void RegisterValidators() 
        {
            Validator.RegisterValidatorFor<Transaction>(new CreateAuthTransactionValidator(), ValidatorContext.CREATE);
                               
            Validator.RegisterValidatorFor<PayuNetSdk.PayU.Model.RecurringPayments.CreditCard>(new CreateCreditCardRecurringPaymentValidator(), ValidatorContext.CREATE);
            Validator.RegisterValidatorFor<PayuNetSdk.PayU.Model.RecurringPayments.CreditCard>(new TokenCreditCardValidator(), ValidatorContext.UPDATE);
            Validator.RegisterValidatorFor<PayuNetSdk.PayU.Model.RecurringPayments.CreditCard>(new TokenCreditCardValidator(), ValidatorContext.GET);
            Validator.RegisterValidatorFor<PayuNetSdk.PayU.Model.RecurringPayments.CreditCard>(new DeleteCreditCardValidator(), ValidatorContext.DELETE);

            Validator.RegisterValidatorFor<Customer>(new CustomerIdCustomerValidator(), ValidatorContext.UPDATE);
            Validator.RegisterValidatorFor<Customer>(new CustomerIdCustomerValidator(), ValidatorContext.DELETE);
            Validator.RegisterValidatorFor<Customer>(new CustomerIdCustomerValidator(), ValidatorContext.GET);

            Validator.RegisterValidatorFor<SubscriptionPlan>(new PlanCodeSubscriptionPlanValidator(), ValidatorContext.UPDATE);
            Validator.RegisterValidatorFor<SubscriptionPlan>(new PlanCodeSubscriptionPlanValidator(), ValidatorContext.DELETE);
            Validator.RegisterValidatorFor<SubscriptionPlan>(new PlanCodeSubscriptionPlanValidator(), ValidatorContext.GET);

            Validator.RegisterValidatorFor<Subscription>(new SubscriptionIdSubscriptionValidator(), ValidatorContext.DELETE);

            Validator.RegisterValidatorFor<RecurringBillItem>(new CreateRecurringBillItemValidator(), ValidatorContext.CREATE);
            Validator.RegisterValidatorFor<RecurringBillItem>(new RecurringBillItemIdRecurringBillItemValidator(), ValidatorContext.UPDATE);
            Validator.RegisterValidatorFor<RecurringBillItem>(new RecurringBillItemIdRecurringBillItemValidator(), ValidatorContext.GET);
            Validator.RegisterValidatorFor<RecurringBillItem>(new RecurringBillItemIdRecurringBillItemValidator(), ValidatorContext.DELETE);
            
                        
            // ....
        }
    }
}

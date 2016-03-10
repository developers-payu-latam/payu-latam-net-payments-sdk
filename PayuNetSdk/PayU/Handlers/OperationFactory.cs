using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using PayuNetSdk.PayU.Messages;
using PayuNetSdk.PayU.Model.Payments;
using PayuNetSdk.PayU.Messages.Enums;
using PayuNetSdk.PayU.Util;

namespace PayuNetSdk.PayU.Handlers
{
    // CLASE PARA ELIMINAR
    internal class OperationFactory
    {
        private readonly IDictionary<ICollection<string>,
            Func<IDictionary<string, string>, AbstractRequest>> commands;


        public OperationFactory()
        {
            commands = new Dictionary<ICollection<string>,
            Func<IDictionary<string, string>, AbstractRequest>>();

            commands.Add(new List<string>() { PayUParameterName.CREDIT_CARD_NUMBER }, PayWithCreditCard);

            commands.Add(new List<string>() { 
                PayUParameterName.CREDIT_CARD_NUMBER, 
                PayUParameterName.PROCESS_WITHOUT_CVV2 
            }
                , PayWithCreditCardWithOptionalSecurityCode);
        }

        public PaymentRequest PayWithCreditCard(IDictionary<string, string> parameters)
        {

            PaymentRequest paymentRequest = new PaymentRequest();

            parameters.ContainsKey(PayUParameterName.REFERENCE_CODE);


            return paymentRequest;
        }

        public PaymentRequest PayWithCreditCardWithOptionalSecurityCode(IDictionary<string, string> parameters)
        {

            PaymentRequest paymentRequest = new PaymentRequest();

            //TODO TRANDUCIR

            return paymentRequest;
        }

        private Transaction BuildTransaction(IDictionary<string, string> parameters)
        {

            
            string orderReference = DataConverter.GetValue(parameters, PayUParameterName.REFERENCE_CODE);
            string creditCardNumber = DataConverter.GetValue(parameters, PayUParameterName.CREDIT_CARD_NUMBER);
            string creditCardExpirationDate = DataConverter.GetValue(parameters, PayUParameterName.CREDIT_CARD_EXPIRATION_DATE);
            bool? processWithoutCvv2 = DataConverter.GetBooleanValue(parameters, PayUParameterName.PROCESS_WITHOUT_CVV2);
            string securityCode = DataConverter.GetValue(parameters, PayUParameterName.CREDIT_CARD_SECURITY_CODE);
            string parentTransactionId = DataConverter.GetValue(parameters, PayUParameterName.TRANSACTION_ID);
            string expirationDate = DataConverter.GetValue(parameters, PayUParameterName.EXPIRATION_DATE);
            PaymentMethod paymentMethod = DataConverter.GetEnumValue<PaymentMethod>(parameters, PayUParameterName.PAYMENT_METHOD);
            int? installments = DataConverter.GetIntegerValue(parameters, PayUParameterName.INSTALLMENTS_NUMBER);

            string tokenId = DataConverter.GetValue(parameters, PayUParameterName.TOKEN_ID);

            Transaction transaction = new Transaction();
            //transaction.Type(transactionType);

            return transaction;
        }
    }
}

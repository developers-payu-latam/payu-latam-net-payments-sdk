namespace PayuNetSdk.Tests.PayU.Api
{
    using NUnit.Framework;
    using PayuNetSdk.PayU.Messages;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;
    using PayuNetSdk.PayU.Model.Payments;
    using PayuNetSdk.PayU.Model.Personal;
    using PayuNetSdk.PayU.Util.DataStructures;
    using RestSharp;
    using RestSharp.Deserializers;
    using RestSharp.Serializers;

    public class SerializationDeserializationTest : AbstractTest
    {
        /// <summary>
        /// Serializes the ping request test.
        /// </summary>
        [Test]
        public void SerializePingRequestTest()
        {
            PingRequest request = new PingRequest();
            request.Language = Language.en;
            request.Merchant = new Merchant()
            {
                ApiKey = base.apiKey,
                ApiLogin = base.apiLogin
            };
            request.Url = base.paymentsUrl;

            request.Command = Command.PING;

            DotNetXmlSerializer serializer = new DotNetXmlSerializer();
            
            string serializedObject = serializer.Serialize(request);

            Assert.IsTrue(serializedObject.Contains("<request>"));
            Assert.IsTrue(serializedObject.Contains("<command>PING</command>"));
            Assert.IsTrue(serializedObject.Contains("<apiLogin>012345678901</apiLogin>"));
            Assert.IsTrue(serializedObject.Contains("<apiKey>012345678901</apiKey>"));
            Assert.IsTrue(serializedObject.Contains("<language>en</language>"));
            Assert.IsTrue(serializedObject.Contains("</request>"));
        }

        /// <summary>
        /// Serializes the payment request test.
        /// </summary>
        [Test]
        public void SerializePaymentRequestTest()
        {
            PaymentRequest request = new PaymentRequest();

            request.Language = Language.en;
            request.Merchant = new Merchant()
            {
                ApiKey = base.apiKey,
                ApiLogin = base.apiLogin
            };
            request.Url = base.paymentsUrl;

            request.Command = Command.SUBMIT_TRANSACTION;

            request.Transaction = new Transaction();
            request.Transaction.Order = new Order();
            request.Transaction.Order.AccountId = 8;
            request.Transaction.Order.ReferenceCode = "A1B2C3";
            request.Transaction.Order.Description = "ALL IN 5";
            request.Transaction.Order.Language = request.Language;
            request.Transaction.Order.Signature = "575522081b12448a6a0cf326716a9c13";
            request.Transaction.Order.Buyer = new Buyer();
            request.Transaction.Order.Buyer.FullName = "NAME 1383885401927";
            request.Transaction.Order.Buyer.Address = new Address();
            request.Transaction.Order.Buyer.Address.Street1 = "1";
            request.Transaction.Order.Buyer.Address.City = "Bogotá";
            request.Transaction.Order.AdditionalValues = new SerializableDictionary<string, AdditionalValue>();
            request.Transaction.Order.AdditionalValues.Add("TX_TAX_RETURN_BASE", new AdditionalValue()
            {
                Currency = Currency.USD,
                Value = 100.00M
            });
            request.Transaction.Order.AdditionalValues.Add("TX_VALUE", new AdditionalValue()
            {
                Currency = Currency.USD,
                Value = 100.00M
            });
            request.Transaction.Order.AdditionalValues.Add("TX_TAX", new AdditionalValue()
            {
                Currency = Currency.USD,
                Value = 16.00M
            });
            request.Transaction.CreditCard = new CreditCard();
            request.Transaction.CreditCard.Name = "NAME 1383922917718";
            request.Transaction.CreditCard.Number = "4005580000029205";
            request.Transaction.CreditCard.SecurityCode = "495";
            request.Transaction.CreditCard.ExpirationDate = "2015/01";
            request.Transaction.TransactionType = TransactionType.AUTHORIZATION;
            request.Transaction.PaymentMethod = PaymentMethod.VISA;
            request.Transaction.Source = TransactionSource.PAYU_SDK;
            request.Transaction.PaymentCountry = PaymentCountry.PA;
            request.Transaction.Payer = new Payer();
            request.Transaction.Payer.FullName = "NAME 1383922917718";
            request.Transaction.Payer.Address = new Address();
            request.Transaction.Payer.Address.City = "Bogotá";
            request.Transaction.Payer.Address.Street1 = "ABC 123";
            request.Transaction.IpAddress = "127.0.0.1";
            request.Transaction.Cookie = "Cookie";
            request.Transaction.UserAgent = ".NET te quiero como a Dominique de DM Argentina, eres lo máximo";
            request.Transaction.ExtraParameters = new SerializableDictionary<string, string>();
            request.Transaction.ExtraParameters.Add("INSTALLMENTS_NUMBER", "3");

            DotNetXmlSerializer serializer = new DotNetXmlSerializer();
            string serializedObject = serializer.Serialize(request);

            Assert.IsTrue(serializedObject.Contains("<request>"));
            Assert.IsTrue(serializedObject.Contains("<command>SUBMIT_TRANSACTION</command>"));
            Assert.IsTrue(serializedObject.Contains("<language>en</language>"));
            Assert.IsTrue(serializedObject.Contains("<merchant>"));
            Assert.IsTrue(serializedObject.Contains("<apiLogin>012345678901</apiLogin>"));
            Assert.IsTrue(serializedObject.Contains("<apiKey>012345678901</apiKey>"));
            Assert.IsTrue(serializedObject.Contains("</merchant>"));
            Assert.IsTrue(serializedObject.Contains("<transaction>"));
            Assert.IsTrue(serializedObject.Contains("<order>"));
            Assert.IsTrue(serializedObject.Contains("<accountId>8</accountId>"));
            Assert.IsTrue(serializedObject.Contains("<referenceCode>A1B2C3</referenceCode>"));
            Assert.IsTrue(serializedObject.Contains("<description>ALL IN 5</description>"));
            Assert.IsTrue(serializedObject.Contains("<language>en</language>"));
            Assert.IsTrue(serializedObject.Contains("<signature>575522081b12448a6a0cf326716a9c13</signature>"));
            Assert.IsTrue(serializedObject.Contains("<buyer>"));
            Assert.IsTrue(serializedObject.Contains("<fullName>NAME 1383885401927</fullName>"));
            Assert.IsTrue(serializedObject.Contains("<shippingAddress>"));
            Assert.IsTrue(serializedObject.Contains("<street1>1</street1>"));
            Assert.IsTrue(serializedObject.Contains("<city>Bogotá</city>"));
            Assert.IsTrue(serializedObject.Contains("</shippingAddress>"));
            Assert.IsTrue(serializedObject.Contains("</buyer>"));
            Assert.IsTrue(serializedObject.Contains("<additionalValues>"));
            Assert.IsTrue(serializedObject.Contains("<entry>"));
            Assert.IsTrue(serializedObject.Contains("<string>TX_TAX_RETURN_BASE</string>"));
            Assert.IsTrue(serializedObject.Contains("<additionalValue>"));
            Assert.IsTrue(serializedObject.Contains("<value>100.00</value>"));
            Assert.IsTrue(serializedObject.Contains("<currency>USD</currency>"));
            Assert.IsTrue(serializedObject.Contains("</additionalValue>"));
            Assert.IsTrue(serializedObject.Contains("</entry>"));
            Assert.IsTrue(serializedObject.Contains("</additionalValues>"));
            Assert.IsTrue(serializedObject.Contains("</order>"));
            Assert.IsTrue(serializedObject.Contains("<creditCard>"));
            Assert.IsTrue(serializedObject.Contains("<number>4005580000029205</number>"));
            Assert.IsTrue(serializedObject.Contains("<securityCode>495</securityCode>"));
            Assert.IsTrue(serializedObject.Contains("<expirationDate>2015/01</expirationDate>"));
            Assert.IsTrue(serializedObject.Contains("<name>NAME 1383922917718</name>"));
            Assert.IsTrue(serializedObject.Contains("</creditCard>"));
            Assert.IsTrue(serializedObject.Contains("<type>AUTHORIZATION</type>"));
            Assert.IsTrue(serializedObject.Contains("<paymentMethod>VISA</paymentMethod>"));
            Assert.IsTrue(serializedObject.Contains("<source>PAYU_SDK</source>"));
            Assert.IsTrue(serializedObject.Contains("<paymentCountry>PA</paymentCountry>"));
            Assert.IsTrue(serializedObject.Contains("<payer>"));
            Assert.IsTrue(serializedObject.Contains("<fullName>NAME 1383922917718</fullName>"));
            Assert.IsTrue(serializedObject.Contains("<billingAddress>"));
            Assert.IsTrue(serializedObject.Contains("<street1>ABC 123</street1>"));
            Assert.IsTrue(serializedObject.Contains("<city>Bogotá</city>"));
            Assert.IsTrue(serializedObject.Contains("</billingAddress>"));
            Assert.IsTrue(serializedObject.Contains("</payer>"));
            Assert.IsTrue(serializedObject.Contains("<ipAddress>127.0.0.1</ipAddress>"));
            Assert.IsTrue(serializedObject.Contains("<cookie>Cookie</cookie>"));
            Assert.IsTrue(serializedObject.Contains("<extraParameters>"));
            Assert.IsTrue(serializedObject.Contains("<entry>"));
            Assert.IsTrue(serializedObject.Contains("<string>INSTALLMENTS_NUMBER</string>"));
            Assert.IsTrue(serializedObject.Contains("<string>3</string>"));
            Assert.IsTrue(serializedObject.Contains("</entry>"));
            Assert.IsTrue(serializedObject.Contains("</extraParameters>"));
            Assert.IsTrue(serializedObject.Contains("</transaction>"));
            Assert.IsTrue(serializedObject.Contains("</request>"));
        }

        [Test]
        public void DeserializePaymentMethodsTest()
        {
            DotNetXmlDeserializer deserializer = new DotNetXmlDeserializer();

            RestResponse restResponse = new RestResponse();
            restResponse.Content = @"<paymentMethodsResponse>
                                           <code>SUCCESS</code>
                                           <paymentMethods>
                                              <paymentMethodComplete>
                                                 <id>193</id>
                                                 <description>COBRO_EXPRESS</description>
                                                 <country>AR</country>
                                              </paymentMethodComplete>
                                              <paymentMethodComplete>
                                                 <id>254</id>
                                                 <description>PSE</description>
                                                 <country>CO</country>
                                              </paymentMethodComplete>
                                              <paymentMethodComplete>
                                                 <id>139</id>
                                                 <description>AMEX</description>
                                                 <country>MX</country>
                                              </paymentMethodComplete>
                                              <paymentMethodComplete>
                                                 <id>250</id>
                                                 <description>VISA</description>
                                                 <country>CO</country>
                                              </paymentMethodComplete>
                                           </paymentMethods>
                                        </paymentMethodsResponse>";

            PaymentMethodsResponse response = deserializer.Deserialize<PaymentMethodsResponse>(restResponse);

            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
            Assert.AreEqual(4, response.PaymentMethods.Count);
            Assert.AreEqual("193", response.PaymentMethods[0].Id);
            Assert.AreEqual("COBRO_EXPRESS", response.PaymentMethods[0].Description);
            Assert.AreEqual(PaymentCountry.AR.ToString(), response.PaymentMethods[0].Country);
            Assert.AreEqual("254", response.PaymentMethods[1].Id);
            Assert.AreEqual("PSE", response.PaymentMethods[1].Description);
            Assert.AreEqual(PaymentCountry.CO.ToString(), response.PaymentMethods[1].Country);
            Assert.AreEqual("139", response.PaymentMethods[2].Id);
            Assert.AreEqual("AMEX", response.PaymentMethods[2].Description);
            Assert.AreEqual(PaymentCountry.MX.ToString(), response.PaymentMethods[2].Country);
            Assert.AreEqual("250", response.PaymentMethods[3].Id);
            Assert.AreEqual("VISA", response.PaymentMethods[3].Description);
            Assert.AreEqual(PaymentCountry.CO.ToString(), response.PaymentMethods[3].Country);            
        }

        /// <summary>
        /// Deserializes the extra parameters.
        /// </summary>
        [Test]
        public void DeserializeExtraParameters()
        {
            DotNetXmlDeserializer deserializer = new DotNetXmlDeserializer();

            RestResponse restResponse = new RestResponse();
            restResponse.Content = @"<paymentResponse>
                                       <code>SUCCESS</code>
                                       <transactionResponse>
                                          <orderId>2448200</orderId>
                                          <transactionId>accdf6e8-03be-466c-9eca-561100b8d9ca</transactionId>
                                          <state>PENDING</state>
                                          <pendingReason>AWAITING_NOTIFICATION</pendingReason>
                                          <responseCode>PENDING_TRANSACTION_CONFIRMATION</responseCode>
                                          <extraParameters>
                                             <entry>
                                                <string>EXPIRATION_DATE</string>
                                                <date>2013-11-16T14:43:53</date>
                                             </entry>
                                             <entry>
                                                <string>REFERENCE</string>
                                                <int>2448200</int>
                                             </entry>
                                          </extraParameters>
                                       </transactionResponse>
                                    </paymentResponse>";

            PaymentResponse aymentResponse = deserializer.Deserialize<PaymentResponse>(restResponse);
            Assert.IsNotNull(aymentResponse.TransactionResponse.ExtraParameters);
            Assert.AreEqual(2, aymentResponse.TransactionResponse.ExtraParameters.Count);

            object obj = aymentResponse.TransactionResponse.ExtraParameters["EXPIRATION_DATE"];
            Assert.AreEqual("2013-11-16T14:43:53", obj);

            obj = aymentResponse.TransactionResponse.ExtraParameters["REFERENCE"];
            Assert.AreEqual("2448200", obj);
        }

        [Test]
        public void DeserializeReportTest()
        {
            string raw = @"<reportingResponse>
                               <code>SUCCESS</code>
                               <result>
                                  <payload class=""order"">
                                     <id>6073035</id>
                                     <accountId>8</accountId>
                                     <status>CAPTURED</status>
                                     <referenceCode>8c3dd156-b902-4a10-956f-06e35c7c9fe0-20v213c4ld3</referenceCode>
                                     <description>PlanRecu-72861 - 2c8axh8i9q6</description>
                                     <language>es</language>
                                     <buyer>
                                        <fullName>Javier Humberto Ortiz Molina</fullName>
                                        <emailAddress>test.pagosonline.calidad@gmail.com</emailAddress>
                                     </buyer>
                                     <transactions>
                                        <transaction>
                                           <id>c0c0eaad-9454-4c6a-b38f-9d750257c30c</id>
                                           <creditCard>
                                              <maskedNumber>416684******0786</maskedNumber>
                                              <name>Javier Humberto Ortiz Molina</name>
                                           </creditCard>
                                           <type>AUTHORIZATION_AND_CAPTURE</type>
                                           <paymentMethod>VISA</paymentMethod>
                                           <source>RECURRING_PAYMENTS</source>
                                           <paymentCountry>PA</paymentCountry>
                                           <transactionResponse>
                                              <state>APPROVED</state>
                                              <paymentNetworkResponseCode>00</paymentNetworkResponseCode>
                                              <trazabilityCode>332313563116</trazabilityCode>
                                              <authorizationCode>123456</authorizationCode>
                                              <responseCode>APPROVED</responseCode>
                                              <operationDate>2013-11-19T08:29:13</operationDate>
                                           </transactionResponse>
                                           <payer>
                                              <merchantPayerId>2c8axh8i9q6</merchantPayerId>
                                              <fullName>Javier Humberto Ortiz Molina</fullName>
                                              <emailAddress>test.pagosonline.calidad@gmail.com</emailAddress>
                                           </payer>
                                           <additionalValues>
                                              <entry>
                                                 <string>TX_ADDITIONAL_VALUE</string>
                                                 <additionalValue>
                                                    <value>0.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>PM_ADDITIONAL_VALUE</string>
                                                 <additionalValue>
                                                    <value>0.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>TX_TAX_RETURN_BASE</string>
                                                 <additionalValue>
                                                    <value>5.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>PM_TAX</string>
                                                 <additionalValue>
                                                    <value>10.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>TX_VALUE</string>
                                                 <additionalValue>
                                                    <value>131.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>PM_TAX_RETURN_BASE</string>
                                                 <additionalValue>
                                                    <value>5.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>TX_TAX</string>
                                                 <additionalValue>
                                                    <value>10.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>PM_VALUE</string>
                                                 <additionalValue>
                                                    <value>131.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>TX_NETWORK_VALUE</string>
                                                 <additionalValue>
                                                    <value>131.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>COMMISSION_VALUE</string>
                                                 <additionalValue>
                                                    <value>6.05</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                              <entry>
                                                 <string>PM_NETWORK_VALUE</string>
                                                 <additionalValue>
                                                    <value>131.00</value>
                                                    <currency>USD</currency>
                                                 </additionalValue>
                                              </entry>
                                           </additionalValues>
                                           <extraParameters>
                                              <entry>
                                                 <string>INSTALLMENTS_NUMBER</string>
                                                 <string>2</string>
                                              </entry>
                                           </extraParameters>
                                        </transaction>
                                     </transactions>
                                     <additionalValues>
                                        <entry>
                                           <string>TX_ADDITIONAL_VALUE</string>
                                           <additionalValue>
                                              <value>0.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>PM_ADDITIONAL_VALUE</string>
                                           <additionalValue>
                                              <value>0.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>PM_TAX</string>
                                           <additionalValue>
                                              <value>10.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>TX_TAX_RETURN_BASE</string>
                                           <additionalValue>
                                              <value>5.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>TX_VALUE</string>
                                           <additionalValue>
                                              <value>131.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>TX_TAX</string>
                                           <additionalValue>
                                              <value>10.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>PM_TAX_RETURN_BASE</string>
                                           <additionalValue>
                                              <value>5.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>PM_VALUE</string>
                                           <additionalValue>
                                              <value>131.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>TX_NETWORK_VALUE</string>
                                           <additionalValue>
                                              <value>131.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                        <entry>
                                           <string>PM_NETWORK_VALUE</string>
                                           <additionalValue>
                                              <value>131.00</value>
                                              <currency>USD</currency>
                                           </additionalValue>
                                        </entry>
                                     </additionalValues>
                                  </payload>
                               </result>
                            </reportingResponse>";

            DotNetXmlDeserializer deserializer = new DotNetXmlDeserializer();

            RestResponse restResponse = new RestResponse();
            restResponse.Content = raw;
            OrderReportResponse response = deserializer.Deserialize<OrderReportResponse>(restResponse);

            Assert.IsNotNull(response);
            Assert.AreEqual(ResponseCode.SUCCESS, response.ResponseCode);
        }

    }
}

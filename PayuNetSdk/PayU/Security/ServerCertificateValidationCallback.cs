// <copyright file="ServerCertificateValidation.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Security
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    /// <summary>
    /// Validates server certificate.
    /// 
    /// By default, allows any certificate.
    /// </summary>
    internal class ServerCertificateValidation
    {
        private static ServerCertificateValidation instance;

        private static object syncLock = new object();

        /// <summary>
        /// Prevents a default instance of the <see cref="ServerCertificateValidation"/> class from being created.
        /// </summary>
        private ServerCertificateValidation() { }

        /// <summary>
        /// Validates the server certificate.
        /// 
        /// Accept any certificate.
        /// WARNING. VALIDATE WITH DEV PAYU TEAM
        /// </summary>
        /// <returns></returns>
        public static ServerCertificateValidation ValidateServerCertificate()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new ServerCertificateValidation();

                        ServicePointManager.ServerCertificateValidationCallback =
                            delegate(object s, X509Certificate certificate, 
                                X509Chain chain, SslPolicyErrors sslPolicyErrors)
                            {
                                return true;
                            };

                    }
                }
            }
            return instance;
        }
    }
}

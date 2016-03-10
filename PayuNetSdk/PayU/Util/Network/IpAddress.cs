// <copyright file="IpAddress.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Util.Network
{
    using System.Net;
    using System.Net.Sockets;

    /// <summary>
    /// Utility class for obtain local ip address.
    /// </summary>
    internal class IpAddress
    {
        private static IpAddress instance;

        private static object syncLock = new object();

        /// <summary>
        /// Prevents a default instance of the <see cref="IpAddress"/> class from being created.
        /// </summary>
        private IpAddress() { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>IpAddress instance.</returns>
        public static IpAddress GetInstance()
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new IpAddress();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// Gets the local ip address.
        /// </summary>
        /// <returns>Ip address</returns>
        public string GetLocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}

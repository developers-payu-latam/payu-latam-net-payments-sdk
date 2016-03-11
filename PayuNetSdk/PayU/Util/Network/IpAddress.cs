// The MIT License (MIT)
//
// Copyright (c) 2016 PayU Latam
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
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

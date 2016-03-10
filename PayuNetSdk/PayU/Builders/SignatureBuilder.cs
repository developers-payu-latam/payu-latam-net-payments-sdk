// <copyright file="SignatureBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using System.Globalization;
    using System.Security.Cryptography;
    using System.Text;
    using PayuNetSdk.PayU.Model.Payments;

    /// <summary>
    /// Builder class for generate the signature of the request.
    /// </summary>
    internal class SignatureBuilder
    {
        private const string CURRENCY_FORMAT = "{0:0.00}";

        /// <summary>
        /// Builds the signature.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="key">The key.</param>
        /// <param name="valueFormat">The value format.</param>
        /// <returns></returns>
        public static string BuildSignature(Order order, int merchantId,
            string key, string valueFormat)
        {
            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(
                BuildMessage(order, merchantId, key, valueFormat)));

            StringBuilder hash = new StringBuilder();

            for (int i = 0; i <= data.Length - 1; i++)
            {
                hash.Append(data[i].ToString("x2"));
            }

            return hash.ToString();
        }

        /// <summary>
        /// Builds the message.
        /// </summary>
        /// <param name="order">The order.</param>
        /// <param name="merchantId">The merchant identifier.</param>
        /// <param name="key">The key.</param>
        /// <param name="valueFormat">The value format.</param>
        /// <returns></returns>
        private static string BuildMessage(Order order, int merchantId,
            string key, string valueFormat)
        {
            string.Format(CURRENCY_FORMAT, valueFormat);

            StringBuilder message = new StringBuilder();

            message.Append(key);
            message.Append("~");
            message.Append(merchantId);
            message.Append("~");
            message.Append(order.ReferenceCode);
            message.Append("~");
            message.Append(string.Format(CultureInfo.InvariantCulture, CURRENCY_FORMAT, order.AdditionalValues["TX_VALUE"].Value));
            message.Append("~");
            message.Append(order.AdditionalValues["TX_VALUE"].Currency.ToString());

            return message.ToString();
        }
    }
}

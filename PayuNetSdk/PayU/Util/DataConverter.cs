﻿// <copyright file="DataConverter.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Util
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using PayuNetSdk.Resources;

    /// <summary>
    /// Converter of data types.
    /// </summary>
    internal static class DataConverter
    {
        /// <summary>
        /// Tries the get value from a Dictionary.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool TryGetValue(IDictionary<string, string> parameters, 
            string paramName, out string value)
        {
            try
            {
                value = parameters[paramName];
                return true;
            }
            catch (KeyNotFoundException)
            {
                value = null;
                return false;
            }
        }

        /// <summary>
        /// Gets the value of the a Dictionary.
        /// </summary>
        /// <param name="parameters">The parameters to retreive the value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is found. Otherwise, null.</returns>
        public static string GetValue(IDictionary<string, string> parameters, string paramName)
        {
            string value;
            try
            {
                value = parameters[paramName];
            }
            catch (KeyNotFoundException)
            {
                value = null;
            }
            return value;
        }

        /// <summary>
        /// Gets the integer value.
        /// </summary>
        /// <param name="parameters">The parameters to retreive the value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is found. Otherwise, null.</returns>
        public static int? GetIntegerValue(IDictionary<string, string> parameters, string paramName)
        {
            var value = GetValue(parameters, paramName);
            return ParseIntegerValue(value, paramName);
        }

        /// <summary>
        /// Gets the boolean value.
        /// </summary>
        /// <param name="parameters">The parameters to retreive the value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is found. Otherwise, null.</returns>
        public static bool? GetBooleanValue(IDictionary<string, string> parameters, string paramName)
        {
            var value = GetValue(parameters, paramName);
            return ParseBooleanValue(value, paramName);
        }

        /// <summary>
        /// Gets the decimal value.
        /// </summary>
        /// <param name="parameters">The parameters to retreive the value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is found. Otherwise, null.</returns>
        public static decimal? GetDecimalValue(IDictionary<string, string> parameters, string paramName)
        {
            var value = GetValue(parameters, paramName);
            return ParseDecimalValue(value, paramName);
        }

        /// <summary>
        /// Gets the date time value.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is found. Otherwise, null.</returns>
        public static DateTime? GetDateTimeValue(IDictionary<string, string> parameters, string paramName)
        {
            var value = GetValue(parameters, paramName);
            return ParseDateTimeValue(value, paramName);
        }

        /// <summary>
        /// Gets the enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters to retreive the value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Enum value if it is found. Otherwise, null.</returns>
        public static T GetEnumValue<T>(IDictionary<string, string> parameters, string paramName)
        {
            var value = GetValue(parameters, paramName);
            return ParseEnumValue<T>(value, paramName);
        }

        ///////////////////////////////////////////////////////////////////
        //// Utility methods
        ///////////////////////////////////////////////////////////////////

        /// <summary>
        /// Parses the integer value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is converted. Otherwise, null.</returns>
        /// <exception cref="System.InvalidCastException">When the value isn't a valid integer value.</exception>
        private static int? ParseIntegerValue(string value, string paramName)
        {
            try
            {
                return int.Parse(value);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format(PayUSdkMessages.InvalidInteger, paramName), e);
            }
        }

        /// <summary>
        /// Parses the boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is converted. Otherwise, null.</returns>
        /// <exception cref="System.InvalidCastException">When the value isn't a valid boolean value.</exception>
        private static bool? ParseBooleanValue(string value, string paramName)
        {
            try
            {
                return bool.Parse(value);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format(PayUSdkMessages.InvalidBool, paramName), e);
            }
        }

        /// <summary>
        /// Parses the decimal value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is converted. Otherwise, null.</returns>
        /// <exception cref="System.InvalidCastException">When the value isn't a valid decimal value.</exception>
        private static decimal? ParseDecimalValue(string value, string paramName)
        {
            try
            {
                return decimal.Parse(value);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format(PayUSdkMessages.InvalidDecimal, paramName), e);
            }
        }

        /// <summary>
        /// Parses the date time value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is converted. Otherwise, null.</returns>
        /// <exception cref="System.InvalidCastException">When the value isn't a valid DateTime value</exception>
        private static DateTime? ParseDateTimeValue(string value, string paramName)
        {
            try
            {
                return DateTime.Parse(value, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format(PayUSdkMessages.InvalidDate, paramName), e);
            }
        }

        /// <summary>
        /// Parses the enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="paramName">Name of the parameter.</param>
        /// <returns>Value if it is converted. Otherwise, null.</returns>
        /// <exception cref="System.InvalidCastException">When the value isn't a valid enum value.</exception>
        private static T ParseEnumValue<T>(string value, string paramName)
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException(string.Format(PayUSdkMessages.EnumIsNull, paramName));
            }
            catch (Exception e)
            {
                throw new InvalidCastException(string.Format(PayUSdkMessages.InvalidEnum, paramName), e);
            }
        }
    }
}

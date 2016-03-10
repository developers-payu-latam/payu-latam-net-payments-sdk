namespace PayuNetSdk.Tests.PayU.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using System.Globalization;

    public class FormatTest
    {
        /// <summary>
        /// Formats the decimal test.
        /// </summary>
        [Test]
        public void FormatDecimalTest()
        {

            decimal val1;

            string format = "{0:0.00}";

            val1 = 100;
            Assert.AreEqual("100.00", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.00M;
            Assert.AreEqual("100.00", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.5M;
            Assert.AreEqual("100.50", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.501M;
            Assert.AreEqual("100.50", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.49M;
            Assert.AreEqual("100.49", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.51M;
            Assert.AreEqual("100.51", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.99M;
            Assert.AreEqual("100.99", String.Format(CultureInfo.InvariantCulture, format, val1));

            val1 = 100.01M;
            Assert.AreEqual("100.01", String.Format(CultureInfo.InvariantCulture, format, val1));

            // TODO Confirmar
            val1 = 100.499M;
            Assert.AreEqual("100.50", String.Format(CultureInfo.InvariantCulture, format, val1));

            // TODO Confirmar
            val1 = 100.495M;
            Assert.AreEqual("100.50", String.Format(CultureInfo.InvariantCulture, format, val1));

            // TODO Confirmar
            val1 = 100.494M;
            Assert.AreEqual("100.49", String.Format(CultureInfo.InvariantCulture, format, val1));

        }

        /// <summary>
        /// Formats the date test.
        /// </summary>
        [Test]
        public void FormatDateTest()
        {
            DateTime val1 = DateTime.Now;

            string format = "{0:s}";  // SortableDateTime

            // '1982-06-13T14:45:00' :P
            string expected = string.Format("{0}-{1:d2}-{2:d2}T{3:d2}:{4:d2}:{5:d2}",
                val1.Year, val1.Month, val1.Day, val1.Hour, val1.Minute, val1.Second);

            Assert.AreEqual(expected, String.Format(CultureInfo.InvariantCulture, format, val1));
        }
    }
}

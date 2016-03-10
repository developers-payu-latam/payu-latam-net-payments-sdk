// <copyright file="Address.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Model.Personal
{
    using System.Xml.Serialization;

    /// <summary>
    /// Represents an address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the street1.
        /// </summary>
        /// <value>
        /// The street1.
        /// </value>
        [XmlElement("street1")]
        public string Street1 { get; set; }

        /// <summary>
        /// Gets or sets the street2.
        /// </summary>
        /// <value>
        /// The street2.
        /// </value>
        [XmlElement("street2")]
        public string Street2 { get; set; }

        /// <summary>
        /// Gets or sets the street3.
        /// </summary>
        /// <value>
        /// The street3.
        /// </value>
        [XmlElement("street3")]
        public string Street3 { get; set; }

        /// <summary>
        /// Gets or sets the line1.
        /// </summary>
        /// <value>
        /// The line1.
        /// </value>
        [XmlElement("line1")]
        public string Line1 { get; set; }

        /// <summary>
        /// Gets or sets the line2.
        /// </summary>
        /// <value>
        /// The line2.
        /// </value>
        [XmlElement("line2")]
        public string Line2 { get; set; }

        /// <summary>
        /// Gets or sets the line3.
        /// </summary>
        /// <value>
        /// The line3.
        /// </value>
        [XmlElement("line3")]
        public string Line3 { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        [XmlElement("city")]
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        [XmlElement("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        [XmlElement("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        /// <value>
        /// The postal code.
        /// </value>
        [XmlElement("postalCode")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        [XmlElement("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" }, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Address o = obj as Address;
            if ((System.Object)o == null)
            {
                return false;
            }
            return object.Equals(Street1, o.Street1) &&
                   object.Equals(Street2, o.Street2) &&
                   object.Equals(Street3, o.Street3) &&
                   object.Equals(City, o.City) &&
                   object.Equals(State, o.State) &&
                   object.Equals(Country, o.Country) &&
                   object.Equals(PostalCode, o.PostalCode) &&
                   object.Equals(Phone, o.Phone);

        }
    }
}

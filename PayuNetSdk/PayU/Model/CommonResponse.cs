using System.Collections.Generic;
using System.Xml.Serialization;

namespace PayuNetSdk.PayU.Model
{
    [XmlRoot("response")]
    public class CommonResponse
    {
        /// <summary>
        /// The error description message
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [XmlIgnore]
        public SdkError Error { get; set; }
    }
}

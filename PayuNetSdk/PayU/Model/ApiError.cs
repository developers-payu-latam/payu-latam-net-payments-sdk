using System.Collections.Generic;
using System.Xml.Serialization;
using PayuNetSdk.PayU.Messages.Enums;

namespace PayuNetSdk.PayU.Model
{
    [XmlRoot("error")]
    public class SdkError
    {
        /// <summary>
        /// The error type
        /// </summary>
        [XmlElement("type")]
        public ErrorType? ErrorType { get; set; }
        public bool ShouldSerializeErrorType() { return ErrorType.HasValue; }

        /// <summary>
        /// The error description message
        /// </summary>
        [XmlElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// The list containing a detailed description of errors
        /// </summary>
        [XmlArray("errors")]
        [XmlArrayItem("description")]
        public List<string> ErrorList { get; set; }
    }
}

// <copyright file="DataConverter.cs" company="PayU Latam">
//    
// </copyright>

namespace PayuNetSdk.PayU.Util.DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using PayuNetSdk.PayU.Messages.Enums;
    using PayuNetSdk.PayU.Model;

    /// <summary>
    /// Thanks to http://www.codeproject.com/Articles/141955/Both-XML-and-Binary-Serializable-Dictionary
    /// 
    /// Dictionary by default is not XML serializable.To make it XML serializable with XML serializer, 
    /// we need to implement IXmlSerialiable. But also derived class of Dictionary is not Binary deserializable so here 
    /// I have given a solution with a Dictionary which is both XML and binary serializable
    /// 
    /// </summary>
    /// <typeparam name="KT">The type of the t.</typeparam>
    /// <typeparam name="VT">The type of the t.</typeparam>
    [Serializable]
    public class SerializableDictionary<KT, VT> : Dictionary<KT, VT>, IXmlSerializable
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableDictionary{KT, VT}"/> class.
        /// </summary>
        /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> object containing the information 
        /// required to serialize the <see cref="T:System.Collections.Generic.Dictionary`2"></see>.</param>
        /// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext"></see> structure containing the source 
        /// and destination of the serialized stream associated with the <see cref="T:System.Collections.Generic.Dictionary`2"></see>.</param>
        public SerializableDictionary(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableDictionary{KT, VT}"/> class.
        /// </summary>
        public SerializableDictionary() { }

        /// <summary>
        /// Este método se reserva y no debe utilizarse. Al implementar la interfaz IXmlSerializable, debe devolver 
        /// null (Nothing en Visual Basic) desde este método y, en su lugar, si se requiere especificar un esquema personalizado, 
        /// aplique <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute" /> a la clase.
        /// </summary>
        /// <returns>
        /// Una clase <see cref="T:System.Xml.Schema.XmlSchema" /> que describe la representación XML del objeto 
        /// producido por el método <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)" /> y
        /// utilizado por el método <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)" />.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return (null);
        }

        /// <summary>
        /// Genera un objeto a partir de su representación XML.
        /// </summary>
        /// <param name="reader">Secuencia de <see cref="T:System.Xml.XmlReader" /> desde la que se deserializa el objeto.</param>
        public void ReadXml(XmlReader reader)
        {
            Boolean wasEmpty = reader.IsEmptyElement;

            reader.Read();

            if (wasEmpty)
            {
                return;
            }

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                KT key;
                if (reader.Name == "entry")
                {
                    reader.Read();
                    Type keytype = reader.ValueType;
                    object obj = null;
                    if (keytype != null)
                    {
                        key = (KT)new XmlSerializer(keytype).Deserialize(reader);
                        Type valuetype = reader.ValueType;

                        if (valuetype != null)
                        {
                            if ("additionalvalue".ToLower().Equals(reader.Name.ToLower()))
                            {
                                obj = new AdditionalValue();

                                reader.Read();
                                reader.Read();
                                ((AdditionalValue)obj).Value = reader.ReadContentAsDecimal();
                                reader.Read();
                                reader.Read();
                                ((AdditionalValue)obj).Currency = (Currency)Enum.Parse(typeof(Currency), reader.Value);
                                reader.Read();
                                reader.ReadEndElement();
                            }
                            else
                            {
                                reader.Read();
                                obj = reader.ReadContentAsObject();
                            }

                            VT value = (VT)obj;
                            Add(key, value);
                            reader.ReadEndElement();
                        }
                        else
                        {
                            Add(key, default(VT));
                            reader.Skip();
                        }
                    }
                    
                    /*if (obj.GetType() != typeof(AdditionalValue))
                    {
                        
                        
                    }*/
                    reader.ReadEndElement();
                    reader.MoveToContent();
                }
            }

            reader.ReadEndElement();
        }

        /// <summary>
        /// Convierte un objeto en su representación XML.
        /// </summary>
        /// <param name="writer">Secuencia de <see cref="T:System.Xml.XmlWriter" /> para la que se serializa el objeto.</param>
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            for (int i = 0; i < Keys.Count; i++)
            {
                KT key = Keys.ElementAt(i);
                VT value = this.ElementAt(i).Value;
                //create <entry>
                writer.WriteStartElement("entry");
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                new XmlSerializer(key.GetType()).Serialize(writer, key, ns);
                if (value != null)
                {
                    new XmlSerializer(value.GetType()).Serialize(writer, value, ns);
                }
                writer.WriteEndElement();
            }
        }
    }
}

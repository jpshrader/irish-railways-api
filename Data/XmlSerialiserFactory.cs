using irish_railways_api.Data.Stations;
using System;
using System.Linq;
using System.Xml.Serialization;

namespace irish_railways_api.Data {
    public class XmlSerialiserFactory {
        public XmlSerializer GetXmlSerialiser<T>() {
            var xmlSerialiserType = typeof(T).Assembly.GetTypes()
                    .Single(t => t.GetInterfaces().Contains(typeof(IXmlNode<T>)));

            return new XmlSerializer(xmlSerialiserType);
        }
    }
}

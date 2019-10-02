using irish_railways_api.Models;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace irish_railways_api.Data {
    public class XmlSerialiserFactory {
        public XmlSerializer GetXmlSerialiser(Type type) {
            if (type == typeof(Station)) {
                return new XmlSerializer(typeof(StationList));
            }

            throw new KeyNotFoundException();
        }
    }

    //TDOD: Organise this better
    [XmlRoot("ArrayOfObjStation", Namespace = "http://api.irishrail.ie/realtime/")]
    public class StationList : IApiList<Station> {
        [XmlElement("objStation")]
        public Station[] Items { get; set; }
    }

    //TDOD: Better name
    public interface IApiList<T> {
        T[] Items { get; set; }
    }
}

﻿using irish_railways_api.Controllers.Trains.Models;
using System.Xml.Serialization;

namespace irish_railways_api.Data.Trains {
    [XmlRoot("ArrayOfObjTrainPositions", Namespace = "http://api.irishrail.ie/realtime/")]
    public class TrainList : IXmlNode<Train> {
        [XmlElement("objTrainPositions")]
        public Train[] Items { get; set; }
    }
}

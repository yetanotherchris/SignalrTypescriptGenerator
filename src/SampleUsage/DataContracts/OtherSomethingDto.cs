using System;
using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public class OtherSomethingDto
    {
        [DataMember]
        public string Property1 { get; set; }

        [DataMember]
        public DateTime Property2 { get; set; }

        [DataMember]
        public InnerSomethingDto Property3 { get; set; }

        [DataMember]
        public InnerSomethingDto Property4 { get; set; }
    }
}
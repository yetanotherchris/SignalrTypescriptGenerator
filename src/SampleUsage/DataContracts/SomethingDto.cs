using System;
using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public class SomethingDto
    {
        [DataMember]
        public string Property1 { get; set; }

        [DataMember]
        public Guid Property2 { get; set; }

        [DataMember]
        public InnerSomethingDto Property3 { get; set; }
    }
}
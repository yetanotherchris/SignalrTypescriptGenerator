using System;
using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public class SomethingDto
    {
        [DataMember(Name = "iChangedTheName")]
        public string Property1 { get; set; }

        [DataMember]
        public Guid Property2 { get; set; }

        [DataMember]
        public InnerSomethingDto Property3 { get; set; }
    }
}
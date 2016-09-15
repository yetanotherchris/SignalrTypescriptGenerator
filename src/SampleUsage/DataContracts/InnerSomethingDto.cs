using System;
using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public class InnerSomethingDto
    {
        [DataMember]
        public int InnerProperty1 { get; set; }

        [DataMember]
        public DateTime InnerProperty2 { get; set; }

        [DataMember]
        public SomethingEnum InnerProperty3 { get; set; }
    }
}
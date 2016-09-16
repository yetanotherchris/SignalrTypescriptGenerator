using System;
using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public class InnerSomethingDto
    {
        [DataMember]
        public int InnerProperty1 { get; set; }

        [DataMember(Name = "innerProperty2")]
        public DateTime InnerProperty2 { get; set; }

        [DataMember(Name = "innerProperty3WithCrazyCustomName")]
        public SomethingEnum InnerProperty3 { get; set; }
    }
}
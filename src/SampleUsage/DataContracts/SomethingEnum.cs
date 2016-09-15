using System.Runtime.Serialization;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.SampleUsage.DataContracts
{
    [DataContract]
    public enum SomethingEnum
    {
        [EnumMember]
        One,
        [EnumMember]
        Two,
        [EnumMember]
        Three,
    }
}
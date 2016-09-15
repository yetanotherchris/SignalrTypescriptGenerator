using System.Collections.Generic;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.Models
{
	public class DataContractInfo
	{
		public string ModuleName { get; }
		public string InterfaceName { get; }
		public List<TypeInfo> Properties { get; }

	    public DataContractInfo(string moduleName, string interfaceName, List<TypeInfo> properties)
	    {
	        ModuleName = moduleName;
	        InterfaceName = interfaceName;
	        Properties = properties;
	    }

	    public override string ToString()
        {
            return $"ModuleName:{ModuleName},InterfaceName:{InterfaceName};Properties:[{string.Join(",", Properties)}]";
        }
    }
}
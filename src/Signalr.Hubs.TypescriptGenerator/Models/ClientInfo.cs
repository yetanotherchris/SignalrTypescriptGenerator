using System.Collections.Generic;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.Models
{
	public class ClientInfo
	{
		public string ModuleName { get; }
		public string InterfaceName { get; }
		public List<FunctionDetails> FunctionDetails { get; }

	    public ClientInfo(string moduleName, string interfaceName, List<FunctionDetails> functionDetails)
	    {
	        ModuleName = moduleName;
	        InterfaceName = interfaceName;
	        FunctionDetails = functionDetails;
	    }

	    public override string ToString()
	    {
	        return $"ModuleName:{ModuleName},InterfaceName:{InterfaceName}";
	    }
	}
}
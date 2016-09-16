using System.Collections.Generic;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.Models
{
	public class ServiceInfo
	{
		public string ModuleName { get; }
		public string InterfaceName { get; }
		public string ClientType { get; }

		public string ServerType { get; }
		public string ServerTypeFullNamespace { get; }
		public List<FunctionDetails> ServerFunctions { get; }

	    public ServiceInfo(string moduleName, string interfaceName, string clientType, string serverType, string serverTypeFullNamespace, List<FunctionDetails> serverFunctions)
	    {
	        ModuleName = moduleName;
	        InterfaceName = interfaceName;
	        ClientType = clientType;
	        ServerType = serverType;
	        ServerTypeFullNamespace = serverTypeFullNamespace;
	        ServerFunctions = serverFunctions;
	    }

	    public override string ToString()
        {
            return $"ModuleName:{ModuleName},InterfaceName:{InterfaceName},ClientType:{ClientType}";
        }
    }
}
using System.Collections.Generic;

namespace SignalrTypescriptGenerator.Models
{
	public class ServiceInfo
	{
		public string ModuleName { get; set; }
		public string InterfaceName { get; set; }
		public string ClientType { get; set; }

		public string ServerType { get; set; }
		public string ServerTypeFullNamespace { get; set; }
		public List<FunctionDetails> ServerFunctions { get; set; }

		public ServiceInfo()
		{
			ServerFunctions = new List<FunctionDetails>();
		}
	}
}
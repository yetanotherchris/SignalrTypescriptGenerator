using System.Collections.Generic;

namespace SignalrTypescriptGenerator.Models
{
	public class DataContractInfo
	{
		public string ModuleName { get; set; }
		public string InterfaceName { get; set; }
		public List<TypeInfo> Properties { get; set; }

		public DataContractInfo()
		{
			Properties = new List<TypeInfo>();
		}
	}
}
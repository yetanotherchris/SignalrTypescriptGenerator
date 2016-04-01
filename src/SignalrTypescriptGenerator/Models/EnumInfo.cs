using System.Collections.Generic;

namespace SignalrTypescriptGenerator.Models
{
	public class EnumInfo
	{
		public string ModuleName { get; set; }
		public string InterfaceName { get; set; }
		public List<TypeInfo> Properties { get; set; }

		public EnumInfo()
		{
			Properties = new List<TypeInfo>();
		}
	}
}
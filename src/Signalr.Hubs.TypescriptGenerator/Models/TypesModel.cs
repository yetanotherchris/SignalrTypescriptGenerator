using System;
using System.Collections.Generic;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.Models
{
	public class TypesModel
	{
		public List<TypeInfo> Hubs { get; }
		public List<ServiceInfo> ServiceContracts { get; }
		public List<ClientInfo> Clients { get; }
		public List<DataContractInfo> DataContracts { get; }
		public List<EnumInfo> Enums { get; }

        public DateTime LastGenerated => DateTime.UtcNow;

	    public TypesModel(List<TypeInfo> hubs, List<ServiceInfo> serviceContracts, List<ClientInfo> clients, List<DataContractInfo> dataContracts, List<EnumInfo> enums)
	    {
	        Hubs = hubs;
	        ServiceContracts = serviceContracts;
	        Clients = clients;
	        DataContracts = dataContracts;
	        Enums = enums;
	    }
	}
}
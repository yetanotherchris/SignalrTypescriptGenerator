using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalrTypescriptGenerator.Models;
using TypeInfo = SignalrTypescriptGenerator.Models.TypeInfo;

namespace SignalrTypescriptGenerator
{
	internal class SignalrHubinator
	{
		private static string _assemblyRootFolder;
		private readonly TypeHelper _typeHelper;
		private DefaultHubManager _hubmanager;

		public SignalrHubinator(string assemblyPath)
		{
			_assemblyRootFolder = Path.GetDirectoryName(assemblyPath);
			LoadAssemblyIntoAppDomain(assemblyPath);

			_typeHelper = new TypeHelper();

			var defaultDependencyResolver = new DefaultDependencyResolver();
			_hubmanager = new DefaultHubManager(defaultDependencyResolver);
		}

		public TypeHelper TypeHelper
		{
			get { return _typeHelper; }
		}

		private static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
		{
			string assemblyPath = Path.Combine(_assemblyRootFolder, new AssemblyName(args.Name).Name + ".dll");
			if (File.Exists(assemblyPath) == false)
				return null;

			Assembly assembly = Assembly.LoadFrom(assemblyPath);
			return assembly;
		}

		private void LoadAssemblyIntoAppDomain(string assemblyPath)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += new ResolveEventHandler(LoadFromSameFolder);
			Assembly.LoadFile(assemblyPath);
		}

		public List<TypeInfo> GetHubs()
		{
			var items = new List<TypeInfo>();
			foreach (var hub in _hubmanager.GetHubs())
			{
				string name = hub.NameSpecified ? hub.Name : _typeHelper.FirstCharLowered(hub.Name);
				string typename = hub.HubType.FullName;

				items.Add(new TypeInfo() { Name = name, TypescriptType = typename });
			}

			return items;
		}

		public List<ServiceInfo> GetServiceContracts()
		{
			var list = new List<ServiceInfo>();
			var serviceInfo = new ServiceInfo();

			foreach (var hub in _hubmanager.GetHubs())
			{
				Type hubType = hub.HubType;

				string moduleName = hubType.Namespace;
				string interfaceName = hubType.Name;
				string server = hubType.FullName + "Server";

				Type clientType = TypeHelper.ClientType(hubType);
				string clientTypeName = clientType != null ? clientType.FullName : "any";

				serviceInfo.ModuleName = moduleName;
				serviceInfo.InterfaceName = interfaceName;
				serviceInfo.ServerType = server;
				serviceInfo.ClientType = clientTypeName;

				serviceInfo.FunctionDetails = TypeHelper.GetFunctions(hubType);
				list.Add(serviceInfo);
			}

			return list;
		}

		public List<ClientInfo> GetClients()
		{
			var list = new List<ClientInfo>();

			foreach (var hub in _hubmanager.GetHubs())
			{
				Type hubType = hub.HubType;
				Type clientType = TypeHelper.ClientType(hubType);

				if (clientType != null)
				{
					string moduleName = clientType.Namespace;
					string interfaceName = clientType.Name;
					var clientInfo = new ClientInfo();

					clientInfo.ModuleName = moduleName;
					clientInfo.InterfaceName = interfaceName;
					clientInfo.FunctionDetails = TypeHelper.GetFunctions(hubType);
					list.Add(clientInfo);
				}
			}

			return list;
		}

		public List<DataContractInfo> GetDataContracts()
		{
			var list = new List<DataContractInfo>();

			while (_typeHelper.InterfaceTypes.Count != 0)
			{
				var type = _typeHelper.InterfaceTypes.Pop();
				var dataContractInfo = new DataContractInfo();

				string moduleName = type.Namespace;
				string interfaceName = _typeHelper.GenericSpecificName(type, false);

				dataContractInfo.ModuleName = moduleName;
				dataContractInfo.InterfaceName = interfaceName;

				foreach (var property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
				{
					string propertyName = property.Name;
					string typeName = _typeHelper.GetTypeContractName(property.PropertyType);

					dataContractInfo.Properties.Add(new TypeInfo() { Name = propertyName, TypescriptType = typeName });
				}

				list.Add(dataContractInfo);
			}

			return list;
		}

		public List<EnumInfo> GetEnums()
		{
			var list = new List<EnumInfo>();

			while (_typeHelper.EnumTypes.Count != 0)
			{
				var type = _typeHelper.EnumTypes.Pop();
				var enuminfo = new EnumInfo();

				string moduleName = type.Namespace;
				string interfaceName = _typeHelper.GenericSpecificName(type, false);

				enuminfo.ModuleName = moduleName;
				enuminfo.InterfaceName = interfaceName;

				foreach (string name in Enum.GetNames(type))
				{
					string propertyName = name;
					string typeName = string.Format("{0:D}", Enum.Parse(type, name));

					enuminfo.Properties.Add(new TypeInfo() { Name = propertyName, TypescriptType = typeName });
				}

				list.Add(enuminfo);
			}

			return list;
		}
	}
}
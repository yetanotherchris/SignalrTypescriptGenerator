using GeniusSports.Signalr.Hubs.TypeScriptGenerator.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypeInfo = GeniusSports.Signalr.Hubs.TypeScriptGenerator.Models.TypeInfo;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.Helpers
{
    internal class HubHelper
    {
        private readonly DefaultHubManager hubmanager;
        private readonly TypeHelper typeHelper;

        public HubHelper()
        {
            typeHelper = new TypeHelper();

            var defaultDependencyResolver = new DefaultDependencyResolver();
            hubmanager = new DefaultHubManager(defaultDependencyResolver);
        }

        public List<TypeInfo> GetHubs()
        {
            return hubmanager
                .GetHubs()
                .Select(hub => new TypeInfo(name: hub.NameSpecified ? hub.Name : typeHelper.FirstCharLowered(hub.Name), typescriptType: hub.HubType.FullName))
                .ToList();
        }

        public List<ServiceInfo> GetServiceContracts()
        {
            var list = new List<ServiceInfo>();

            foreach (var hub in hubmanager.GetHubs())
            {
                var hubMethods = hubmanager
                    .GetHubMethods(hub.Name)
                    .Select(method =>
                    {
                        var methodParametersString = method.Parameters.Select(x => x.Name + " : " + typeHelper.GetTypeContractName(x.ParameterType));
                        return new FunctionDetails(
                            name: typeHelper.FirstCharLowered(method.Name),
                            arguments: $"({string.Join(", ", methodParametersString)})",
                            returnType: $"JQueryPromise<{typeHelper.GetTypeContractName(method.ReturnType)}>");
                    })
                    .ToList();

                var hubType = hub.HubType;
                var clientType = typeHelper.ClientType(hubType);
                list.Add(new ServiceInfo(
                    moduleName: hubType.Namespace,
                    interfaceName: hubType.Name,
                    clientType: clientType != null ? clientType.FullName : "any",
                    serverType: hubType.Name + "Server",
                    serverTypeFullNamespace: hubType.FullName + "Server",
                    serverFunctions: hubMethods));
            }

            return list;
        }

        public List<ClientInfo> GetClients()
        {
            var list = new List<ClientInfo>();

            foreach (var hub in hubmanager.GetHubs())
            {
                var hubType = hub.HubType;
                var clientType = typeHelper.ClientType(hubType);

                if (clientType != null)
                {
                    list.Add(new ClientInfo(moduleName: clientType.Namespace, interfaceName: clientType.Name, functionDetails: typeHelper.GetClientFunctions(hubType)));
                }
            }

            return list;
        }

        public List<DataContractInfo> GetDataContracts()
        {
            var list = new List<DataContractInfo>();

            while (typeHelper.InterfaceTypes.Count != 0)
            {
                var type = typeHelper.InterfaceTypes.Pop();

                var properties = type
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Select(prop => new TypeInfo(name: typeHelper.GetPropertyName(prop), typescriptType: typeHelper.GetTypeContractName(prop.PropertyType)))
                    .ToList();

                list.Add(new DataContractInfo(moduleName: type.Namespace, interfaceName: typeHelper.GenericSpecificName(type, false), properties: properties));
            }

            return list;
        }

        public List<EnumInfo> GetEnums()
        {
            var list = new List<EnumInfo>();

            while (typeHelper.EnumTypes.Count != 0)
            {
                var type = typeHelper.EnumTypes.Pop();

                var enumProperties =
                    Enum.GetNames(type)
                        .Select(propertyName => new TypeInfo(name: propertyName, typescriptType: $"{Enum.Parse(type, propertyName):D}"))
                        .ToList();

                list.Add(new EnumInfo(moduleName: type.Namespace, interfaceName: typeHelper.GenericSpecificName(type, false), properties: enumProperties));
            }

            return list;
        }
    }
}
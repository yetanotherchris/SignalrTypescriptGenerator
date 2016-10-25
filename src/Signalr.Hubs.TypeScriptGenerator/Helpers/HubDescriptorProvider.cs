using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.Helpers
{
    public class HubDescriptorProvider : IHubDescriptorProvider
    {
        private readonly IDependencyResolver resolver;

        public HubDescriptorProvider(IDependencyResolver resolver)
        {
            this.resolver = resolver;
        }

        public IList<HubDescriptor> GetHubs()
        {
            return GetHubsInternal().Values.ToList();
        }

        private IDictionary<string, HubDescriptor> GetHubsInternal()
        {
            // Getting all IHub-implementing types that apply
            var assemblyLocator = (IAssemblyLocator)resolver.GetService(typeof(IAssemblyLocator));
            var types = assemblyLocator.GetAssemblies()
                .SelectMany(GetTypesSafe)
                .Where(IsHubType)
                .ToList();

            // Building cache entries for each descriptor
            // Each descriptor is stored in dictionary under a key
            // that is it's name or the name provided by an attribute
            var hubDescriptors = types
                .Select(type => new HubDescriptor
                {
                    NameSpecified = (type.GetHubAttributeName() != null),
                    Name = type.GetHubName(),
                    HubType = type
                });

            var cacheEntries = new Dictionary<string, HubDescriptor>(StringComparer.OrdinalIgnoreCase);

            foreach (var descriptor in hubDescriptors)
            {
                HubDescriptor oldDescriptor = null;
                if (!cacheEntries.TryGetValue(descriptor.Name, out oldDescriptor))
                {
                    cacheEntries[descriptor.Name] = descriptor;
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            return cacheEntries;
        }

        public bool TryGetHub(string hubName, out HubDescriptor descriptor)
        {
            return GetHubsInternal().TryGetValue(hubName, out descriptor);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "If we throw then it's not a hub type")]
        private static bool IsHubType(Type type)
        {
            try
            {
                return typeof(Hub).IsAssignableFrom(type) &&
                       !type.IsAbstract &&
                       (type.Attributes.HasFlag(TypeAttributes.Public) ||
                        type.Attributes.HasFlag(TypeAttributes.NestedPublic));
            }
            catch
            {
                return false;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "If we throw then we have an empty type")]
        private IEnumerable<Type> GetTypesSafe(Assembly a)
        {
            try
            {
                return a.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(t => t != null);
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Type>();
            }
        }
    }

    internal static class HubTypeExtensions
    {
        internal static string GetHubName(this Type type)
        {
            if (!typeof(IHub).IsAssignableFrom(type))
            {
                return null;
            }

            return GetHubAttributeName(type) ?? GetHubTypeName(type);
        }

        internal static string GetHubAttributeName(this Type type)
        {
            if (!typeof(IHub).IsAssignableFrom(type))
            {
                return null;
            }

            // We can still return null if there is no attribute name
            return ReflectionHelper.GetAttributeValue<HubNameAttribute, string>(type, attr => attr.HubName);
        }

        private static string GetHubTypeName(Type type)
        {
            var lastIndexOfBacktick = type.Name.LastIndexOf('`');
            if (lastIndexOfBacktick == -1)
            {
                return type.Name;
            }
            else
            {
                return type.Name.Substring(0, lastIndexOfBacktick);
            }
        }
    }
}
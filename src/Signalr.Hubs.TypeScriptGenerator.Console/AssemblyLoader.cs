using System;
using System.IO;
using System.Reflection;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.Console
{
	internal class AssemblyLoader
	{
	    public void LoadAssemblyIntoAppDomain(string assemblyPath)
		{
			var currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += LoadFromSameFolder;
			Assembly.LoadFile(assemblyPath);
		}

	    private static Assembly LoadFromSameFolder(object sender, ResolveEventArgs args)
	    {
	        var directoryName = Path.GetDirectoryName(args.RequestingAssembly.Location);
	        var assemblyPath = Path.Combine(directoryName, new AssemblyName(args.Name).Name + ".dll");
	        if (!File.Exists(assemblyPath))
	        {
	            return null;
	        }

	        var assembly = Assembly.LoadFrom(assemblyPath);
	        return assembly;
	    }
	}
}
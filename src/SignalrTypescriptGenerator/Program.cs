using System;
using System.IO;
using System.Reflection;
using RazorEngine;
using RazorEngine.Templating;
using SignalrTypescriptGenerator.Models;

namespace SignalrTypescriptGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			var signalrHelper = new SignalrHubinator(@"C:\Code\syringe\src\Syringe.Service\bin\debug\Syringe.Service.exe");

			var model = new TypesModel();
			model.Hubs = signalrHelper.GetHubs();
			model.ServiceContracts = signalrHelper.GetServiceContracts();
			model.Clients = signalrHelper.GetClients();
			model.DataContracts = signalrHelper.GetDataContracts();
			model.Enums = signalrHelper.GetEnums();

			string template = ReadEmbeddedFile("template.cshtml");
			string result = Engine.Razor.RunCompile(template, "templateKey", null, model);

			Console.WriteLine(result);
		}

		static string ReadEmbeddedFile(string file)
		{
			string resourcePath = string.Format("{0}.{1}", typeof(Program).Namespace, file);

			Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
			if (stream == null)
				throw new InvalidOperationException(string.Format("Unable to find '{0}' as an embedded resource", resourcePath));

			string textContent = "";
			using (StreamReader reader = new StreamReader(stream))
			{
				textContent = reader.ReadToEnd();
			}

			return textContent;
		}
	}
}

using System;
using System.IO;
using System.Reflection;
using GeniusSports.Signalr.Hubs.TypescriptGenerator.Helpers;
using GeniusSports.Signalr.Hubs.TypescriptGenerator.Models;
using RazorEngine;
using RazorEngine.Templating;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator
{
    public class HubTypeScriptGenerator
    {
        public string Generate()
        {
            var model = GenerateTypeScriptModel();
            var template = ReadEmbeddedFile("template.cshtml");
            var outputText = Engine.Razor.RunCompile(template, "templateKey", null, model);
            return outputText;
        }

        private static TypesModel GenerateTypeScriptModel()
        {
            var signalrHelper = new HubHelper();
            return new TypesModel(
                hubs: signalrHelper.GetHubs(),
                serviceContracts: signalrHelper.GetServiceContracts(),
                clients: signalrHelper.GetClients(),
                dataContracts: signalrHelper.GetDataContracts(),
                enums: signalrHelper.GetEnums());
        }

        private static string ReadEmbeddedFile(string file)
        {
            string resourcePath = $"{typeof(HubTypeScriptGenerator).Namespace}.{file}";

            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath))
            {
                if (stream == null) throw new InvalidOperationException($"Unable to find '{resourcePath}' as an embedded resource");

                string textContent;
                using (var reader = new StreamReader(stream))
                {
                    textContent = reader.ReadToEnd();
                }

                return textContent;
            }
        }
    }
}
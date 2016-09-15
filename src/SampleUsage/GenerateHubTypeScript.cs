using NUnit.Framework;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.SampleUsage
{
    [TestFixture]
    public class GenerateHubTypeScript
    {
        [Test]
        public void Generate()
        {
            var hubTypeScriptGenerator = new HubTypeScriptGenerator();
            var typeScript = hubTypeScriptGenerator.Generate();
            System.Console.WriteLine(typeScript);
        }
    }
}
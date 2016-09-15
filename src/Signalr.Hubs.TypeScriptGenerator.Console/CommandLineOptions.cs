using CommandLine;
using CommandLine.Text;

namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.Console
{
	public class CommandLineOptions
	{
		[Option('a', "assembly", HelpText = "The path to the assembly (.dll/.exe)", Required = true)]
		public string AssemblyPath { get; set; }

		[Option('o', "outfile", HelpText = "The path to the file to generate. If this is empty, the output is written to stdout.")]
		public string OutFile { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this, current => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
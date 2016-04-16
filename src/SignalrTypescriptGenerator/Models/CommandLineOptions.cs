using CommandLine;

namespace SignalrTypescriptGenerator.Models
{
	public class CommandLineOptions
	{
		[Option('a', "assembly", HelpText = "The path to the assembly (.dll/.exe)", Required = true)]
		public string AssemblyPath { get; set; }

		[Option('o', "outfile", HelpText = "The path to the file to generate. If this is empty, the output is written to stdout.")]
		public string OutFile { get; set; }
	}
}
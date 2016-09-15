namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.Models
{
	public class FunctionDetails
	{
		public string Name { get; }
		public string Arguments { get; }
		public string ReturnType { get; }

	    public FunctionDetails(string name, string arguments, string returnType)
	    {
	        Name = name;
	        Arguments = arguments;
	        ReturnType = returnType;
	    }

	    public override string ToString()
        {
            return $"Name:{Name},Arguments:{Arguments};ReturnType:[{string.Join(",", ReturnType)}]";
        }
    }
}
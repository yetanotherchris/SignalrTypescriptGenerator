namespace GeniusSports.Signalr.Hubs.TypescriptGenerator.Models
{
	public class TypeInfo
	{
		public string Name { get; }
		public string TypescriptType { get; }

	    public TypeInfo(string name, string typescriptType)
	    {
	        Name = name;
	        TypescriptType = typescriptType;
	    }

	    public override string ToString()
        {
            return $"Name:{Name},TypescriptType:{TypescriptType}]";
        }
    }
}
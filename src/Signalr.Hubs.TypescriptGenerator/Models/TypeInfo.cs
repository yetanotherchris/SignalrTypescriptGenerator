namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.Models
{
	public class TypeInfo
	{
		public string Name { get; }
		public string TypeScriptType { get; }

	    public TypeInfo(string name, string typescriptType)
	    {
	        Name = name;
	        TypeScriptType = typescriptType;
	    }

	    public override string ToString()
        {
            return $"Name:{Name},TypeScriptType:{TypeScriptType}]";
        }
    }
}
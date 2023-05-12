using parser.data.model;

namespace parser;

public class ParserLog
{
    public readonly ParserSettings settings = new();

    private string path = "";
    private ParserImport import;
    private ViewOutput output;

    private ParserSessions sessions;

    public ParserShow show => settings.show;
    public string txt => output.txt;

    public ParserLog()
    {
        sessions = new ParserSessions();
        
        import = new ParserImport(this);
        output = new ViewOutput(this);
    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

}


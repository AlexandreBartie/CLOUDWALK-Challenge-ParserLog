using parser.data.model;
using parser.data.format;

namespace parser;

public class ParserLog : ViewData
{

    public readonly ParserSettings settings = new();

    private string path = "";
    private ParserImport import;
    private ViewOutput output;

    public ParserShow show => settings.show;

    public string txt => output.txt;


    public ParserLog()
    {
        import = new ParserImport(this);
        output = new ViewOutput(this);
    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

}


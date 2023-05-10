using parser.lib;

namespace parser;

public class ParserImport
{

    private ParserLog parser;

    public ParserImport(ParserLog parser)
    {
        this.parser = parser;
    }

    public bool Load(string path, string name)
    {

        var file = new FileTXT();

        if (file.Open(path, name))
        {
            parser.Populate(file.lines);

            return true;
        }

        return false;

    }



}
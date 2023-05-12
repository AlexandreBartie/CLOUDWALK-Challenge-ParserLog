namespace parser;

public class ParserLog
{
    public readonly ParserSettings settings = new();

    private string path = "";
    private ParserImport import;
    private ParserOutput output;

    public ParserSessions sessions;

    public ParserSession session => sessions.current;

    public ParserShow show => settings.show;
    public string txt => output.txt(sessions);

    public ParserLog()
    {
        sessions = new ParserSessions();

        import = new ParserImport(this);
        output = new ParserOutput(this);
    }

    public bool LoadFile(string name)
    {
        return import.Load(settings.GetInputFileFolder(path), name);
    }

    public void LoadLines(string[] lines)
    {
        sessions.Populate(lines); ;
    }

    public ParserSession data(int index) => sessions.GetSession(index);

}


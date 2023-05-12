using parser.core.log;
using parser.data.model;

namespace parser;

public class ParserSession : ViewData
{
    public string tag = "";

    public ParserSession() : base(new LogList()) {}

    public void SetTag(int order)
    { tag = string.Format("Game#${0}", order); }

}


public class ParserSessions : List<ParserSession>
{

    public ParserSession current = new();

    public LogList all => getAll();

    public bool isNull => (all.Count == 0);

    public void Populate(string[] lines)
    {
        LogRecord log;

        foreach (string line in lines)
        {

            if (string.IsNullOrWhiteSpace(line))
            {

                log = new LogRecord(line);

                if (log.isHeader)
                    addSession();

                addRecord(log);

            }

        }

    }

    private void addSession()
    {
        Add(new ParserSession());

        current = this.Last();
        
        current.SetTag(Count);

    }

    private void addRecord(LogRecord record)
    {
        current.logs.Add(record);
    }

    private LogList getAll()
    {

        var logs = new LogList();

        foreach (ParserSession session in this)
            logs.AddRange(session.logs);

        return logs;

    }

}
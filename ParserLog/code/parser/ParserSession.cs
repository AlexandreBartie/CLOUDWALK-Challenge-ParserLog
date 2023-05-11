using parser.core.log;

namespace parser;

public class ParserSession
{

    public LogList logs = new();

}


public class ParserSessions : List<ParserSession>
{

    private ParserSession? current;

    public LogList all => getAll();

    public bool isNull => (all.Count == 0);

    public void Populate(string[] lines)
    {
        LogRecord log;

        foreach (string line in lines)
        {

            if (line.Trim() != "")
            {

                log = new LogRecord(line);

                if (log.isHeader)
                    addHeader();

                addRecord(log);

            }


        }

    }

    private void addHeader()
    {
        current = new ParserSession();

        Add(current);
    }

    private void addRecord(LogRecord record)
    {
        current?.logs.Add(record);
    }

    private LogList getAll()
    {

        var logs = new LogList();
        foreach (ParserSession session in this)
            logs.AddRange(session.logs);

        return logs;

    }

}
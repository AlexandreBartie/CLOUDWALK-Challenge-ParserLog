using parser.data.log;

namespace parser;

public class ParserSession
{

    public LogList logs = new();

}


public class ParserSessions : List<ParserSession>
{

    private ParserSession? current;

    public LogList logs => getLogs();

    public bool isNull => (logs.Count == 0);

    public void Populate(string[] lines)
    {
        LogItem log;

        foreach (string line in lines)
        {

            if (line.Trim() != "")
            {

                log = new LogItem(line);

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

    private void addRecord(LogItem record)
    {
        current?.logs.Add(record);
    }

    private LogList getLogs()
    {

        var logs = new LogList();
        foreach (ParserSession session in this)
            logs.AddRange(session.logs);

        return logs;

    }

}
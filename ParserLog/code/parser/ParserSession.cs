using parser.core.log;

namespace parser;

public class ParserSession
{

    public RecordsLog logs = new();

}


public class ParserSessions : List<ParserSession>
{

    private ParserSession? current;

    public RecordsLog logs => getLogs();

    public bool isNull => (logs.Count == 0);

    public void Populate(string[] lines)
    {
        RecordLog log;

        foreach (string line in lines)
        {

            if (line.Trim() != "")
            {

                log = new RecordLog(line);

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

    private void addRecord(RecordLog record)
    {
        current?.logs.Add(record);
    }

    private RecordsLog getLogs()
    {

        var logs = new RecordsLog();
        foreach (ParserSession session in this)
        {
            logs.AddRange(session.logs);
        }

        return logs;

    }

}
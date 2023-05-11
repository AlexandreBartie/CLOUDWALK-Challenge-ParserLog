using parser.core.regex;
using parser.data.record;

namespace parser.data.log;

public class LogItem : RegexBase
{
    public bool isHeader => (type == LogType.eLogSession);

    public RecordWorldKillSomeone worldKillSomeone => GetWorldKillSomeone();

    public RecordPlayerKillSomeone playerKillSomeone => GetPlayerKillSomeone();

    public LogItem(string info) : base(info) { }

    private RecordWorldKillSomeone GetWorldKillSomeone()
    {

        var record = new RecordWorldKillSomeone(this);

        record.dead = GetParameter(2);
        record.cause = GetParameter(3);

        return record;

    }

    private RecordPlayerKillSomeone GetPlayerKillSomeone()
    {

        var record = new RecordPlayerKillSomeone(this);

        record.killer = GetParameter(2);
        record.dead = GetParameter(3);
        record.cause = GetParameter(4);

        return record;

    }

}

public class LogList : List<LogItem>
{

    public LogList filter(LogType type)
    {

        var logs = new LogList();

        foreach (LogItem log in this)
        {
            if (log.type == type)
                logs.Add(log);
        }

        return logs;
    }

}
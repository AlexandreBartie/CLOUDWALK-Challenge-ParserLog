using parser.core.regex;

namespace parser.data.log;

public class LogItem : RegexBase
{
    public bool isHeader => (type == LogType.eLogSession);

    public ILogWorldKillSomeone worldKillSomeone => GetWorldKillSomeone();

    public ILogPlayerKillSomeone playerKillSomeone => GetPlayerKillSomeone();

    public LogItem(string info) : base(info) { }

    private ILogWorldKillSomeone GetWorldKillSomeone()
    {

        var ILog = new ILogWorldKillSomeone(this);

        ILog.dead = GetParameter(2);
        ILog.cause = GetParameter(3);

        return ILog;

    }

    private ILogPlayerKillSomeone GetPlayerKillSomeone()
    {

        var ILog = new ILogPlayerKillSomeone(this);

        ILog.killer = GetParameter(2);
        ILog.dead = GetParameter(3);
        ILog.cause = GetParameter(4);

        return ILog;

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
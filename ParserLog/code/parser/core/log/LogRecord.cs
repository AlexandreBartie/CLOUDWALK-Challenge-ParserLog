using parser.core.regex;

namespace parser.core.log;

public class LogRecord : RegexBase
{
    public bool isHeader => (type == LogType.eLogSession);

    public ILogWorldKill worldKill => GetWorldKill();

    public ILogPlayerKill playerKill => GetPlayerKill();

    public LogRecord(string info) : base(info) { }

    private ILogWorldKill GetWorldKill()
    {

        var ILog = new ILogWorldKill(this);

        ILog.dead = GetParameter(2);
        ILog.cause = GetParameterFixed(3);

        return ILog;

    }

    private ILogPlayerKill GetPlayerKill()
    {

        var ILog = new ILogPlayerKill(this);

        ILog.killer = GetParameter(2);
        ILog.dead = GetParameter(3);
        ILog.cause = GetParameterFixed(4);

        return ILog;

    }

    private string GetParameterFixed(int index)
    { 
        string name = GetParameter(index);
        return name.Replace("MOD_", ""); 
    }

}

public class LogList : List<LogRecord>
{
    public int count => this.Count;

    public LogList filter(LogType type)
    {

        var logs = new LogList();

        foreach (LogRecord log in this)
        {
            if (log.type == type)
                logs.Add(log);
        }

        return logs;
    }

}
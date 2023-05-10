using parser.core.regex;

namespace parser.core.log;

public class RecordLog : BaseLog
{
    public bool isHeader => (type == TypeLog.eLogSession);

    public RecordLog(string info) : base(info) { }

    public ILogPlayerDead dataPlayerDead => regex.data.GetPlayerDead();

}

public class RecordsLog : List<RecordLog>
{

    public RecordsLog filter(TypeLog type)
    {

        var logs = new RecordsLog();

        foreach (RecordLog log in this)
        {
            if (log.type == type)
                logs.Add(log);
        }

        return logs;
    }

}
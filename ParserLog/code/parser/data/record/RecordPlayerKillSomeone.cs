using parser.data.log;

namespace parser.data.record;

public class RecordPlayerKillSomeone : ILogPlayerKillSomeone
{
    public readonly LogItem log;

    public RecordPlayerKillSomeone(LogItem log)
    {
        this.log = log;
    }

}
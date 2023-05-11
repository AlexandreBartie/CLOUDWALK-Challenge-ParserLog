

using parser.data.log;

namespace parser.data.record;

public class RecordWorldKillSomeone : ILogWorldKillSomeone
{
    public readonly LogItem log;

    public RecordWorldKillSomeone(LogItem log)
    {
        this.log = log;
    }

}
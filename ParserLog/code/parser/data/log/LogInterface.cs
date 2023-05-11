namespace parser.data.log;

public class ILogModel
{
    public readonly LogItem log;

    public ILogModel(LogItem log)
    {
        this.log = log;
    }
}

public class ILogWorldKillSomeone : ILogModel
{
    public string dead = "";
    public string cause = "";

    public ILogWorldKillSomeone(LogItem log) : base(log) {}

}

public class ILogPlayerKillSomeone : ILogModel
{

    public string killer = "";
    public string dead = "";
    public string cause = "";

    public ILogPlayerKillSomeone(LogItem log) : base(log) {}
}

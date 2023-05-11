namespace parser.data.log;

public class ILogKillSomeone : ILogModel
{
    public string dead = "";
    public string cause = "";

    public ILogKillSomeone(LogItem log) : base(log) {}

}

public class ILogWorldKillSomeone : ILogKillSomeone
{
    public ILogWorldKillSomeone(LogItem log) : base(log) {}
}

public class ILogPlayerKillSomeone : ILogKillSomeone
{

    public string killer = "";
    public ILogPlayerKillSomeone(LogItem log) : base(log) {}
}

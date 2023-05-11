namespace parser.core.log;

public class ILogKillSomeone : ILogModel
{
    public string dead = "";
    public string cause = "";

    public ILogKillSomeone(LogRecord log) : base(log) { }

}

public class ILogWorldKillSomeone : ILogKillSomeone
{
    public ILogWorldKillSomeone(LogRecord log) : base(log) { }
}

public class ILogPlayerKillSomeone : ILogKillSomeone
{

    public string killer = "";
    public ILogPlayerKillSomeone(LogRecord log) : base(log) { }
}

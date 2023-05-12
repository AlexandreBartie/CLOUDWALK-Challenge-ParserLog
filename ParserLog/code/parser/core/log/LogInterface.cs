namespace parser.core.log;

public class ILogKill : ILogModel
{
    public string dead = "";
    public string cause = "";

    public ILogKill(LogRecord log) : base(log) { }

}

public class ILogWorldKill : ILogKill
{
    public ILogWorldKill(LogRecord log) : base(log) { }
}

public class ILogPlayerKill : ILogKill
{

    public string killer = "";
    public ILogPlayerKill(LogRecord log) : base(log) { }
}

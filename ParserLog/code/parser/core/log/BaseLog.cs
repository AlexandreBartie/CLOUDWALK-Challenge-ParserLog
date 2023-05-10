using parser.core.regex;

namespace parser.core.log;

public class BaseLog
{
    public readonly string msg;
    public readonly string time;

    public readonly RegexLog regex;

    public TypeLog type
    {
        get { return regex.type; }
    }

    public BaseLog(string info)
    {
        InfoLog tag = new(info);

        this.msg = tag.msg;
        this.time = tag.time;
        this.regex = new RegexLog(msg, time);

    }

}


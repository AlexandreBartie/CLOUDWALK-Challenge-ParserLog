using parser.core.log;

namespace parser.core.regex;

public class RegexBase
{
    public readonly string msg;
    public readonly string time;

    protected readonly RegexLog regex;

    public LogType type
    {
        get { return regex.type; }
    }

    public RegexBase(string info)
    {
        RegexTime tag = new(info);

        this.msg = tag.msg;
        this.time = tag.time;

        this.regex = new RegexLog(msg);

    }

    protected string GetParameter(int index)
    {
        if (regex.match != null)
            return regex.match.Groups[index].Value;
        return "";
    }

}


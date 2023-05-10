using System.Text.RegularExpressions;

namespace parser.core.log;

public class InfoLog
{

    const string INFO_TIME = "HH:mm";
    const string REGEX_TIME = @"^([0-1][0-9]|[2][0-3]):([0-5][0-9])$";

    private string info;

    public string time => (hasTime) ? getTime() : "";

    public string msg => (hasTime) ? getMsg() : info;

    //check if represent a valid time
    public bool hasTime => (Regex.IsMatch(getTime(), REGEX_TIME));

    public InfoLog(string info)
    {
        this.info = info;
    }

    // extract time in string info
    private string getTime()
    {
        return info.Substring(0, INFO_TIME.Length);
    }

    // extract time in string info
    private string getMsg()
    {
        return info.Substring(INFO_TIME.Length + 1).Trim();
    }

}
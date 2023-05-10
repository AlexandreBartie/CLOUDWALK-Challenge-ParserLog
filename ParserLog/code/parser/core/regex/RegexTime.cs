using parser.lib;

namespace parser.core.log;

public class RegexTime
{

    const string REGEX_TIME = @"^(\d{1,2}:\d{2})\s(.*)$";

    public string time;
    public string msg;

    // private TextMatch log;

    public RegexTime(string info)
    {
        var log = new TextMatch(info, REGEX_TIME);

        time = log.IsMatch ? log.GetParameter(1) : "";
        msg = log.IsMatch ? log.GetParameter(2) : info;

    }

    // private void Setup(string info)
    // {



    // }

    // // extract time in string info
    // private string getTime()
    // {
    //     return info.Substring(0, INFO_TIME.Length);
    // }

    // // extract time in string info
    // private string getMsg()
    // {
    //     return info.Substring(INFO_TIME.Length + 1).Trim();
    // }

}
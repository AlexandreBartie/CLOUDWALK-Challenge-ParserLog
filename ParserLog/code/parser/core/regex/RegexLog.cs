using System.Text.RegularExpressions;
using parser.core.log;

namespace parser.core.regex;

public class RegexLog : RegexSettings
{

    private LogType _type;
    private Match? _match;

    public readonly string msg;

    public LogType type => _type;

    public Match? match => _match;

    public RegexLog(string msg)
    {

        this.msg = msg;

        GetLogTypeGame();

    }

    private void GetLogTypeGame()
    {

        _type = LogType.eLogUndefined;

        if (MatchLogType(LogType.eLogSession))
            return;

        if (MatchLogType(LogType.eLogWorldKill))
            return;

        if (MatchLogType(LogType.eLogPlayerKill))
            return;

    }

    private bool MatchLogType(LogType type)
    {

        var match = Regex.Match(msg, getPattern(type));

        if (match.Success)
        {
            _type = type;

            _match = match;

            return true;
        }

        return false;
    }

}
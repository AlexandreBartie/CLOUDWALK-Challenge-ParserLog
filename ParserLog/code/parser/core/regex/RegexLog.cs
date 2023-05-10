using System.Text.RegularExpressions;
using parser.core.log;

namespace parser.core.regex;

public class RegexLog : RegexSettings
{

    private TypeLog _type;
    private Match? _match;

    public readonly string msg ;

    public TypeLog type => _type;

    public Match? match => _match;

    public RegexData data;

    public RegexLog(string msg)
    {

        this.msg = msg;

        GetTypeLogGame();

        data = new RegexData(match);

    }

    private void GetTypeLogGame()
    {

        _type = TypeLog.eLogUndefined;

        if (MatchTypeLog(TypeLog.eLogSession))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerDead))
            return;

    }

    private bool MatchTypeLog(TypeLog type)
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
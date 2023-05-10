using System.Text.RegularExpressions;
using parser.core.log;
using parser.data.group;

namespace parser.core.regex;

public class RegexData
{
    private Match? match;

    public RegexData(Match? match)
    {
        this.match = match;
    }

    public ILogPlayerDead GetPlayerDead()
    {

        ILogPlayerDead data = new();

        data.killer = GetParameter(2);
        data.dead = GetParameter(3);
        data.cause = GetParameter(4);

        return data;

    }

    private string GetParameter(int index)
    {
        if (match != null)
            return match.Groups[index].Value;
        return "";
    }


}
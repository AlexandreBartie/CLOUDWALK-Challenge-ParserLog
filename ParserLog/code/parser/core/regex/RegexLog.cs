using System.Text.RegularExpressions;
using parser.core.log;

namespace parser.core.regex;

public class RegexLog : RegexSettings
{

    private string text = "";

    private TypeLog _type;
    private Match? _match;

    public TypeLog type => _type;

    public Match? match => _match;

    public RegexData data;

    public RegexLog(string msg, string time)
    {

        text = msg;

        if (time == "")
            GetTypeLogByNote();
        else
            GetTypeLogByGame();

        data = new RegexData(match);

    }

    private void GetTypeLogByNote()
    {

        _type = TypeLog.eLogNoteMessage;

        if (MatchTypeLog(TypeLog.eLogNoteSession))
            return;

    }

    private void GetTypeLogByGame()
    {

        _type = TypeLog.eLogMessage;

        if (MatchTypeLog(TypeLog.eLogPlayerHealedPower))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerLostPowerByUnknown))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerLostPowerByCreature))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerGainedExperience))
            return;

        if (MatchTypeLog(TypeLog.eLogPlayerLootedByCreature))
            return;

        if (MatchTypeLog(TypeLog.eLogCreatureHealedPower))
            return;

        if (MatchTypeLog(TypeLog.eLogCreatureLostPower))
            return;

    }

    private bool MatchTypeLog(TypeLog item)
    {

        var pattern = getPattern(item);

        var check = Regex.Match(text, pattern);

        if (check.Success)
        {
            _type = item;

            _match = check;

            return true;
        }

        return false;
    }

}
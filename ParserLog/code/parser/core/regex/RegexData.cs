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

    public ILogPlayerPoints GetPlayerPoints()
    {

        ILogPlayerPoints data = new();

        data.points = int.Parse(GetParameter(1));

        return data;

    }

    public ILogCreaturePoints GetCreaturePoints(TypeLog type)
    {
        int indCreature, indPoints;

        switch (type)
        {
            case TypeLog.eLogPlayerLostPowerByCreature:
                indCreature = 3; indPoints = 1; break;

            default:
                indCreature = 1; indPoints = 2; break;
        }

        ILogCreaturePoints data = new();

        data.creature = GetParameter(indCreature);
        data.points = int.Parse(GetParameter(indPoints));

        return data;

    }

    public ILogPlayerLooted GetPlayerLooted()
    {
        ILogPlayerLooted data = new();

        data.creature = GetParameter(1);
        data.list = new GroupLootList(GetParameter(2));

        return data;
    }

    private string GetParameter(int index)
    {
        if (match != null)
            return match.Groups[index].Value;
        return "";
    }


}
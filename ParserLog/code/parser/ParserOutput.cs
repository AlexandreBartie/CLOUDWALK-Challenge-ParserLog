using lib;

namespace parser;

public class ParserOutput
{

    private ParserLog parser;

    private ParserShow show => parser.show;

    public ParserOutput(ParserLog parser)
    {
        this.parser = parser;
    }

    public string txt(ParserSessions sessions)
    {

        var memo = new Memo();

        memo.add(parser.session.logTitle("Statistics"));

        foreach (ParserSession session in sessions)
            memo.add(getSessionTXT(session));

        memo.add(parser.session.logEnd("Statistics based by file log extracted"));

        return (memo.txt);

    }
    private string getSessionTXT(ParserSession session)
    {

        var memo = new Memo();

        memo.add(parser.session.logLine());
        memo.add($"Game: {session.order}");
        memo.add($"Total Kills: {session.totalKills}");
        memo.add($"  - byWorld: {session.WorldKill.count}");
        memo.add($" - byPlayer: {session.PlayerKill.count}");
        memo.add($"    Players: {session.players.txt}");
        memo.add($"    Players: {session.players.txt}");
        memo.add(parser.session.logLine());

        if (show.PlayerStatistics)
        {

            // memo.add(parser.PlayerKill.log("Kills"));

        }

        // if (parser.show.LootedItems)
        // {
        //     memo.add(parser.logTitle("Looted Items"));
        //     memo.add(parser.PlayerLootedByCreature.log("LootedByCreature"));
        // }

        // if (parser.show.CreatureStatistics)
        // {
        //     memo.add(parser.logTitle("Creature Statistics"));
        //     memo.add(parser.CreatureHealedPower.log("HealedPower"));
        //     memo.add(parser.CreatureLostPower.log("LostPower"));
        // }

        // if (parser.show.CreatureSpotlight)
        // {
        //     if (parser.CreatureSpotlight.HasCreatures)
        //     {
        //         memo.add(parser.logSubTitle("Creature Spotlight", parser.CreatureSpotlight.wildcard));
        //         memo.add(parser.logColumns());
        //         memo.add(parser.CreatureSpotlight.log());
        //     }
        // }

        return (memo.txt);

    }

}
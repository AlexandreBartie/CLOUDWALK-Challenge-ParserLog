using parser.lib;

namespace parser.data.format;

public class ViewOutput
{

    private ParserLog parser;

    public string txt => getTXT();

    public ViewOutput(ParserLog parser)
    {
        this.parser = parser;
    }
    private string getTXT()
    {

        var memo = new Memo();

        if (!parser.isNull)
        {

            if (parser.show.PlayerStatistics)
            {
                memo.add(parser.logTitle("Player Statistics"));
                memo.add(parser.PlayerDead.log("Kills"));

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

            memo.add(parser.logEnd("Statistics based by file log extracted"));

        }

        return (memo.txt);

    }


}
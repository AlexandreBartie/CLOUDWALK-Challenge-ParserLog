namespace parser.unit;

public class UT03_PlayerKillSomeoneTest
{

    private string input = "";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 100, 100)]
    [InlineData("Dono da Bola", 100, 100)]
    [InlineData("Zeh", 100, 100)]
    [InlineData("Assasinu Credi", 100, 100)]
    public void TST01_PlayerKillSomeone_ByDead(string player, int kill, int dead)
    {

        input = "PlayerKillSomeone.log";

        parser.LoadFile(input);

        Assert.Equal(kill, parser.PlayerKillSomeone.FilterByKiller(player).Count);
        Assert.Equal(dead, parser.PlayerKillSomeone.FilterByDead(player).Count);

    }

    // [Theory]
    // [InlineData(12, 332, 12)]
    // public void TST02_PlayerLostPower(int unknown, int total, int qty)
    // {

    //     input = "PlayerLostPower.txt";

    //     parser.LoadFile(input);

    //     Assert.Equal(unknown, parser.PlayerLostPower.byUnknown.totalDamage);
    //     Assert.Equal(total, parser.PlayerLostPower.totalDamage);
    //     Assert.Equal(qty, parser.PlayerLostPower.count);

    // }

    // [Theory]
    // [InlineData(697, 6)]
    // public void TST03_PlayerGainedExperience(int damage, int qty)
    // {

    //     input = "PlayerGainedExperience.txt";

    //     parser.LoadFile(input);

    //     Assert.Equal(damage, parser.PlayerGainedExperience.totalExperience);
    //     Assert.Equal(qty, parser.PlayerGainedExperience.count);

    // }

    // [Theory]
    // [InlineData("ghoul", 2, 1)]
    // [InlineData("cyclops", 16, 2)]
    // [InlineData("cyclops smith", 29, 1)]
    // [InlineData("dragon", 264, 3)]
    // [InlineData("dwarf soldier", 9, 1)]
    // public void TST04_PlayerLostPowerByCreature(string creature, int totalDamage, int qty)
    // {

    //     string input = "PlayerLostPower.txt";

    //     parser.LoadFile(input);

    //     var listLog = parser.PlayerLostPower.byCreature.group.filter(creature);

    //     Assert.Equal(totalDamage, listLog.total);
    //     Assert.Equal(qty, listLog.count);

    // }

}
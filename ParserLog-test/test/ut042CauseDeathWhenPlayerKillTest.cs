namespace parser.unit;

public class UT042_CauseDeathWhenPlayerKillTest
{

    private string input = "ListPlayerKill.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("MACHINEGUN, ROCKET, ROCKET_SPLASH")]
    public void TST01_CauseDeath_GetList(string list)
    {

        parser.LoadFile(input);

        Assert.Equal(list, parser.session.playerKill.causes.txt);

    }

    [Theory]
    [InlineData("ROCKET", 7)]
    [InlineData("ROCKET_SPLASH", 7)]
    [InlineData("MACHINEGUN", 1)]
    [InlineData("FALLING", 0)]
    public void TST02_CauseDeath_Count(string cause, int count)
    {

        parser.LoadFile(input);

        Assert.Equal(count, parser.session.playerKill.FilterByHowDied(cause).count);

    }

    [Theory]
    [InlineData("ROCKET, ROCKET_SPLASH, MACHINEGUN")]
    public void TST03_CauseDeath_Ranking(string ranking)
    {

        parser.LoadFile(input);

        Assert.Equal(ranking, parser.session.rankingCauses.raw);

    }

}
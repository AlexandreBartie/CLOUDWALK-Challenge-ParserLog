namespace parser.unit;

public class UT041_CauseDeathWhenWorkKillTest
{

    private string input = "ListWorldKill.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("FALLING, TRIGGER_HURT")]
    public void TST01_CauseDeath_GetList(string list)
    {

        parser.LoadFile(input);

        Assert.Equal(list, parser.session.worldKill.causes.txt);

    }

    [Theory]
    [InlineData("FALLING", 11)]
    [InlineData("TRIGGER_HURT", 9)]
    [InlineData("ROCKET_SPLASH", 0)]
    public void TST02_CauseDeath_Count(string cause, int count)
    {

        parser.LoadFile(input);

        Assert.Equal(count, parser.session.worldKill.FilterByHowDied(cause).count);

    }

    [Theory]
    [InlineData("FALLING, TRIGGER_HURT")]
    public void TST03_CauseDeath_Ranking(string ranking)
    {

        parser.LoadFile(input);

        Assert.Equal(ranking, parser.session.rankingCauses.raw);

    }

}
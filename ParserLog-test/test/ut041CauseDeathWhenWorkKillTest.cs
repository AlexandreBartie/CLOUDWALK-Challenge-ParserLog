namespace parser.unit;

public class UT041_CauseDeathWhenWorkKillTest
{

    private string input = "ListWorldKillSomeone.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("MOD_FALLING, MOD_TRIGGER_HURT")]
    public void TST01_CauseDeath_GetList(string list)
    {
        
        parser.LoadFile(input);

        Assert.Equal(list, parser.session.WorldKillSomeone.causes.txt);

    }

    [Theory]
    [InlineData("MOD_FALLING", 11)]
    [InlineData("MOD_TRIGGER_HURT", 9)]
    [InlineData("MOD_ROCKET_SPLASH", 0)]
    public void TST02_CauseDeath_Count(string cause, int count)
    {

        parser.LoadFile(input);

        Assert.Equal(count, parser.session.WorldKillSomeone.FilterByHowDied(cause).count);

    }

}
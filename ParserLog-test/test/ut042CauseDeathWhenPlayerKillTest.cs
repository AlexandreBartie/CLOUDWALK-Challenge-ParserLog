namespace parser.unit;

public class UT042_CauseDeathWhenPlayerKillTest
{

    private string input = "ListPlayerKillSomeone.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("MOD_MACHINEGUN, MOD_ROCKET, MOD_ROCKET_SPLASH")]
    public void TST01_CauseDeath_GetList(string list)
    {
       
        parser.LoadFile(input);

        Assert.Equal(list, parser.session.PlayerKillSomeone.causes.txt);

    }

    [Theory]
    [InlineData("MOD_ROCKET", 7)]
    [InlineData("MOD_ROCKET_SPLASH", 7)]
    [InlineData("MOD_MACHINEGUN", 1)]    
    [InlineData("MOD_FALLING", 0)]
    public void TST02_CauseDeath_Count(string cause, int count)
    {

        parser.LoadFile(input);

        Assert.Equal(count, parser.session.PlayerKillSomeone.FilterByHowDied(cause).count);

    }

}
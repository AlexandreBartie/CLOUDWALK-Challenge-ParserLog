namespace parser.unit;

public class UT050_SessionOneViewTest
{
    string input = "Session-One.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData(1, 120, "Kills", "Dead", "MOD_FALLING, MOD_TRIGGER_HURT")]
    public void TST01_SessionOneViewTest(string rules, string creatures)
    {

        parser.LoadFile(input);

        var list = parser.session.WorldKill.players;

        Assert.Equal(creatures, list.txt);

    }


}
namespace parser.unit;

public class UT02_WorldKillSomeoneTest
{

    private string input = "";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 100)]
    [InlineData("Dono da Bola", 100)]
    [InlineData("Zeh", 100)]
    [InlineData("Assasinu Credi", 100)]
    public void TST01_WorldKillSomeone_ByDead(string player, int count)
    {

        input = "WorldKillSomeone.log";

        parser.LoadFile(input);

        Assert.Equal(count, parser.WorldKillSomeone.FilterByDead(player).Count);

    }

}
namespace parser.unit;

public class UT02_WorldKillSomeoneTest
{

    private string input = "";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 8)]
    [InlineData("Dono da Bola", 7)]
    [InlineData("Zeh", 2)]
    [InlineData("Assasinu Credi", 3)]
    public void TST01_WorldKillSomeone_ByDead(string player, int count)
    {

        input = "ListWorldKillSomeone.log";

        parser.LoadFile(input);

        Assert.Equal(count, parser.WorldKillSomeone.FilterByDead(player).Count);

    }

}
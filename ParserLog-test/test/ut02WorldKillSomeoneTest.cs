namespace parser.unit;

public class UT02_WorldKillSomeoneTest
{

    private string input = "";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 0)]
    [InlineData("Dono da Bola", 0)]
    [InlineData("Zeh", 0)]
    [InlineData("Assasinu Credi", 0)]
    public void TST01_WorldKillSomeone_ByDead(string player, int count)
    {

        input = "ListWorldKillSomeone.log";

        parser.LoadFile(input);

        Assert.Equal(count, parser.WorldKillSomeone.count); // .FilterByDead(player).Count);

    }

}
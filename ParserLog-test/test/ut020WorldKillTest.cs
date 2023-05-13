namespace parser.unit;

public class UT020_WorldKillTest
{

    private string input = "ListWorldKill.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 8)]
    [InlineData("Dono da Bola", 7)]
    [InlineData("Zeh", 2)]
    [InlineData("Assasinu Credi", 3)]
    public void TST01_WorldKill_Filter(string player, int count)
    {

        parser.LoadFile(input);

        Assert.Equal(count, parser.session.worldKill.FilterByWhoDied(player).count);

    }

    [Theory]
    [InlineData("Assasinu Credi, Dono da Bola, Isgalamido, Zeh")]
    public void TST02_WorldKill_ListPlayer(string list)
    {

        parser.LoadFile(input);

        Assert.Equal(list, parser.session.worldKill.players.txt);

    }

}
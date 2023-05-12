namespace parser.unit;

public class UT020_WorldKillSomeoneTest
{

    private string input = "ListWorldKillSomeone.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 8)]
    [InlineData("Dono da Bola", 7)]
    [InlineData("Zeh", 2)]
    [InlineData("Assasinu Credi", 3)]
    public void TST01_WorldKillSomeone_Filter(string player, int count)
    {

        parser.LoadFile(input);

        Assert.Equal(count, parser.session.WorldKillSomeone.FilterByWhoDied(player).Count);

    }

    [Theory]
    [InlineData("Assasinu Credi, Dono da Bola, Isgalamido, Zeh")]
    public void TST02_WorldKillSomeone_ListPlayer(string list)
    {

        parser.LoadFile(input);

        Assert.Equal(list, parser.session.WorldKillSomeone.players.txt);

    }

}
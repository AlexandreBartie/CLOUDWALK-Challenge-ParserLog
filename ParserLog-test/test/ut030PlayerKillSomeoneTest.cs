using parser.core;
namespace parser.unit;

public class UT030_PlayerKillSomeoneTest
{

    private string input = "ListPlayerKillSomeone.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 6, 3)]
    [InlineData("Dono da Bola", 3, 6)]
    [InlineData("Zeh", 6, 6)]
    [InlineData("Assasinu Credi", 0, 0)]
    public void TST01_PlayerKillSomeone_Filter(string player, int kill, int dead)
    {

        parser.LoadFile(input);

        Assert.Equal(kill, parser.session.PlayerKillSomeone.FilterByWhoKill(player).Count);
        Assert.Equal(dead, parser.session.PlayerKillSomeone.FilterByWhoDied(player).Count);

    }

    [Theory]
    [InlineData("ListPlayerKillSomeone", "Dono da Bola, Isgalamido, Zeh")]
    public void TST02_PlayerKillSomeone_PlayerList(string file, string list)
    {

        parser.LoadFile(input);

        Assert.Equal(list, parser.session.PlayerKillSomeone.players.txt);

    }

}
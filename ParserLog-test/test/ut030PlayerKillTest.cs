namespace parser.unit;

public class UT030_PlayerKillTest
{

    private string input = "ListPlayerKill.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 6, 3)]
    [InlineData("Dono da Bola", 3, 6)]
    [InlineData("Zeh", 6, 6)]
    [InlineData("Assasinu Credi", 0, 0)]
    public void TST01_PlayerKill_Filter(string player, int kill, int dead)
    {

        parser.LoadFile(input);

        Assert.Equal(kill, parser.session.PlayerKill.FilterByWhoKill(player).count);
        Assert.Equal(dead, parser.session.PlayerKill.FilterByWhoDied(player).count);

    }

    [Theory]
    [InlineData("ListPlayerKill", "Dono da Bola, Isgalamido, Zeh")]
    public void TST02_PlayerKill_ListPlayer(string file, string list)
    {

        parser.LoadFile(input);

        Assert.Equal(list, parser.session.PlayerKill.players.txt);

    }

}
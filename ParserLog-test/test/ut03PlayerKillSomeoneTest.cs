namespace parser.unit;

public class UT03_PlayerKillSomeoneTest
{

    private string input = "";

    private ParserLog parser = new();

    [Theory]
    [InlineData("Isgalamido", 8, 3)]
    [InlineData("Dono da Bola", 3, 6)]
    [InlineData("Zeh", 7, 6)]
    [InlineData("Assasinu Credi", 1, 4)]
    public void TST01_PlayerKillSomeone_Reduced(string player, int kill, int dead)
    {

        input = "ListPlayerKillSomeone-Reduced.log";

        parser.LoadFile(input);

        Assert.Equal(kill, parser.PlayerKillSomeone.FilterByKiller(player).Count);
        Assert.Equal(dead, parser.PlayerKillSomeone.FilterByDead(player).Count);

    }

    [Theory]
    [InlineData("Isgalamido", 27, 15)]
    [InlineData("Dono da Bola", 20, 24)]
    [InlineData("Zeh", 22, 25)]
    [InlineData("Assasinu Credi", 16, 21)]
    public void TST02_PlayerKillSomeone_Full(string player, int kill, int dead)
    {

        input = "ListPlayerKillSomeone-Full.log";

        parser.LoadFile(input);

        Assert.Equal(kill, parser.PlayerKillSomeone.FilterByKiller(player).Count);
        Assert.Equal(dead, parser.PlayerKillSomeone.FilterByDead(player).Count);

    }

    [Theory]
    [InlineData("ListPlayerKillSomeone-Reduced", "Assasinu Credi, Dono da Bola, Isgalamido, Zeh")]
    [InlineData("ListPlayerKillSomeone-Full", "Assasinu Credi, Dono da Bola, Isgalamido, Zeh")]
    public void TST03_PlayerKillSomeone_Full_PlayerList(string file, string list)
    {

        input = file + ".log";

        parser.LoadFile(input);

        Assert.Equal(list, parser.PlayerKillSomeone.players.txt);

    }

}
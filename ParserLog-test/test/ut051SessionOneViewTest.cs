namespace parser.unit;

public class UT051_SessionOneViewTest
{
    string input = "Session-One.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData(105, "Assasinu Credi, Dono da Bola, Isgalamido, Zeh", "FALLING, MACHINEGUN, RAILGUN, ROCKET, ROCKET_SPLASH, SHOTGUN, TRIGGER_HURT")]
    public void TST01_SessionOneViewTest(int kills, string ListPlayers, string ListCauses)
    {

        parser.LoadFile(input);

        Assert.Equal(kills, parser.session.totalKills);
        Assert.Equal(ListPlayers, parser.session.players.txt);
        Assert.Equal(ListCauses, parser.session.causes.txt);

    }

    [Theory]
    [InlineData("Assasinu Credi", 10, 5, 2)]
    [InlineData("Dono da Bola", 10, 5, 2)]
    [InlineData("Isgalamido", 10, 5, 2)]
    [InlineData("Zeh", 10, 5, 2)]
    [InlineData("Mocinha", 10, 5, 2)]
    public void TST02_SessionOneViewTest_Score(string player, int score, int kills, int deaths)
    {

        parser.LoadFile(input);

        Assert.Equal(score, parser.session.totalScore(player));
        Assert.Equal(kills, parser.session.totalScoreKills(player));
        Assert.Equal(deaths, parser.session.totalScoreKilled(player));

    }


}
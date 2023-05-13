namespace parser.unit;

public class UT052_SessionFullViewTest
{
    string input = "Session-Full.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData(1, 0, "", "")]
    [InlineData(2, 11, "Isgalamido, Mocinha", "FALLING, ROCKET_SPLASH, TRIGGER_HURT")]
    [InlineData(3, 4, "Dono da Bola, Isgalamido, Mocinha, Zeh", "FALLING, ROCKET, TRIGGER_HURT")]
    [InlineData(4, 105, "Assasinu Credi, Dono da Bola, Isgalamido, Zeh", "FALLING, MACHINEGUN, RAILGUN, ROCKET, ROCKET_SPLASH, SHOTGUN, TRIGGER_HURT")]    
    public void TST01_SessionFullViewTest(int game, int kills, string ListPlayers, string ListCauses)
    {

        parser.LoadFile(input);

        var session = parser.data(game);

        Assert.Equal(kills, session.totalKills);
        Assert.Equal(ListPlayers, session.players.txt);
        Assert.Equal(ListCauses, session.causes.txt);

    }

    // [Theory]
    // [InlineData(4, "Assasinu Credi", 10, 5, 2)]
    // [InlineData(4, "Dono da Bola", 10, 5, 2)]
    // [InlineData(4, "Isgalamido", 10, 5, 2)]
    // [InlineData(4, "Zeh", 10, 5, 2)]
    // [InlineData(4, "Mocinha", 10, 5, 2)]
    // public void TST02_SessionFullViewTest_Score(int game, string player, int score, int kills, int deaths)
    // {

    //     parser.LoadFile(input);

    //     var session = parser.data(game);

    //     Assert.Equal(score, session.totalScore(player));
    //     Assert.Equal(kills, session.totalScoreKills(player));
    //     Assert.Equal(deaths, session.totalScoreKilled(player));

    // }


}
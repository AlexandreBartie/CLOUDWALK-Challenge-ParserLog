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
    [InlineData("Assasinu Credi", 13, 16, 3, 21)]
    [InlineData("Dono da Bola", 13, 20, 7, 24)]
    [InlineData("Isgalamido", 19, 27, 8, 15)]
    [InlineData("Zeh", 20, 22, 2, 25)]
    [InlineData("Mocinha", 0, 0, 0, 0)]
    public void TST02_SessionOneViewTest_Score(string player, int score, int kills, int deathsByWorld, int deathsByPlayer)
    {

        parser.LoadFile(input);

        Assert.Equal(score, parser.session.totalScore(player));
        Assert.Equal(kills, parser.session.totalScoreKills(player));
        Assert.Equal(deathsByWorld, parser.session.totalScoreDeadByWorld(player));
        Assert.Equal(deathsByPlayer, parser.session.totalScoreDeadByPlayer(player));

    }

    [Theory]
    [InlineData("Zeh, Isgalamido, Dono da Bola, Assasinu Credi")]
    public void TST03_SessionOneViewTest_RankingKills(string ranking)
    {

        parser.LoadFile(input);

        Assert.Equal(ranking, parser.session.rankingKills.raw);

    }

    [Theory]
    [InlineData("ROCKET_SPLASH, ROCKET, FALLING, TRIGGER_HURT, RAILGUN, MACHINEGUN, SHOTGUN")]
    public void TST03_SessionOneViewTest_RankingCauses(string ranking)
    {

        parser.LoadFile(input);

        Assert.Equal(ranking, parser.session.rankingCauses.raw);

    }

}
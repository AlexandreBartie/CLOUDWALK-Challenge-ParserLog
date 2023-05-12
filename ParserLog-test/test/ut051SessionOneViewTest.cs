namespace parser.unit;

public class UT050_SessionOneViewTest
{
    string input = "Session-One.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData(1, 105, "Assasinu Credi, Dono da Bola, Isgalamido, Zeh", "MOD_FALLING, MOD_MACHINEGUN, MOD_RAILGUN, MOD_ROCKET, MOD_ROCKET_SPLASH, MOD_SHOTGUN, MOD_TRIGGER_HURT")]
    public void TST01_SessionOneViewTest(int game, int kills, string ListPlayers, string ListCauses)
    {

        parser.LoadFile(input);

        var session = parser.data(game);

        Assert.Equal(kills, session.totalKills);
        Assert.Equal(ListPlayers, session.players.txt);
        Assert.Equal(ListCauses, session.causes.txt);

    }


}
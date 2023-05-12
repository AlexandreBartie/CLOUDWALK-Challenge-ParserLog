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
    public void TST01_SessionOneViewTest(int game, int kills, string ListPlayers, string ListCauses)
    {

        parser.LoadFile(input);

        var session = parser.data(game);

        Assert.Equal(kills, session.totalKills);
        Assert.Equal(ListPlayers, session.players.txt);
        Assert.Equal(ListCauses, session.causes.txt);

    }


}
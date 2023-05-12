namespace parser.unit;

public class UT050_SessionOneViewTest
{
    string input = "Session-One.log";

    private ParserLog parser = new();

    [Theory]
    [InlineData("*cyclo*", "cyclops, cyclops smith")]
    [InlineData("*black*", "Black Knight")]
    [InlineData("dragon*, dwarf", "dragon, dragon lord, dwarf, dwarf soldier")]
    public void TST01_CreatureGroup_ByCreatureSpotlight(string rules, string creatures)
    {

        parser.LoadFile(input);

        var list = parser.CreatureSpotlight.creatures;

        Assert.Equal(creatures, list.txt);

    }


}
namespace parser.unit;

public class UT06_SpotlightViewTest
{
    string input = "CreatureSpotlight.txt";

    private ParserLog parser = new();

    [Theory]
    [InlineData("*cyclo*", "cyclops, cyclops smith")]
    [InlineData("*black*", "Black Knight")]
    [InlineData("dragon*, dwarf", "dragon, dragon lord, dwarf, dwarf soldier")]
    public void TST01_CreatureGroup_ByCreatureSpotlight(string rules, string creatures)
    {

        parser.SetSpotlight(rules);

        parser.LoadFile(input);

        var list = parser.CreatureSpotlight.creatures;

        Assert.Equal(creatures, list.txt);

    }


}
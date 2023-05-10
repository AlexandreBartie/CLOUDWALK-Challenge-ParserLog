namespace parser.unit;

public class UT04_CreatureViewTest
{
    private string input = "";

    private ParserLog parser = new();

    [Theory]
    [InlineData("rat", 20, 1)]
    [InlineData("cyclops", 520, 2)]
    [InlineData("cyclops smith", 435, 2)]
    [InlineData("skeleton", 50, 1)]
    [InlineData("spider", 20, 1)]
    [InlineData("dragon", 1018, 3)]
    [InlineData("dwarf", 90, 1)]
    [InlineData("dwarf soldier", 135, 1)]
    public void TST01_CreatureLostPower(string name, int totalDamage, int qty)
    {

        string input = "CreatureLostPower.txt";

        parser.LoadFile(input);

        var creature = parser.CreatureLostPower.group.filter(name);

        Assert.Equal(totalDamage, creature.total);
        Assert.Equal(qty, creature.Count);

    }

    [Theory]
    [InlineData("cyclops, cyclops smith, dragon, dwarf soldier, ghoul")]
    public void TST02_CreatureGroup_ByPlayerLostPower(string creatures)
    {

        string input = "PlayerLostPower.txt";

        parser.LoadFile(input);

        var group = parser.PlayerLostPower.byCreature.group;

        Assert.Equal(creatures, group.creatures.txt);

    }

    [Theory]
    [InlineData("dragon, dragon lord")]
    public void TST03_CreatureGroup_ByCreatureHealedPower(string creatures)
    {

        string input = "CreatureHealedPower.txt";

        parser.LoadFile(input);

        var group = parser.CreatureHealedPower.group;

        Assert.Equal(creatures, group.creatures.txt);

    }

    [Theory]
    [InlineData("cyclops, cyclops smith, dragon, dwarf, dwarf soldier, rat, skeleton, spider")]
    public void TST04_CreatureGroup_ByCreatureLostPower(string creatures)
    {

        string input = "CreatureLostPower.txt";

        parser.LoadFile(input);

        var group = parser.CreatureLostPower.group;

        Assert.Equal(creatures, group.creatures.txt);

    }

}
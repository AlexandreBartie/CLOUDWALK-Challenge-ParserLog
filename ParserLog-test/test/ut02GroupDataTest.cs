using parser.data.group;

namespace parser.unit;

public class UT02_GroupDataTest
{

    [Theory]
    [InlineData("a gold coin", "1 gold coin")]
    [InlineData("2 dragon ham, 66 gold coins", "2 dragon ham, 66 gold coins")]
    [InlineData("a cyclops trophy, 29 gold coins", "1 cyclops trophy, 29 gold coins")]
    [InlineData("a cyclops toe, 13 gold coins, meat", "1 cyclops toe, 13 gold coins, 1 meat")]
    [InlineData("a crossbow, 2 dragon ham, green dragon leather, plate legs, a steel shield", "1 crossbow, 2 dragon ham, 1 green dragon leather, 1 plate legs, 1 steel shield")]
    [InlineData("5 bolts, a soldier helmet, 2 white mushrooms", "5 bolts, 1 soldier helmet, 2 white mushrooms")]
    [InlineData("nothing", "")]
    public void TST01_LootList(string input, string expected)
    {

        var list = new GroupLootList(input);

        Assert.Equal(expected, list.txt);

    }


}
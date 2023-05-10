using parser.data.group;

namespace parser.core.log;

public struct ILogPlayerPoints
{
    public int points;
}

public struct ILogPlayerLooted
{
    public string creature;
    public GroupLootList list;

}

public struct ILogCreaturePoints
{
    public string creature;
    public int points;

}

using parser.core.log;
using parser.data.list;
using parser.data.model;
using parser.lib;

namespace parser.data.group;

public class GroupCreatureList : List<GroupCreature>
{

    public readonly ViewData view;

    public readonly TypeLog type;

    public CreatureList creatures => GetCreatures();

    public int total => GetTotal();

    public int count => this.Count;

    public GroupCreatureList(ViewData view, TypeLog type)
    {
        this.view = view;
        this.type = type;
    }

    public void AddItem(RecordLog log)
    {
        if (type == TypeLog.eLogPlayerLostPowerByCreature)
            AddItem(log.dataPlayerLostPowerByCreature);

        if (type == TypeLog.eLogCreatureHealedPower)
            AddItem(log.GroupCreatureHealedPower);

        if (type == TypeLog.eLogCreatureLostPower)
            AddItem(log.GroupCreatureLostPower);

    }

    private void AddItem(ILogCreaturePoints data)
    {
        Add(new GroupCreature(data.creature, data.points));
    }

    public GroupCreatureList filter(string creature)
    {

        var list = new GroupCreatureList(view, type);

        foreach (GroupCreature item in this)
        {
            if (Text.IsMatch(item.creature, creature))
                list.Add(item);
        }

        return list;
    }

    private CreatureList GetCreatures()
    {

        var list = new CreatureList();

        foreach (GroupCreature item in this)
        {
            list.AddItem(item.creature);
        }

        return list;

    }

    private int GetTotal()
    {
        var total = 0;

        foreach (GroupCreature item in this)
        {
            total += item.points;
        }

        return total;
    }

    public string log()
    {

        var memo = new Memo();

        foreach (Creature item in creatures.OrderBy(item => item.name))
        {
            var creature = item.name;

            var list = filter(creature);

            var log = view.GetLogPoints(creature, list.total, list.count, 3);

            memo.Add(log);
        }

        return memo.txt;

    }

}

public class GroupCreature
{

    public string creature;
    public int points;

    public GroupCreature(string creature, int points)
    {
        this.creature = creature;
        this.points = points;
    }

}
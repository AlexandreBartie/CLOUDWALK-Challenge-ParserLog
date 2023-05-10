using parser.core.log;
using parser.data.group;
using parser.data.list;
using parser.data.model;
using parser.lib;

namespace parser.data.view;

public class ViewPlayerLootedByCreature : ViewModelGeneric
{
    public ViewPlayerLootedByCreature(ViewData view) : base(view, TypeLog.eLogPlayerLootedByCreature) { }

    public GroupLootList loot = new();

    public override void GroupData()
    {
        foreach (RecordLog log in logs)
        {
            loot.AddList(log.dataPlayerLootedByCreature.list);
        }
    }

    public override string log(string label)
    {

        var memo = new Memo();

        memo.add(view.GetLogItems(label, loot.total, count));

        memo.add(logList());

        return memo.txt;
    }

    private string logList()
    {

        var memo = new Memo();

        foreach (LootItem item in loot.items.OrderBy(item => item.name))
        {
            var name = item.name;

            var list = loot.filter(name);

            var log = view.GetLogItems(name, list.total, list.count, 3);

            memo.Add(log);
        }

        return memo.txt;

    }

}
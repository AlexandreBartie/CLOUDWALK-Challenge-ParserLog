using parser.core.log;
using parser.data.group;
using parser.data.list;
using parser.lib;

namespace parser.data.model;

public abstract class ViewModelCreatureList : ViewModelGeneric
{

    public GroupCreatureList group;

    public CreatureList creatures => group.creatures;

    public ViewModelCreatureList(ViewData view, TypeLog type) : base(view, type)
    { group = new GroupCreatureList(view, type); }

    public override void GroupData()
    {

        foreach (RecordLog log in logs)
        {
            group.AddItem(log);
        }

    }

    public override string log(string label)
    {

        var memo = new Memo();

        memo.add(view.GetLogPoints(label, group.total, count, 2));

        memo.add(group.log());

        return memo.txt;
    }

}
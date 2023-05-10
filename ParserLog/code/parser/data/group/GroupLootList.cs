using System.Text.RegularExpressions;
using parser.data.list;
using parser.lib;

namespace parser.data.group;

public class GroupLootList : List<GroupLootItem>
{

    const string LOOT_DELIMITER = ", ";


    public int total => GetTotal();

    public int count => this.Count;

    public string txt => string.Join(LOOT_DELIMITER, this);

    public LootList items => GetLootList();

    public GroupLootList(string list = "")
    {

        if (list != "")
            setup(list);
    }

    public void AddList(GroupLootList list)
    {

        foreach (GroupLootItem loot in list)
        {
            Add(loot);
        }
    }

    public GroupLootList filter(string name)
    {

        var list = new GroupLootList();

        foreach (GroupLootItem loot in this)
        {
            if (Text.IsMatch(loot.name, name, true))
                list.Add(loot);
        }

        return list;
    }

    private void setup(string list)
    {

        string[] items = list.Split(LOOT_DELIMITER);

        foreach (string item in items)
        {
            Add(new GroupLootItem(item));
        }

    }
    private int GetTotal()
    {
        var total = 0;

        foreach (GroupLootItem loot in this)
        {
            total += loot.qty;
        }

        return total;
    }

    private LootList GetLootList()
    {

        var list = new LootList();

        foreach (GroupLootItem item in this)
            list.AddItem(item.name);

        return list;

    }

}

public class GroupLootItem
{

    const string LOOTED_NULL = "nothing";
    const string LOOTED_ITEM = @"^\s*(\d*)\s*(.*)$";
    const string LOOTED_ITEM_NAME = @"^(an? )";

    private string item;

    private string paramQTY = "";
    private string paramName = "";

    private bool isNull => (item == LOOTED_NULL);

    public int qty
    {
        get
        {

            if (isNull)
                return 0;

            if (paramQTY == "")
                return 1;

            return int.Parse(paramQTY);
        }
    }

    public string name => paramName;

    public override string ToString() => isNull ? "" : String.Format("{0} {1}", qty, paramName);

    public GroupLootItem(string item)
    {

        this.item = item;

        if (!isNull)
        {
            var match = new TextMatch(item, LOOTED_ITEM);

            paramQTY = match.GetParameter(1);
            paramName = GetNameTreatment(match.GetParameter(2));

        }

    }

    private string GetNameTreatment(string input)
    {
        return Regex.Replace(input, LOOTED_ITEM_NAME, "");
    }

}



using parser.lib;

namespace parser.data.list;

public class LootList : List<LootItem>
{
    public string txt => string.Join(", ", this.OrderBy(item => item.name));

    public void AddItem(string name)
    {
        if (name.Trim() == "")
            return;

        if (!Found(name))
            Add(new LootItem(name));

    }

    public bool Found(string name)
    {

        foreach (LootItem item in this)
        {
            if (item.IsMatch(name))
                return true;
        }

        return false;

    }

    private string GetTXT()
    {

        var memo = new Memo();

        foreach (LootItem item in this)
            memo.Add(item.name);

        return memo.txt;

    }

}

public class LootItem
{

    private string _name;
    public string name => _name;

    public LootItem(string name)
    { _name = name; }

    public override string ToString() => name;

    public bool IsMatch(string name)
    {
        if (Text.IsMatch(_name, name, true))
        {
            setPluralName(name);

            return true;
        }

        return false;
    }

    private void setPluralName(string name)
    {
        if (Text.IsPlural(name))
            _name = name;
    }


}


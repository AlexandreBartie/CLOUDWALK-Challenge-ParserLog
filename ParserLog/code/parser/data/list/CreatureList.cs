using parser.lib;

namespace parser.data.list;

public class CreatureList : List<Creature>
{
    public string txt => string.Join(", ", this.OrderBy(item => item.name));

    public void AddList(CreatureList list)
    {
        foreach (Creature creature in list)
            AddItem(creature.name);

    }

    public void AddItem(string name)
    {
        if (name.Trim() == "")
            return;

        if (!Found(name))
            Add(new Creature(name));

    }

    public bool Found(string name)
    {

        foreach (Creature item in this)
        {
            if (Text.IsMatch(item.name, name))
                return true;
        }

        return false;

    }

    public CreatureList Match(string wildcard)
    {

        CreatureList list = new();

        foreach (Creature creature in this)
        {
            if (creature.IsMatch(wildcard))
                list.Add(creature);
        }

        return list;

    }

    private string GetTXT()
    {

        var memo = new Memo();

        foreach (Creature item in this)
            memo.Add(item.name);

        return memo.txt;

    }

}

public class Creature
{
    public readonly string name;

    public Creature(string name)
    { this.name = name; }

    public override string ToString() => name;

    public bool IsMatch(string pattern)
    {
        return Text.IsMatchByWildcard(name, pattern);
    }

}




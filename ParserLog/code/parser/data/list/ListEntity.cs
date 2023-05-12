using lib;

namespace parser.data.list;

public abstract class ListEntity<T> : List<T> where T : Entity
{
    public string txt => string.Join(", ", this.OrderBy(item => item.name));

    public void AddList(List<T> list)
    {
        foreach (T item in list)
            AddItem(item.name);

    }

    public void AddItem(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return;

        if (!Found(name))
        {
            T? item = Activator.CreateInstance(typeof(T), name) as T;

            if (item != null)
                Add(item);
        }

    }

    public bool Found(string name)
    {

        foreach (T item in this)
        {
            if (Text.IsMatch(item.name, name))
                return true;
        }

        return false;

    }

    public List<T> Match(string wildcard)
    {

        List<T> list = new();

        foreach (T item in this)
        {
            if (item.IsMatch(wildcard))
                list.Add(item);
        }

        return list;

    }

    private string GetTXT()
    {

        var memo = new Memo();

        foreach (T item in this)
            memo.Add(item.name);

        return memo.txt;

    }

}

public abstract class Entity
{
    private string _name  = "";
    
    public string name => _name;

    public Entity(string name)
    { _name = name; }

    public override string ToString() => name;

    public bool IsMatch(string pattern)
    {
        return Text.IsMatchByWildcard(name, pattern);
    }

    public void SetName(string name)
    { _name = name; }

}




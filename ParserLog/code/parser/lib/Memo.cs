namespace parser.lib;

public class Memo : List<string>
{

    public string txt => string.Join(Environment.NewLine, this);

    public string csv => string.Join(", ", this);


    public void add(string item)
    {
        Add(item);
    }
    public void add(string[] list)
    {

        foreach (string item in list)
        {
            add(item);
        }

    }

}
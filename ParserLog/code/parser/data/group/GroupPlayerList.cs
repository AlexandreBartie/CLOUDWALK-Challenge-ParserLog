using parser.core.log;
using parser.data.list;
using parser.data.model;
using parser.lib;

namespace parser.data.group;

public class GroupPlayerList : List<GroupPlayer>
{

    public readonly ViewData view;

    public readonly TypeLog type;

    public PlayerList players => GetPlayers();

    public int count => this.Count;

    public GroupPlayerList(ViewData view, TypeLog type)
    {
        this.view = view;
        this.type = type;
    }

    public void AddItem(RecordLog log)
    {
        AddItem(log.dataPlayerDead);

    }

    private void AddItem(ILogPlayerDead data)
    {
        Add(new GroupPlayer(data.killer));
    }

    public GroupPlayerList filter(string player)
    {

        var list = new GroupPlayerList(view, type);

        foreach (GroupPlayer item in this)
        {
            if (Text.IsMatch(item.player, player))
                list.Add(item);
        }

        return list;
    }

    private PlayerList GetPlayers()
    {

        var list = new PlayerList();

        foreach (GroupPlayer item in this)
        {
            list.AddItem(item.player);
        }

        return list;

    }

    private int GetTotal()
    {
        var total = 0;

        foreach (GroupPlayer item in this)
        {
            total ++;
        }

        return total;
    }

    public string log()
    {

        var memo = new Memo();

        foreach (Player item in players.OrderBy(item => item.name))
        {
            var player = item.name;

            var list = filter(player);

            var log = view.GetLogPoints(player, 100, list.count, 3);

            memo.Add(log);
        }

        return memo.txt;

    }

}

public class GroupPlayer
{

    public string player;
    public int kills;
    public int deaths;

    public GroupPlayer(string player)
    {
        this.player = player;
    }

}
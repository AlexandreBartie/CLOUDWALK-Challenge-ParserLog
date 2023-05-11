using parser.data.list;
using parser.data.log;
using parser.data.model;
using parser.lib;

namespace parser.data.view;

public class ViewWorldKillSomeone : ViewModelGeneric
{
    public ViewWorldKillSomeone(ViewData view) : base(view, LogType.eLogWorldKillSomeone) { }

    public PlayerList players => GetPlayers();

    public int totalDeaths => logs.Count;

    public LogList FilterByDead(string player)
    {

        var list = new LogList();

        foreach (LogItem log in this.logs)
        {
            if (Text.IsMatch(player, log.worldKillSomeone.dead))
                list.Add(log);

        }

        return list;

    }

    private PlayerList GetPlayers()
    {

        var list = new PlayerList();

        foreach (LogItem log in this.logs)
            list.AddItem(log.worldKillSomeone.dead);

        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
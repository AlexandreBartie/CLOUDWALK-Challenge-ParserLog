using parser.data.list;
using parser.data.log;
using parser.data.model;
using parser.lib;

namespace parser.data.view;

public class ViewPlayerKillSomeone : ViewModel
{
    public ViewPlayerKillSomeone(ViewData view) : base(view, LogType.eLogPlayerKillSomeone) { }

    public PlayerList players => GetPlayers();

    public int total => logs.Count;

    public LogList FilterByWhoKill(string player)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(player, log.playerKillSomeone.killer))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByWhoDied(string player)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(player, log.playerKillSomeone.dead))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByHowDied(string cause)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(cause, log.playerKillSomeone.cause))
                list.Add(log);

        }

        return list;

    }

    private PlayerList GetPlayers()
    {

        var list = new PlayerList();

        foreach (LogItem log in this.logs)
        {
            list.AddItem(log.playerKillSomeone.killer);
            list.AddItem(log.playerKillSomeone.dead);
        }


        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
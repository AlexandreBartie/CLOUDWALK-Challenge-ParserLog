using lib;
using parser.core.log;
using parser.data.list;
using parser.data.model;

namespace parser.data.view;

public class ViewPlayerKillSomeone : ViewModel
{
    public ViewPlayerKillSomeone(ViewData view) : base(view, LogType.eLogPlayerKillSomeone) { }

    public ListPlayer players => GetPlayers();
    public ListCauseDeath causes => GetCauseList();

    public int total => logs.Count;

    public LogList FilterByWhoKill(string player)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(player, log.playerKillSomeone.killer))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByWhoDied(string player)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(player, log.playerKillSomeone.dead))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByHowDied(string cause)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(cause, log.playerKillSomeone.cause))
                list.Add(log);

        }

        return list;

    }

    private ListPlayer GetPlayers()
    {

        var list = new ListPlayer();

        foreach (LogRecord log in this.logs)
        {
            list.AddItem(log.playerKillSomeone.killer);
            list.AddItem(log.playerKillSomeone.dead);
        }


        return list;

    }

    private ListCauseDeath GetCauseList()
    {

        var list = new ListCauseDeath();

        foreach (LogRecord log in this.logs)
            list.AddItem(log.playerKillSomeone.cause);

        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
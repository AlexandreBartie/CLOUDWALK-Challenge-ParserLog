using lib;
using parser.data.list;
using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewWorldKillSomeone : ViewModel
{
    public ListPlayer players => GetListPlayer();
    public ListCauseDeath causes => GetCauseList();

    public int totalDeaths => logs.Count;

    public ViewWorldKillSomeone(ViewData view) : base(view, LogType.eLogWorldKillSomeone) { }

    public LogList FilterByWhoDied(string player)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(player, log.worldKillSomeone.dead))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByHowDied(string cause)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(cause, log.worldKillSomeone.cause))
                list.Add(log);

        }

        return list;

    }

    private ListPlayer GetListPlayer()
    {

        var list = new ListPlayer();

        foreach (LogRecord log in this.logs)
            list.AddItem(log.worldKillSomeone.dead);


        return list;

    }

    private ListCauseDeath GetCauseList()
    {

        var list = new ListCauseDeath();

        foreach (LogRecord log in this.logs)
            list.AddItem(log.worldKillSomeone.cause);

        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
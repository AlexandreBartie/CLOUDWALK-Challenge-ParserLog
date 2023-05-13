using lib;
using parser.data.list;
using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewWorldKill : ViewModel
{
    public ListPlayer players => GetListPlayer();
    public ListCauseDeath causes => GetListCause();

    public int totalDeaths => logs.Count;

    public ViewWorldKill(ViewDashBoard view) : base(view, LogType.eLogWorldKill) { }

    public LogList FilterByWhoDied(string player)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(player, log.worldKill.dead))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByHowDied(string cause)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(cause, log.worldKill.cause))
                list.Add(log);

        }

        return list;

    }

    private ListPlayer GetListPlayer()
    {

        var list = new ListPlayer();

        foreach (LogRecord log in this.logs)
            list.AddItem(log.worldKill.dead);


        return list;

    }

    private ListCauseDeath GetListCause()
    {

        var list = new ListCauseDeath();

        foreach (LogRecord log in this.logs)
            list.AddItem(log.worldKill.cause);

        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
using lib;
using parser.core.log;
using parser.data.list;
using parser.data.model;

namespace parser.data.view;

public class ViewPlayerKill : ViewModel
{
    public ViewPlayerKill(ViewData view) : base(view, LogType.eLogPlayerKill) { }

    public ListPlayer players => GetListPlayer();
    public ListCauseDeath causes => GetListCause();

    public int total => logs.Count;

    public LogList FilterByWhoKill(string player)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(player, log.playerKill.killer))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByWhoDied(string player)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(player, log.playerKill.dead))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByHowDied(string cause)
    {

        var list = new LogList();

        foreach (LogRecord log in logs)
        {
            if (Text.IsMatch(cause, log.playerKill.cause))
                list.Add(log);

        }

        return list;

    }

    private ListPlayer GetListPlayer()
    {

        var list = new ListPlayer();

        foreach (LogRecord log in this.logs)
        {
            list.AddItem(log.playerKill.killer);
            list.AddItem(log.playerKill.dead);
        }


        return list;

    }

    private ListCauseDeath GetListCause()
    {

        var list = new ListCauseDeath();

        foreach (LogRecord log in this.logs)
            list.AddItem(log.playerKill.cause);

        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
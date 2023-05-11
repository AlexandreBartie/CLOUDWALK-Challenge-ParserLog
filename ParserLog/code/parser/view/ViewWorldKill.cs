using parser.data.list;
using parser.data.log;
using parser.view.model;
using parser.lib;

namespace parser.data.view;

public class ViewWorldKillSomeone : ViewModel
{
    public PlayerList players => GetPlayerList();
    public CauseDeathList causes => GetCauseList();

    public int totalDeaths => logs.Count;

    public ViewWorldKillSomeone(ViewData view) : base(view, LogType.eLogWorldKillSomeone) { }

    public LogList FilterByWhoDied(string player)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(player, log.worldKillSomeone.dead))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByHowDied(string cause)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(cause, log.worldKillSomeone.cause))
                list.Add(log);

        }

        return list;

    }

    private PlayerList GetPlayerList()
    {

        var list = new PlayerList();

        foreach (LogItem log in this.logs)
            list.AddItem(log.worldKillSomeone.dead);


        return list;

    }

    private CauseDeathList GetCauseList()
    {

        var list = new CauseDeathList();

        foreach (LogItem log in this.logs)
            list.AddItem(log.worldKillSomeone.cause);

        return list;

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
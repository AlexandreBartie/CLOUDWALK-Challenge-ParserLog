using parser.data.log;
using parser.data.model;
using parser.lib;

namespace parser.data.view;

public class ViewPlayerKillSomeone : ViewModelGeneric
{
    public ViewPlayerKillSomeone(ViewData view) : base(view, LogType.eLogPlayerKillSomeone) { }

    public int total => logs.Count;

    public override void GroupData()
    {

        // totalKills = 0;
        // totalDeaths = 0;

        // foreach (LogItem log in logs)
        // {
        //     if (log.dataPlayerKilledSomeone.killer)
        //         totalKills++;
        //     totalDeaths++;
        // }
    }

    public LogList FilterByKiller(string player)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(player, log.playerKillSomeone.killer))
                list.Add(log);

        }

        return list;

    }

    public LogList FilterByDead(string player)
    {

        var list = new LogList();

        foreach (LogItem log in logs)
        {
            if (Text.IsMatch(player, log.playerKillSomeone.dead))
                list.Add(log);

        }

        return list;

    }



    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
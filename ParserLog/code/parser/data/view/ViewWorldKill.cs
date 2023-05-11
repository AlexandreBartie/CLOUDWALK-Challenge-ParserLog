using parser.data.log;
using parser.data.model;
using parser.data.record;
using parser.lib;

namespace parser.data.view;

public class ViewWorldKillSomeone : ViewModelGeneric
{
    public ViewWorldKillSomeone(ViewData view) : base(view, LogType.eLogWorldKillSomeone) { }

    public int totalDeaths => logs.Count;

    public override void GroupData()
    {

        // totalDeaths = 0;

        // foreach (LogItem log in logs)
        // {
        //     if (log.dataPlayerKilledSomeone.killer)
        //     totalDeaths++;
        // }
    }

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

    public override string log(string label)
    {
        return view.GetLogPoints(label, 0, count);
    }

}
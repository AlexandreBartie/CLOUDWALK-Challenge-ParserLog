using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewPlayerDead : ViewModelGeneric
{
    public ViewPlayerDead(ViewData view) : base(view, TypeLog.eLogPlayerDead) { }

    public int totalKills;

    public override void GroupData()
    {

        totalKills = 0;

        foreach (RecordLog log in logs)
        {
            totalKills ++;
        }
    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, totalKills, count);
    }

}
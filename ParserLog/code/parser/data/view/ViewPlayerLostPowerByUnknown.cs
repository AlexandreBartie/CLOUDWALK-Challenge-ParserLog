using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewPlayerLostPowerByUnknown : ViewModelGeneric
{
    public ViewPlayerLostPowerByUnknown(ViewData view) : base(view, TypeLog.eLogPlayerLostPowerByUnknown) { }

    public int totalDamage = 0;

    public override void GroupData()
    {

        totalDamage = 0;

        foreach (RecordLog log in logs)
        {
            totalDamage += log.dataPlayerLostPower.points;
        }

    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, totalDamage, count, 2);
    }

}
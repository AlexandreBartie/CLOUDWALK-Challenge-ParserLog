using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewPlayerHealedPower : ViewModelGeneric
{
    public ViewPlayerHealedPower(ViewData view) : base(view, TypeLog.eLogPlayerHealedPower) { }

    public int totalHealed;

    public override void GroupData()
    {

        totalHealed = 0;

        foreach (RecordLog log in logs)
        {
            totalHealed += log.dataPlayerHealedPower.points;
        }
    }

    public override string log(string label)
    {
        return view.GetLogPoints(label, totalHealed, count);
    }

}
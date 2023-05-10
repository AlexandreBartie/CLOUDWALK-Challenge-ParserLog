using parser.data.model;

namespace parser.data.view;


public class ViewPlayerLostPower
{
    private ViewData view;

    public readonly ViewPlayerLostPowerByUnknown byUnknown;
    public readonly ViewPlayerLostPowerByCreature byCreature;

    public int count => byUnknown.count + byCreature.count;

    public int totalDamage => byUnknown.totalDamage + byCreature.totalDamage;

    public ViewPlayerLostPower(ViewData view)
    {
        this.view = view;

        byUnknown = new ViewPlayerLostPowerByUnknown(view);
        byCreature = new ViewPlayerLostPowerByCreature(view);
    }

    public void GroupData()
    {

        byUnknown.GroupData();
        byCreature.GroupData();
    }

    public string log(string label)
    {
        return view.GetLogPoints(label, totalDamage, count);
    }

}
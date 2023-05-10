using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewPlayerLostPowerByCreature : ViewModelCreatureList
{

    public int totalDamage => group.total;

    public ViewPlayerLostPowerByCreature(ViewData view) : base(view, TypeLog.eLogPlayerLostPowerByCreature) { }

}
using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewCreatureHealedPower : ViewModelCreatureList
{
    public ViewCreatureHealedPower(ViewData view) : base(view, TypeLog.eLogCreatureHealedPower) { }
}
using parser.core.log;
using parser.data.model;

namespace parser.data.view;

public class ViewCreatureLostPower : ViewModelCreatureList
{
    public ViewCreatureLostPower(ViewData view) : base(view, TypeLog.eLogCreatureLostPower) { }
}
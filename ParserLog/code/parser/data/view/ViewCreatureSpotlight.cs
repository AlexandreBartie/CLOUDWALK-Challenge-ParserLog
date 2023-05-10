using parser.data.list;
using parser.data.model;
using parser.lib;

namespace parser.data.view;
public class ViewCreatureSpotlight
{
    private ViewData view;

    public string wildcard = "";

    private CreatureList _creatures = new();

    public bool HasCreatures => (creatures.Count > 0);

    public CreatureList creatures => _creatures;


    public ViewCreatureSpotlight(ViewData view)
    {
        this.view = view;
    }

    public void Setup(string wildcard)
    {
        this.wildcard = wildcard;
    }

    public void GroupData()
    {

        var list = new CreatureList();

        list.AddList(view.PlayerLostPower.byCreature.creatures.Match(wildcard));
        list.AddList(view.CreatureLostPower.creatures.Match(wildcard));
        list.AddList(view.CreatureHealedPower.creatures.Match(wildcard));  

        _creatures = list;

    }

    public string log()
    {

        var memo = new Memo();

        foreach (Creature item in creatures.OrderBy(item => item.name))
        {
            var creature = item.name;

            var damagePlayer = view.PlayerLostPower.byCreature.group.filter(creature).total;

            var lostPower = view.CreatureLostPower.group.filter(creature).total;
            var healedPower = view.CreatureHealedPower.group.filter(creature).total;

            var log = view.GetSpotlight(creature, damagePlayer, lostPower, healedPower);

            memo.Add(log);
        }

        return memo.txt;
    }


}
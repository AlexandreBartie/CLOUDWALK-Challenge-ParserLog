using parser.core.log;
using parser.data.format;
using parser.data.view;

namespace parser.data.model;

public class ViewData : ViewFormat
{

    public ParserSessions sessions = new();

    public readonly ViewPlayerHealedPower PlayerHealedPower;
    public readonly ViewPlayerLostPower PlayerLostPower;
    public readonly ViewPlayerGainedExperience PlayerGainedExperience;
    public readonly ViewPlayerLootedByCreature PlayerLootedByCreature;

    public readonly ViewCreatureHealedPower CreatureHealedPower;
    public readonly ViewCreatureLostPower CreatureLostPower;
    public readonly ViewCreatureSpotlight CreatureSpotlight;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ViewData()
    {

        PlayerHealedPower = new ViewPlayerHealedPower(this);
        PlayerLostPower = new ViewPlayerLostPower(this);
        PlayerLootedByCreature = new ViewPlayerLootedByCreature(this);
        PlayerGainedExperience = new ViewPlayerGainedExperience(this);

        CreatureHealedPower = new ViewCreatureHealedPower(this);
        CreatureLostPower = new ViewCreatureLostPower(this);
        CreatureSpotlight = new ViewCreatureSpotlight(this);

    }

    public void SetSpotlight(string rules)
    {
        CreatureSpotlight.Setup(rules);
    }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        PlayerHealedPower.GroupData();
        PlayerLostPower.GroupData();
        PlayerGainedExperience.GroupData();
        PlayerLootedByCreature.GroupData();
        CreatureHealedPower.GroupData();
        CreatureLostPower.GroupData();
        CreatureSpotlight.GroupData();
    }

}
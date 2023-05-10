using parser.core.log;
using parser.data.format;
using parser.data.view;

namespace parser.data.model;

public class ViewData : ViewFormat
{

    public ParserSessions sessions = new();

    public readonly ViewPlayerDead PlayerDead;

    public RecordsLog logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ViewData()
    {

        PlayerDead = new ViewPlayerDead(this);

    }

    // public void SetSpotlight(string rules)
    // {
    //     CreatureSpotlight.Setup(rules);
    // }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        PlayerDead.GroupData();
    }

}
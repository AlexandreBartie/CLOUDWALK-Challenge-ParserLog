using parser.data.format;
using parser.data.view;
using parser.data.log;

namespace parser.data.model;

public class ViewData : ViewFormat
{

    public ParserSessions sessions = new();

    public readonly ViewWorldKillSomeone WorldKillSomeone;
    public readonly ViewPlayerKillSomeone PlayerKillSomeone;

    public LogList logs => (sessions.logs);

    public bool isNull => (sessions.isNull);

    public ViewData()
    {

        WorldKillSomeone = new ViewWorldKillSomeone(this);
        PlayerKillSomeone = new ViewPlayerKillSomeone(this);

    }

    // public void SetSpotlight(string rules)
    // {
    //     CreatureSpotlight.Setup(rules);
    // }

    public void Populate(string[] lines)
    {

        sessions.Populate(lines);

        // PlayerKilledSomeone.GroupData();
    }

}
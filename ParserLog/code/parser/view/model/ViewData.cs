using parser.data.log;
using parser.data.view;

namespace parser.view.model;

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
    }

}
using parser.core.log;

namespace parser.data.model;

public class ViewData : ViewFormat
{

    public ParserSessions sessions = new();

    public readonly ViewWorldKillSomeone WorldKillSomeone;
    public readonly ViewPlayerKillSomeone PlayerKillSomeone;

    public LogList all => (sessions.all);

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
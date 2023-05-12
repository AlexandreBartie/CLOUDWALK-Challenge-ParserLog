using parser.core.log;
using parser.data.view;

namespace parser.data.model;

public class ViewData : ViewFormat
{
    public readonly ViewWorldKillSomeone WorldKillSomeone;
    public readonly ViewPlayerKillSomeone PlayerKillSomeone;

    public readonly LogList logs;

    public ViewData(LogList logs)
    {
        this.logs = logs;

        WorldKillSomeone = new ViewWorldKillSomeone(this);
        PlayerKillSomeone = new ViewPlayerKillSomeone(this);

    }

}
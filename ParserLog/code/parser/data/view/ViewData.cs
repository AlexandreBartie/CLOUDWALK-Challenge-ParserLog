using parser.core.log;
using parser.data.list;
using parser.data.model;

namespace parser.data.view;

public class ViewData : ViewFormat
{
    public readonly ViewWorldKill WorldKill;
    public readonly ViewPlayerKill PlayerKill;

    public int totalKills => WorldKill.count + PlayerKill.count;

    public ListPlayer players => GetListPlayer();
    public ListCauseDeath causes => GetListCause();

    public readonly LogList logs;

    public ViewData(LogList logs)
    {
        this.logs = logs;

        WorldKill = new ViewWorldKill(this);
        PlayerKill = new ViewPlayerKill(this);

    }

    private ListPlayer GetListPlayer()
    {

        var list = new ListPlayer();

        list.AddList(WorldKill.players);
        list.AddList(PlayerKill.players);

        return list;

    }

    private ListCauseDeath GetListCause()
    {

        var list = new ListCauseDeath();

        list.AddList(WorldKill.causes);
        list.AddList(PlayerKill.causes);

        return list;

    }


}
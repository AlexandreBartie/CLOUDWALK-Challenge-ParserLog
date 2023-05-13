using parser.core.log;
using parser.data.list;
using parser.data.model;

namespace parser.data.view;

public class ViewDashBoard : ViewFormat
{
    public readonly ViewWorldKill WorldKill;
    public readonly ViewPlayerKill PlayerKill;

    public int totalKills => GetTotalKills();

    public int totalScore(string player) => GetScore(player);
    public int totalScoreKills(string player) => GetScoreKills(player);
    public int totalScoreKilled(string player) => GetScoreKilled(player);

    public ListPlayer players => GetListPlayer();
    public ListCauseDeath causes => GetListCause();

    public readonly LogList logs;

    public ViewDashBoard(LogList logs)
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

    private int GetTotalKills() => GetTotalWorldKills() + GetTotalPlayerKills();
    private int GetTotalWorldKills() => WorldKill.count;
    private int GetTotalPlayerKills() => PlayerKill.count;

    private int GetScoreKills(string player) => PlayerKill.FilterByWhoKill(player).count;

    private int GetScoreKilled(string player)
    { return WorldKill.FilterByWhoDied(player).count + PlayerKill.FilterByWhoDied(player).count; }

    private int GetScore(string player)
    { return GetScoreKills(player) - GetScoreKilled(player); }

}
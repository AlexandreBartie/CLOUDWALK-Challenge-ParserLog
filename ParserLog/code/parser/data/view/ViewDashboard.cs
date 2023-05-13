using parser.core.log;
using parser.data.list;
using parser.data.model;

namespace parser.data.view;

public class ViewDashBoard : ViewFormat
{
    public readonly ViewWorldKill worldKill;
    public readonly ViewPlayerKill playerKill;

    private ViewScore score;

    public int totalKills => score.GetTotalKills();
    public int totalKillsByWorld => score.GetTotalKillsByWorld();
    public int totalKillsByPlayer => score.GetTotalKillsByPlayer();

    public int totalScore(string player) => score.GetScore(player);
    public int totalScoreKills(string player) => score.GetScoreKills(player);
    public int totalScoreDeadByWorld(string player) => score.GetScoreDeadByWorld(player);
    public int totalScoreDeadByPlayer(string player) => score.GetScoreDeadByPlayer(player);

    public ListPlayer players => score.GetListPlayer();
    public ListCauseDeath causes => score.GetListCause();

    public readonly LogList logs;

    public ViewDashBoard(LogList logs)
    {
        this.logs = logs;

        worldKill = new ViewWorldKill(this);
        playerKill = new ViewPlayerKill(this);

        score = new ViewScore(this);

    }

}

public class ViewScore
{
    private ViewDashBoard view;
    
    public int GetTotalKills() => GetTotalKillsByWorld() + GetTotalKillsByPlayer();
    public int GetTotalKillsByWorld() => view.worldKill.count;
    public int GetTotalKillsByPlayer() => view.playerKill.count;

    public ViewScore(ViewDashBoard view)
    {
        this.view = view;
    }

    public ListPlayer GetListPlayer()
    {

        var list = new ListPlayer();

        list.AddList(view.worldKill.players);
        list.AddList(view.playerKill.players);

        return list;

    }

    public ListCauseDeath GetListCause()
    {

        var list = new ListCauseDeath();

        list.AddList(view.worldKill.causes);
        list.AddList(view.playerKill.causes);

        return list;

    }

    public int GetScore(string player) => GetScoreKills(player) - GetScoreDeadByWorld(player);
    public int GetScoreKills(string player) => view.playerKill.FilterByWhoKill(player).count;
    public int GetScoreDeadByWorld(string player) => view.worldKill.FilterByWhoDied(player).count;
    public int GetScoreDeadByPlayer(string player) => view.playerKill.FilterByWhoDied(player).count;

}
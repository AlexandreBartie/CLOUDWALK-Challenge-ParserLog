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

    public int totalScoreCause(string cause) => score.GetScoreCauses(cause);
    public int totalScoreCauseByWorld(string cause) => score.GetCausesByWorld(cause);
    public int totalScoreCauseByPlayer(string cause) => score.GetCausesByPlayer(cause);

    public ListPlayer rankingKills => score.rankingPlayer.GetRanking();
    public ListCauseDeath rankingCauses => score.rankingCause.GetRanking();
    
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

public class ViewScore : ViewDataRanking
{
      
    public int GetTotalKills() => GetTotalKillsByWorld() + GetTotalKillsByPlayer();
    public int GetTotalKillsByWorld() => view.worldKill.count;
    public int GetTotalKillsByPlayer() => view.playerKill.count;

    public ViewScore(ViewDashBoard view) : base(view) {}

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

}

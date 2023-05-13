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

    public ListPlayer ranking => score.GetListRanking();
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

public class ViewScore : ViewRanking
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

public class ViewRanking
{

    protected ViewDashBoard view;

    public int GetScore(string player) => GetScoreKills(player) - GetScoreDeadByWorld(player);
    public int GetScoreKills(string player) => view.playerKill.FilterByWhoKill(player).count;
    
    public int GetScoreDeads(string player) => GetScoreDeadByWorld(player) + GetScoreDeadByPlayer(player);
    public int GetScoreDeadByWorld(string player) => view.worldKill.FilterByWhoDied(player).count;
    public int GetScoreDeadByPlayer(string player) => view.playerKill.FilterByWhoDied(player).count;

    public ViewRanking(ViewDashBoard view)
    {
        this.view = view;
    }

    public ListPlayer GetListRanking()
    {

        var rank = new ListPlayer();

        foreach (Player player in view.players.order)
        {

            int index = 0;

            foreach (Player item in rank)
            {
                
                if (IsBetterThan(player.name, item.name))
                {
                    rank.Insert(index, player);
                    break;
                }

                index ++;

            }

            // Represents that player not added in Rank list
            if (rank.Count == index)
                rank.Add(player);

        }

        return rank;

    }

    private bool IsBetterThan(string playerNew, string playerOld)
    {
        return IsBetterThan_ByScore(playerNew, playerOld);
    }

    private bool IsBetterThan_ByScore(string playerNew, string playerOld)   
    {
    
        var scoreNew = GetScore(playerNew);
        var scoreOld = GetScore(playerOld);

        if (scoreNew > scoreOld)
            return true;

        if (scoreNew == scoreOld)
            return IsBetterThan_ByScoreKills(playerNew, playerOld);

        return false;
    }

    private bool IsBetterThan_ByScoreKills(string playerNew, string playerOld)   
    {
    
        var scoreNew = GetScoreKills(playerNew);
        var scoreOld = GetScoreKills(playerOld);

        if (scoreNew > scoreOld)
            return true;

        if (scoreNew == scoreOld)
            return IsBetterThan_ByScoreDeads(playerNew, playerOld);

        return false;
    }

    private bool IsBetterThan_ByScoreDeads(string playerNew, string playerOld)   
    {
    
        var scoreNew = GetScoreDeads(playerNew);
        var scoreOld = GetScoreDeads(playerOld);

        return (scoreNew < scoreOld);

    }

}
using parser.data.list;

namespace parser.data.panel;

public class PanelRanking
{

    public PanelData view;

    public PanelRankingPlayer rankingPlayer;
    public PanelRankingCause rankingCause;

    public int GetScore(string player) => GetScoreKills(player) - GetScoreDeadByWorld(player);
    public int GetScoreKills(string player) => view.playerKill.FilterByWhoKill(player).count;

    public int GetScoreDeads(string player) => GetScoreDeadByWorld(player) + GetScoreDeadByPlayer(player);
    public int GetScoreDeadByWorld(string player) => view.worldKill.FilterByWhoDied(player).count;
    public int GetScoreDeadByPlayer(string player) => view.playerKill.FilterByWhoDied(player).count;

    public int GetScoreCauses(string cause) => GetCausesByWorld(cause) + GetCausesByPlayer(cause);
    public int GetCausesByWorld(string cause) => view.worldKill.FilterByHowDied(cause).count;
    public int GetCausesByPlayer(string cause) => view.playerKill.FilterByHowDied(cause).count;

    public PanelRanking(PanelData view)
    {

        this.view = view;

        rankingPlayer = new PanelRankingPlayer(this);
        rankingCause = new PanelRankingCause(this);
    }

}

public class PanelRankingPlayer
{

    private PanelRanking ranking;

    public PanelRankingPlayer(PanelRanking ranking)
    { this.ranking = ranking; }

    public ListPlayer GetRanking()
    {

        var rank = new ListPlayer();

        foreach (Player player in ranking.view.players.order)
        {

            int index = 0;

            foreach (Player item in rank)
            {

                if (IsBetterThan(player.name, item.name))
                {
                    rank.Insert(index, player);
                    break;
                }

                index++;

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

        var scoreNew = ranking.GetScore(playerNew);
        var scoreOld = ranking.GetScore(playerOld);

        if (scoreNew > scoreOld)
            return true;

        if (scoreNew == scoreOld)
            return IsBetterThan_ByScoreKills(playerNew, playerOld);

        return false;
    }

    private bool IsBetterThan_ByScoreKills(string playerNew, string playerOld)
    {

        var scoreNew = ranking.GetScoreKills(playerNew);
        var scoreOld = ranking.GetScoreKills(playerOld);

        if (scoreNew > scoreOld)
            return true;

        if (scoreNew == scoreOld)
            return IsBetterThan_ByScoreDeads(playerNew, playerOld);

        return false;
    }

    private bool IsBetterThan_ByScoreDeads(string playerNew, string playerOld)
    {

        var scoreNew = ranking.GetScoreDeads(playerNew);
        var scoreOld = ranking.GetScoreDeads(playerOld);

        return (scoreNew < scoreOld);

    }

}
public class PanelRankingCause
{

    private PanelRanking ranking;

    public PanelRankingCause(PanelRanking ranking)
    { this.ranking = ranking; }

    public ListCauseDeath GetRanking()
    {

        var rank = new ListCauseDeath();

        foreach (CauseDeath cause in ranking.view.causes.order)
        {

            int index = 0;

            foreach (CauseDeath item in rank)
            {

                if (IsBiggerThan(cause.name, item.name))
                {
                    rank.Insert(index, cause);
                    break;
                }

                index++;

            }

            // Represents that player not added in Rank list
            if (rank.Count == index)
                rank.Add(cause);

        }

        return rank;

    }

    private bool IsBiggerThan(string causeNew, string causeOld)
    {

        var scoreNew = ranking.GetScoreCauses(causeNew);
        var scoreOld = ranking.GetScoreCauses(causeOld);

        return (scoreNew > scoreOld);
    }

}
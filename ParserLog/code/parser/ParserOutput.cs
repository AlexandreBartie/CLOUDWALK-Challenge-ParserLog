using lib;
using parser.data.list;

namespace parser;

public class ParserOutput
{

    private ParserLog parser;

    private ParserShow show => parser.show;

    private Memo memo = new();

    public ParserOutput(ParserLog parser)
    {
        this.parser = parser;
    }

    public string txt(ParserSessions sessions)
    {

        memo = new Memo();

        memo.add(parser.session.logTitle("Statistics"));

        foreach (ParserSession session in sessions)
            GetSession(session);

        memo.add(parser.session.logBottom("Statistics based by file log extracted"));

        return (memo.txt);

    }
    private void GetSession(ParserSession session)
    {

        var details = parser.show.ViewDetails;

        memo.add(session.logLine('='));
        memo.add(session.logContent("Match", session.tag));

        if (parser.show.ResumeGame)
            GetResumeGame(session, details);

        if (parser.show.RankingKills)
            GetRankingKills(session, details);

        if (parser.show.RankingCauses)
            GetRankingCauses(session, details);

    }

    private void GetResumeGame(ParserSession session, bool details)
    {
        var title = "Total Kills";
        var logKill = "";
        
        if (details)
            logKill = session.logKillsDetails(title, session.totalKills, session.totalKillsByWorld, session.totalKillsByPlayer);
        else
                logKill = session.logKills("Total Kills", session.totalKills);
        
        memo.add(logKill);
        memo.add(session.logContent("Players", session.players.txt));

    }

    private void GetRankingKills(ParserSession session, bool details)
    {

        memo.add(session.logGroup("Kills Score"));

        foreach (Player player in session.rankingKills)
        {
            var name = player.name;

            var score = session.totalScore(name);

            var log = "";

            if (details)
            {
                var scoreKills = session.totalScoreKills(name);
                var scoreDeadByWorld = session.totalScoreDeadByWorld(name);
                var scoreDeadByPlayer = session.totalScoreDeadByPlayer(name);

                log = session.logScorePlayerDetails(name, score, scoreKills, scoreDeadByWorld, scoreDeadByPlayer);
            }
            else 
                log = session.logScorePlayer(name, score);
             
            memo.add(log);
        }
    }

    private void GetRankingCauses(ParserSession session, bool details)
    {
       
        memo.add(session.logGroup("Death Cause"));
        
        foreach (CauseDeath cause in session.rankingCauses)
        {
            var name = cause.name;

            var score = session.totalScoreCause(name);

            var log = "";

            if (details)
            {
                var scoreByWorld = session.totalScoreCauseByWorld(name);
                var scoreByPlayer = session.totalScoreCauseByPlayer(name);

                log = session.logScoreCauseDetails(name, score, scoreByWorld, scoreByPlayer);         
            }
            else
                log = session.logScoreCause(name, score);

            memo.add(log);
        }

    }        
    



}
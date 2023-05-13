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

        memo.add(session.logLine('='));
        memo.add(session.logContent("Game", session.tag));
        memo.add(session.logKills("Total Kills", session.totalKills, session.totalKillsByWorld, session.totalKillsByPlayer));
        memo.add(session.logContent("Players", session.players.txt));

        GetRankingKills(session);

        GetRankingCauses(session);

    }

    private void GetRankingKills(ParserSession session)
    {

        memo.add(session.logGroup("Score by Kills"));

        foreach (Player player in session.rankingKills)
        {
            var name = player.name;

            var score = session.totalScore(name);
            var scoreKills = session.totalScoreKills(name);
            var scoreDeadByWorld = session.totalScoreDeadByWorld(name);
            var scoreDeadByPlayer = session.totalScoreDeadByPlayer(name);

            memo.add(session.logScorePlayer(name, score, scoreKills, scoreDeadByWorld, scoreDeadByPlayer));
        }
    }

    private void GetRankingCauses(ParserSession session)
    {
       
        memo.add(session.logGroup("Cause of Death"));
        
        foreach (CauseDeath cause in session.rankingCauses)
        {
            var name = cause.name;

            var score = session.totalScoreCause(name);
            var scoreByWorld = session.totalScoreCauseByWorld(name);
            var scoreByPlayer = session.totalScoreCauseByPlayer(name);

            memo.add(session.logScoreCause(name, score, scoreByWorld, scoreByPlayer));
        }

    }        
    



}
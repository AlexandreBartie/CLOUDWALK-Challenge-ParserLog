using lib;

namespace parser.data.model;

public class ViewFormat
{
    private const int SIZE_LINE = 90;
    private const int COLUMN_LABEL = 20;
    private const int COLUMN_TYPE = 10;

    private const int COLUMN_VALUE = 3;

    public const string FORMAT_NUMBER = "##0";

    public string logTitle(string title, string subTitle = "")
    {
        if (subTitle != "")
            title = $"{title}: {subTitle}";

        return logBlock(title, true, false);
    }

    public string logBottom(string title)
    {
        return logBlock(title, true, true);
    }
    private string logBlock(string title, bool top, bool bottom)
    {
        var memo = new Memo();

        char markTop; char markBottom;

        if (bottom)
        { markTop = '-'; markBottom = '='; }
        else
        { markTop = '='; markBottom = '-'; }

        if (top)
            memo.add(logLine(markTop));

        memo.add(Text.TabCentralize(title, SIZE_LINE));

        if (bottom)
            memo.add(logLine(markBottom));

        return memo.txt;
    }

    public string logGroup(string group)
    {
        var memo = new Memo();

        memo.add(logLine());
        memo.add(logContent(group));

        return memo.txt;
    }
    public string logLine(char mark = '-')
    {
        return Text.Repeat(mark, SIZE_LINE);
    }

    public string logKills(string label, int kills, string details = "")
    {
        var logKills = FormatValue(kills);

        var content = $"{logKills}{details}";

        return logContent(label, content);
    }

    public string logKillsDetails(string label, int kills, int killsByWorld, int killsByPlayer)
    {
        var logkillsByWorld = FormatTupla(killsByWorld, "byWorld");
        var logkillsByPlayer = FormatTupla(killsByPlayer, "byPlayer");

        var details = $" [ {logkillsByWorld} | {logkillsByPlayer} ]";

        return logKills(label, kills, details);
    }

    public string logScorePlayer(string player, int score, string details = "")
    {
        var label = "-" + player;
        var logScore = FormatTupla(score, "points");

        var content = $"{logScore}{details}";

        return logContent(label, content);
    }

    public string logScorePlayerDetails(string player, int score, int scoreKills, int scoreDeadByWorld, int scoreDeadByPlayer)
    {
        
        var logScoreKills = FormatTupla(scoreKills, "kills");
        var logScoreDeadByWorld = FormatTupla(scoreDeadByWorld, "byWorld");
        var logScoreDeadByPlayer = FormatTupla(scoreDeadByPlayer, "byPlayer");

        var details = $" | {logScoreKills} [ deads: {logScoreDeadByWorld} | {logScoreDeadByPlayer} ]";

        return logScorePlayer(player, score, details);
    }


    public string logScoreCause(string cause, int score, string details = "")
    {
        var label = "-" + cause;
        var logScore = FormatTupla(score, "deaths");

        var content = $"{logScore}{details}";

        return logContent(label, content);
    }

    public string logScoreCauseDetails(string cause, int score, int scoreByWorld, int scoreByPlayer)
    {
        var type = "";
        
        if (scoreByWorld != 0)
            type = "byWorld";
        
        if (scoreByPlayer != 0)
            type = "byPlayer";

        var details = $" [ {FormatType(type)} ]";

        return logScoreCause(cause, score, details);
    }

    public string logContent(string label, string content = "")
    { return $"{FormatLabel(label)}: {content}"; }

    private string FormatLabel(string label) => label.PadLeft(COLUMN_LABEL);
    private string FormatTupla(int value, string unit) => $"{FormatValue(value)} {unit}";
    private string FormatValue(int value) => value.ToString(FORMAT_NUMBER).PadLeft(COLUMN_VALUE);
    private string FormatType(string type) => type.PadRight(COLUMN_TYPE);

}
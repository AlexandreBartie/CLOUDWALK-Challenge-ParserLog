using lib;

namespace parser.data.model;

public class ViewFormat
{
    private const int SIZE_LINE = 90;
    private const int COLUMN_LABEL = 20;

    private const int COLUMN_VALUE = 3;
    private const int COLUMN_UNIT = 8;
    private const int COLUMN_COUNT = 5;

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

    public string logKills(string label, int kills, int killsByWorld, int killsByPlayer)
    {
        var logKills = FormatValue(kills);
        var logkillsByWorld= FormatTupla(killsByWorld, "byWorld");
        var logkillsByPlayer = FormatTupla(killsByPlayer, "byPlayer");

        var content = $"{logKills} [ {logkillsByWorld} | {logkillsByPlayer} ]";

        return logContent(label, content);
    }


    public string logScorePlayer(string player, int score, int scoreKills, int scoreDeadByWorld, int scoreDeadByPlayer)
    {
        var label = "-"+ player;
        var logScore = FormatTupla(score, "points");
        var logScoreKills = FormatTupla(scoreKills, "kills");
        var logScoreDeadByWorld = FormatTupla(scoreDeadByWorld, "byWorld");
        var logScoreDeadByPlayer = FormatTupla(scoreDeadByPlayer, "byPlayer");

        var content = $"{logScore} | {logScoreKills} [ deads: {logScoreDeadByWorld} | {logScoreDeadByPlayer} ]";

        return logContent(label, content);
    }

    public string logScoreCause(string cause, int score, int scoreByWorld, int scoreByPlayer)
    {
        var label = "-"+ cause;
        var logScore = FormatTupla(score, "deaths");
        var logScoreByWorld = FormatTupla(scoreByWorld, "byWorld");
        var logScoreByPlayer = FormatTupla(scoreByPlayer, "byPlayer");

        var content = $"{logScore} [ {logScoreByWorld} | {logScoreByPlayer} ]";

        return logContent(label, content);
    }

    public string logContent(string label, string content = "")
    { return $"{FormatLabel(label)}: {content}"; }

    private string FormatLabel(string label) => label.PadLeft(COLUMN_LABEL);
    private string FormatTupla(int value, string unit) => $"{FormatValue(value)} {unit}";
    private string FormatValue(int value) => value.ToString(FORMAT_NUMBER).PadLeft(COLUMN_VALUE);
    private string FormatCount(int count) => count.ToString(FORMAT_NUMBER).PadLeft(COLUMN_COUNT);

}
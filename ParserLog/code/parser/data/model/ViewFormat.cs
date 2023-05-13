using lib;

namespace parser.data.model;

public class ViewFormat : ViewFormatSpotLight
{
    private const int SIZE_LINE = 80;
    private const int COLUMN_LABEL = 25;

    private const int COLUMN_VALUE = 10;
    private const int COLUMN_UNIT = 8;
    private const int COLUMN_COUNT = 5;

    private const string LABEL_POINTS = "points";
    private const string LABEL_KILLS = "kills";
    private const string LABEL_DEAD_BY_WORLD = "deadByWorld";
    private const string LABEL_DEAD_BY_PLAYER = "deadByPlayer";
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

    public string logLine(char mark = '-')
    {
        return Text.Repeat(mark, SIZE_LINE);
    }

    public string GetLogScorePlayer(string player, int score, int scoreKills, int scoreDeadByWorld, int scoreDeadByPlayer)
    {
        var logScore = FormatTupla(score, "points");
        var logScoreKills = FormatTupla(scoreKills, "kills");
        var logScoreDeadByWorld = FormatTupla(scoreDeadByWorld, "deadByWorld");
        var logScoreDeadByPlayer = FormatTupla(scoreDeadByPlayer, "deadByPlayer");

        return $"{FormatLabel(player)}: {logScore} [{logScoreKills} {logScoreDeadByWorld} {logScoreDeadByPlayer}]";
    }

    private string FormatLabel(string label) => label.PadRight(COLUMN_LABEL);
    private string FormatTupla(int value, string unit) => $"{FormatValue(value)} {unit}";
    private string FormatValue(int value) => value.ToString(FORMAT_NUMBER).PadLeft(COLUMN_VALUE);
    private string FormatCount(int count) => count.ToString(FORMAT_NUMBER).PadLeft(COLUMN_COUNT);


}

public class ViewFormatSpotLight
{

    private const int COLUMN_CREATURE = 16;

    private const int COLUMN_POINTS = 12;

    public const string FORMAT_NUMBER = "##,###,##0";

    private string FormatCreature(string creature, int level) => Text.TabLevel(creature.PadRight(COLUMN_CREATURE), level, 1);
    private string FormatColumn(string column, int size = COLUMN_POINTS) => column.PadLeft(size);
    private string FormatPoints(int value) => value.ToString(FORMAT_NUMBER).PadLeft(COLUMN_POINTS);

    public string GetSpotlight(string creature, int damagePlayer, int lostPower, int healedPower)
    {
        return $"{FormatCreature(creature, 1)} {FormatPoints(damagePlayer)} {FormatPoints(lostPower)} {FormatPoints(healedPower)}";
    }

}
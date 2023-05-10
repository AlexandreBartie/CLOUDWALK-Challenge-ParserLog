using parser.lib;

namespace parser.data.format;

public class ViewFormat : ViewFormatSpotLight
{
    private const int SIZE_LINE = 60;
    private const int COLUMN_LABEL = 25;

    private const int COLUMN_VALUE = 10;
    private const int COLUMN_UNIT = 8;
    private const int COLUMN_COUNT = 5;

    private const string LABEL_POINTS = "points";
    private const string LABEL_ITEMS = "items";

    public string logTitle(string title)
    {
        return logBlock(title, true);
    }

    public string logSubTitle(string title, string subTitle)
    {
        return logTitle($"{title}: {subTitle}");
    }

    public string logEnd(string title)
    {
        return logBlock(title, false);
    }
    private string logBlock(string title, bool start)
    {
        var memo = new Memo();

        char markTop; char markBottom;

        if (start)
        { markTop = '='; markBottom = '-'; }
        else
        { markTop = '-'; markBottom = '='; }

        memo.add(logLine(markTop));
        memo.add(Text.TabCentralize(title, SIZE_LINE));
        memo.add(logLine(markBottom));

        return memo.txt;
    }

    private string logLine(char mark = '=')
    {
        return Text.Repeat(mark, SIZE_LINE);
    }

    public string GetLogPoints(string title, int value, int count, int tab = 1)
    {
        return GetLog(title, value, count, LABEL_POINTS, tab);
    }

    public string GetLogItems(string item, int value, int count, int tab = 1)
    {
        return GetLog(item, value, count, LABEL_ITEMS, tab);
    }

    private string GetLog(string label, int value, int count, string unit, int level)
    {
        return $"{FormatLabel(label, level)} {FormatValue(value)} {FormatUnit(unit)} {FormatCount(count)}#";
    }

    private string FormatLabel(string label, int level) => Text.TabLevel(label.PadRight(COLUMN_LABEL), level, 3);
    private string FormatUnit(string unit) => unit.PadRight(COLUMN_UNIT);
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

    public string logColumns()
    {
        var columnCreature = "Creature Name";
        var columnDamage = "DamagePlayer";
        var columnLost = "LostPower";
        var columnHealed = "HealedPower";

        return $"{Text.Spaces(02)}{columnCreature}{Text.Spaces(5)}{columnDamage}{Text.Spaces(4)}{columnLost}{Text.Spaces(2)}{columnHealed}";
    }

    public string GetSpotlight(string creature, int damagePlayer, int lostPower, int healedPower)
    {
        return $"{FormatCreature(creature, 1)} {FormatPoints(damagePlayer)} {FormatPoints(lostPower)} {FormatPoints(healedPower)}";
    }

}
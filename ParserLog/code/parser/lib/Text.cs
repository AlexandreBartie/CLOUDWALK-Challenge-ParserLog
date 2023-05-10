using System.Text.RegularExpressions;

namespace parser.lib;

public static class Text
{

    public static bool IsMatchByWildcard(string text, string wildcard)
    {

        string[] patterns = wildcard.Split(",");

        foreach (string pattern in patterns)
        {
            // Escape any special characters in the pattern, 
            // replace the asterisk wildcard with a regex pattern
            string regexPattern = Regex.Escape(pattern.Trim()).Replace(@"\*", ".*");

            // Use the regex pattern to match the text
            if (Regex.IsMatch(text, regexPattern, RegexOptions.IgnoreCase))
                return true;

        }

        return false;

    }

    public static bool IsMatch(string str1, string str2, bool ignorePlural = false)
    {
        str1 = str1.Trim();
        str2 = str2.Trim();

        if (ignorePlural)
        {
            str1 = str1.TrimEnd('s');
            str2 = str2.TrimEnd('s');
        }

        return string.Equals(str1, str2, StringComparison.OrdinalIgnoreCase);
    }

    public static bool IsPlural(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return false; // the input string is empty or null, so the last character cannot be "s" or "S"
        }

        char lastChar = input[input.Length - 1];

        return (lastChar == 's' || lastChar == 'S');
    }

    public static string Spaces(int times)
    { return Repeat(" ", times); }

    public static string Repeat(string text, int times)
    { return string.Concat(Enumerable.Repeat(text, times)); }

    public static string Repeat(char text, int times)
    { return new string(text, times); }

    public static string Tab(int index, int size = 2)
    { return Repeat(' ', index * size); }

    public static string TabLevel(string text, int level, int max, string mark = "-")
    {

        string prefix = (level <= 1) ? "" : mark;

        string start = Tab(level).Substring(prefix.Length);
        string end = Tab(max - level);

        return start + prefix + text + end;
    }

    public static string TabCentralize(string text, int size)
    {
        return text.PadLeft((size - text.Length) / 2 + text.Length).PadRight(size);
    }

}


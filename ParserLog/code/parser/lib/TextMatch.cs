using System.Text.RegularExpressions;

namespace parser.lib;

public class TextMatch
{
    private Match match;

    public bool IsMatch => match.Success;

    public TextMatch(string text, string pattern)
    {
        match = Regex.Match(text, pattern);
    }

    public string GetParameter(int index)
    {
        return match.Groups[index].Value.Trim();
    }

}
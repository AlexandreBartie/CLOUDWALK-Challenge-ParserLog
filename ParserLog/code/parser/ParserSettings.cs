
namespace parser;

public class ParserSettings : ParserSettingsData
{
    public readonly ParserShow show = new();

    public string GetInputFileFolder(string path)
    {
        if (path == "")
            path = fileFolder;

        return path + "input/"; ;
    }

    public string GetOutputFileFolder(string path)
    {
        if (path == "")
            path = fileFolder;

        return path + "output/";
    }


}

public class ParserShow
{

    public bool ResumeGame = true;
    public bool RankingKills = true;
    public bool RankingCauses = true;

    public bool KillDetails = true;
}

public class ParserSettingsData
{

    private string _fileFolder = "";

    public string FileFolder
    {
        get
        {
            if (_fileFolder == "")
                _fileFolder = AppDomain.CurrentDomain.BaseDirectory;

            return _fileFolder;
        }
        set
        {
            _fileFolder = value;
        }
    }

}


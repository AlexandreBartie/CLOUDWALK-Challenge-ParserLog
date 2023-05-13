
namespace parser;

public class ParserSettings : ParserSettingsData
{
    public readonly ParserShow show = new();

    public string GetInputFileFolder(string path)
    {
        if (path == "")
            path = GetFileFolder();

        return path + "input/"; ;
    }

    public string GetOutputFileFolder(string path)
    {
        if (path == "")
            path = GetFileFolder();

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

    public void SetFileFolder(string path)
    {
        _fileFolder = path;
    }

    public string GetFileFolder()
    {
        if (_fileFolder == "")
{
#if DEBUG

            _fileFolder = "C:/DEVOPS/CHALLENGE/CLOUDWALK/Challenge-ParserLog/file/";

#else

            _fileFolder = AppDomain.CurrentDomain.BaseDirectory;

#endif
}



        return _fileFolder;
    }

}


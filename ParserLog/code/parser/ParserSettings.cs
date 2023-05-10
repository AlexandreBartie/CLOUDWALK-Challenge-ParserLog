
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

public class ParserSettingsData
{

    protected string fileFolder
    {

        get
        {

            var fileFolder = "";

#if DEBUG
            fileFolder = "C:/DEVOPS/CHALLENGE/BLEU/Challenge-ParserLog/file/";
#else
            fileFolder = AppDomain.CurrentDomain.BaseDirectory;
#endif

            return fileFolder;
        }

    }
}


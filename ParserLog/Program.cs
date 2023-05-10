namespace parser;

class Program
{

    static void Main(string[] args)
    {

        if (args.Length == 0)
        {
            Console.WriteLine("Please, add a file name as a parameter.");
            Console.WriteLine(" -The file needs to be in the same path of the executable.");
            Console.WriteLine(" -Use a second optional parameter to focus data of creatures!");
            Console.WriteLine("");
            Console.WriteLine("""** Sintaxe: Parserlog {FileName} {Creatures wildcard}""");
            Console.WriteLine("""** Example: Parserlog "Session-Full.txt" *Knight*,cyclops*""");

            Environment.Exit(-1);
        }

        var app = new StartApp();

        string fileName;
        string creatureRules;

#if DEBUG
        fileName = "Session-Full.txt";
        creatureRules = "*Knight*"; // "cyclop*, dragon*"; //
#else
        fileName = args[0];
        creatureRules = (args.Length >= 2) ? args[1] : "";
#endif

        app.Run(fileName, creatureRules);

    }

}

class StartApp
{
    public readonly ParserLog parser = new();

    public StartApp()
    {
        parser.show.PlayerStatistics = false;
        parser.show.CreatureStatistics = true;
        parser.show.LootedItems = false;
        parser.show.CreatureSpotlight = true; // Extra Challenge
    }

    public void Run(string fileName, string creatureRules)
    {

        // Set rules for spotlight creatures
        parser.SetSpotlight(creatureRules);

        // Set file will be opened file will be opened
        if (parser.LoadFile(fileName))
        {
            Console.WriteLine(parser.txt);
        }
        else
            Environment.Exit(-1);
    }

}





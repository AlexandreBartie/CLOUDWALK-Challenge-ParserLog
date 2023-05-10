using System.Text;

namespace parser.lib;

public class FileTXT
{

    public string[] lines = new string[0];

    public string path = "";
    public string name = "";

    public string fullName => path + name;

    public bool isValid => System.IO.File.Exists(fullName);

    private Encoding encoding = Encoding.UTF8;

    public void SetEncoding(Encoding prmEncoding) => encoding = prmEncoding;

    public bool Open(string path, string name)
    {

        try
        {

            this.path = path;
            this.name = name;

            if (isValid)
            {
                if ((encoding == null))
                    lines = System.IO.File.ReadAllLines(fullName);
                else
                    lines = System.IO.File.ReadAllLines(fullName, encoding);

                return (true);
            }
            else
            {
                Console.WriteLine("Dont exist this path!");
                Console.WriteLine(fullName);
            }

        }

        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

        return (false);

    }

}

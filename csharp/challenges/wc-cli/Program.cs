// ./cli -c a.txt
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

if (args.Length != 2)
{
    Console.WriteLine("""
        Usage: ./wc-cli [switch] [file]
        List of available switch:
        -c | list bytes of file
        -l | list of lines of file
        """);
    return;
}

var target = args[1];
if (!File.Exists(target))
{
    Console.WriteLine("The specificed file does not exist");
    return;
}

if (args[0] == "-c")
{
    var bytes = await File.ReadAllBytesAsync(target);
    Console.WriteLine($"{bytes.Length} {target}");
    return;
}
// wc always reports 1 lines if the last line of a file does not contain a newline character 
else if (args[0] == "-l")
{
    var lines = await File.ReadAllLinesAsync(target);
    Console.WriteLine($"{lines.Length} {target}");
    return;
}
else if (args[0] == "-w")
{
    var text = await File.ReadAllTextAsync(target, Encoding.UTF8);
    var inWord = false;
    var wordCount = 0;
    for (var i = 0; i < text.Length; i++)
    {
        if (!Char.IsWhiteSpace(text[i]))
        {
            if (inWord == false)
            {
                inWord = true;
                wordCount++;
            }
        }
        else
        {
            inWord = false;
        }
    }
    Console.WriteLine($"{wordCount} {target}");
    return;
}
else if (args[0] == "-m")
{
    var text = await File.ReadAllTextAsync(target, Encoding.UTF8);
    Console.WriteLine($"{text.Length} {target}");
}
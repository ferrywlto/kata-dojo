// ./cli -c a.txt
using System.Text;

var target = args.Length switch
{
    1 => args[0],
    _ => args[1], 
};

if (!File.Exists(target))
{
    Console.WriteLine("The specificed file does not exist");
    return;
}

if (args.Length == 1)
{
    var bytes = await CountBytes(target);
    var lines = await CountLines(target);
    var words = await CountWords(target);
    Console.WriteLine($"{lines,10}\t{words,10}\t{bytes,10}\t{target}");
    return;
}
else if (args[0] == "-c")
{
    Print(await CountBytes(target), target);
    return;
}
// wc always reports 1 lines if the last line of a file does not contain a newline character 
else if (args[0] == "-l")
{
    Print(await CountLines(target), target);
    return;
}
else if (args[0] == "-w")
{
    Print(await CountWords(target), target);
    return;
}
else if (args[0] == "-m")
{
    Print(await CountCharacters(target), target);
}
else 
{
    Console.WriteLine("""
        Usage: ./wc-cli [switch] [file]
        List of available switch:
        -c | list bytes of file
        -l | list of lines of file
        """);
    return;    
}

async Task<int> CountBytes(string target)
{
    var bytes = await File.ReadAllBytesAsync(target);
    return bytes.Length;
}

async Task<int> CountLines(string target)
{
    var lines = await File.ReadAllLinesAsync(target);
    return lines.Length;
}

async Task<int> CountWords(string target)
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
    return wordCount;
}

async Task<int> CountCharacters(string target)
{
    var text = await File.ReadAllTextAsync(target, Encoding.UTF8);
    return text.Length;
}

void Print(int num, string target) => Console.WriteLine($"{num} {target}");
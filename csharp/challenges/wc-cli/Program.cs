using System.Text;

string[] lines;
string text;
string target;

if (args.Length == 0)
{
    lines = await ReadLinesFromStandardInput();
    Console.WriteLine(GetAllStats(lines));
    return;
}
else
{
    if (args.Length == 1)
    {
        if (args[0].StartsWith('-')) // switch only
        {
            lines = await ReadLinesFromStandardInput();
            if (args[0] == "-l")
            {
                Console.WriteLine(lines.Length); 
                return;
            }
            else
            {
                text = string.Join(Environment.NewLine, lines);

                if (args[0] == "-w")
                {
                    Console.WriteLine(CountWords(text));
                    return;
                }
                else if (args[0] == "-m")
                {
                    Console.WriteLine(text.Length);
                    return;
                }
                else if (args[0] == "-c")
                {
                    var bytes = Encoding.UTF8.GetBytes(text);
                    Console.WriteLine(bytes.Length);
                    return;
                }
                else
                {
                    Console.WriteLine(
                    """
                    Usage: ./wc-cli [switch] [file]
                    List of available switch:
                    -c | count bytes in file
                    -l | count lines in file
                    -w | count words in file
                    -m | count characters in file
                    omit switch | count lines, words and bytes in file
                    without parameter | count lines, words and bytes from standard input
                """);
                    return;
                }
            }
        }
        else // file name only
        {
            target = args[0];
            if (!File.Exists(target))
            {
                Console.WriteLine("The specificed file does not exist");
                return;
            }
            lines = await File.ReadAllLinesAsync(target, Encoding.UTF8);
            Console.WriteLine(GetAllStats(lines));
            return;
        }
    }
    else 
    {
        target = args[1];
        lines = await File.ReadAllLinesAsync(target, Encoding.UTF8);
        if (!File.Exists(target))
        {
            Console.WriteLine("The specificed file does not exist");
            return;
        }
        if (args.Length == 1)
        {
            Console.WriteLine($"{GetAllStats(lines)}\t{target}");
            return;
        }
        // wc always reports 1 lines if the last line of a file does not contain a newline character 
        else if (args[0] == "-l")
        {
            Print(lines.Length, target);
            return;
        }
        else
        {
            text = string.Join(Environment.NewLine, lines);

            if (args[0] == "-w")
            {
                Print(CountWords(text), target);
                return;
            }
            else if (args[0] == "-m")
            {
                Print(text.Length, target);
                return;
            }
            else if (args[0] == "-c")
            {
                var bytes = Encoding.UTF8.GetBytes(text);
                Print(bytes.Length, target);
                return;
            }
            else
            {
                Console.WriteLine(
                """
                    Usage: ./wc-cli [switch] [file]
                    List of available switch:
                    -c | count bytes in file
                    -l | count lines in file
                    -w | count words in file
                    -m | count characters in file
                    omit switch | count lines, words and bytes in file
                    without parameter | count lines, words and bytes from standard input
                """);
                return;
            }
        }
    }
}

async Task<string[]> ReadLinesFromStandardInput()
{
    var lines = new List<string>();
    var stream = Console.OpenStandardInput();
    var sc = new StreamReader(stream);
    string? line;
    while ((line = await sc.ReadLineAsync()) != null)
    {
        lines.Add(line);
    }
    return lines.ToArray();
}

string GetAllStats(string[] lines)
{
    var lineCount = lines.Length;
    var text = string.Join(Environment.NewLine, lines);

    var wordCount = CountWords(text);

    var bytes = Encoding.UTF8.GetBytes(text);

    var byteCount = bytes.Length;

    return $"{lineCount,10}\t{wordCount,10}\t{byteCount,10}";
}

int CountWords(string input)
{
    var inWord = false;
    var wordCount = 0;
    for (var i = 0; i < input.Length; i++)
    {
        if (!char.IsWhiteSpace(input[i]))
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

void Print(int num, string target) => Console.WriteLine($"{num} {target}");
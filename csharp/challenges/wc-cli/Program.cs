using System.Text;

string[] lines;

if (args.Length == 0)
{
    lines = await ReadLinesFromStandardInput();
    Console.WriteLine(GetAllStats(lines));
}
else if ((args.Length == 1) && args[0].StartsWith('-'))
{
    lines = await ReadLinesFromStandardInput();
    var count = ProcessCommand(args[0], lines);
    if (count != -1) Console.WriteLine(count);
}
else if (args.Length == 1)
{
    lines = await ReadLinesFromFile(args[0]);
    if (lines.Length == 0) return;

    Console.WriteLine(GetAllStats(lines));
}
else 
{
    lines = await ReadLinesFromFile(args[1]);
    if (lines.Length == 0) return;

    var count = ProcessCommand(args[0], lines);
    if(count != -1) Console.WriteLine($"{count} {args[1]}");
}
async Task<string[]> ReadLinesFromFile(string input)
{
    if (!File.Exists(input)) 
    {
        Console.WriteLine("The specificed file does not exist");
        return [];
    }
    return await File.ReadAllLinesAsync(input, Encoding.UTF8);
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
int ProcessCommand(string command, string[] lines)
{
    if (command == "-l")  return lines.Length;
    else
    {
       var text = string.Join(Environment.NewLine, lines);
        // wc always reports 1 lines if the last line of a file does not contain a newline character 
        if (command == "-w") return CountWords(text);
        else if (command == "-m") return text.Length;
        else if (command == "-c")
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            return bytes.Length;
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
            return -1;
        }
    }
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
        else inWord = false;
    }
    return wordCount;
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
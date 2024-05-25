// ./cli -c a.txt
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

if(args[0] == "-c")
{
    var bytes = await File.ReadAllBytesAsync(target);
    Console.WriteLine($"{bytes.Length} {target}");
    return;
}
else if(args[0] == "-l")
{
    var lines = await File.ReadAllLinesAsync(target);
    Console.WriteLine($"{lines.Length} {target}");
}
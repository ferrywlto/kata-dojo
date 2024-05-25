// ./cli a.txt
// ./cli a.txt b.txt
// ./cli -c a.txt
if(args.Length == 2 && args[0] == "-c")
{
    var target = args[1];
    if (!File.Exists(target))
    {
        Console.WriteLine("The specificed file does not exist");
        return;
    }

    var bytes = await File.ReadAllBytesAsync(target);
    Console.WriteLine($"{bytes.Length} {target}");
}

using System.Diagnostics;

namespace dojo.leetcode;

public class ShellTest(ITestOutputHelper output) : TestBase(output)
{
    // Use "/bin/bash" for Linux/Mac, "cmd.exe" for Windows
    protected virtual string Shell => "/bin/bash";

    protected string Run(string command)
    {
        var processInfo = new ProcessStartInfo
        {
            FileName = Shell,
            Arguments = $"-c \"{command}\"",    // Replace "your command here" with your shell command
            UseShellExecute = false,            // Do not use OS shell, need to be false for RedirectStandardOutput set to true
            RedirectStandardOutput = true       // Any output, generated by a process is redirected back
        };

        string result = string.Empty;
        using (var process = Process.Start(processInfo))
        {
            // Read the output stream first and then wait.
            result = process!.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // log the output
            output.WriteLine(result);
        }
        return result;
    }
}

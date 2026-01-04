// TC: O(n), n scale with number of input commands.
// SC: O(n), worst case all commands are "visit", then history list contains all urls 
public class BrowserHistory
{
    private readonly List<string> history = [];
    private int historyIdx = 0;
    public BrowserHistory(string homepage)
    {
        history.Add(homepage);
    }

    public void Visit(string url)
    {
        var maxLen = history.Count - 1;
        if (historyIdx != maxLen)
        {
            history.RemoveRange(historyIdx + 1, maxLen - historyIdx);
        }

        history.Add(url);
        historyIdx++;
    }

    public string Back(int steps)
    {
        historyIdx -= steps;
        if (historyIdx < 0) historyIdx = 0;

        return history[historyIdx];
    }

    public string Forward(int steps)
    {
        historyIdx += steps;
        if (historyIdx >= history.Count)
            historyIdx = history.Count - 1;

        return history[historyIdx];
    }
}

public class Q1742_DesignBrowserHistory(ITestOutputHelper output)
{
    public static TheoryData<string[], string[], string?[]> TestData => new()
    {
        {
            ["BrowserHistory", "visit","visit","visit","back","back","forward","visit","forward","back","back"],
            ["leetcode.com","google.com","facebook.com","youtube.com","1","1","1","linkedin.com","2","2","7"],
            [null,null,null,null,"facebook.com","google.com","facebook.com",null,"linkedin.com","google.com","leetcode.com"]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] commands, string[] parameters, string?[] expected)
    {
        var browser = new BrowserHistory(parameters[0]);
        for (var i = 1; i < commands.Length; i++)
        {
            output.WriteLine($"cmd: {commands[i]}, param: {parameters[i]}, expected: {expected[i]}");
            if (commands[i] == "back")
            {
                Assert.Equal(expected[i], browser.Back(int.Parse(parameters[i])));
            }
            else if (commands[i] == "forward")
            {
                Assert.Equal(expected[i], browser.Forward(int.Parse(parameters[i])));
            }
            else if (commands[i] == "visit")
            {
                browser.Visit(parameters[i]);
            }
        }
    }
}

public class BrowserHistory
{

    public BrowserHistory(string homepage)
    {

    }

    public void Visit(string url)
    {

    }

    public string Back(int steps)
    {
        return "";
    }

    public string Forward(int steps)
    {
        return "";
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */

public class Q1742_DesignBrowserHistory
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
        for(var i=1; i<commands.Length; i++)
        {
            if(commands[i] == "back")
            {
                Assert.Equal(expected[i], browser.Back(int.Parse(parameters[i])));
            }
            else if(commands[i] == "forward")
            {
                Assert.Equal(expected[i], browser.Forward(int.Parse(parameters[i])));
            }
            else if(commands[i] == "visit")
            {
                browser.Visit(parameters[i]);
            }
        }
    }
}

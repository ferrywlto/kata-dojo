namespace dojo.leetcode;

public class Q500_KeyboardRow
{
    private const string row1 = "qwertyuiop";
    private const string row2 = "asdfghjkl";
    private const string row3 = "zxcvbnm";
    private readonly string rowAll = row1 + row2 + row3;
    private readonly Dictionary<int, (int, int)> Ranges = new()
    {
        {1, (0, row1.Length-1) },
        {2, (row1.Length, row1.Length + row2.Length-1) },
        {3, (row1.Length + row2.Length, row1.Length + row2.Length + row3.Length-1) },
    };

    private bool InOneRow(string input)
    {
        if (input.Length == 0) return false;

        var firstChar = input[0];

        int range;
        if (row1.Contains(firstChar))
        {
            range = 1;
        }
        else if (row2.Contains(firstChar))
        {
            range = 2;
        }
        else
        {
            range = 3;
        }
        var (min, max) = Ranges[range];

        for(var i=1; i<input.Length; i++)
        {
            var idx = rowAll.IndexOf(input[i]);

            if (idx < min || idx > max) return false;
        }
        return true;
    }
    
    // TC: O(n), SC: O(n)
    public string[] FindWords(string[] words)
    {
        var result = new List<string>();

        foreach(var w in words)
        {
            var lower = w.ToLower();
            if (InOneRow(lower)) result.Add(w);
        }
        return result.ToArray();        
    }
}

public class Q500_KeyboardRowTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new string[] {"Hello", "Alaska", "Dad", "Peace"}, new string[] {"Alaska", "Dad"}],
        [new string[] {"omk"}, Array.Empty<string>()],
        [new string[] {"adsdf", "sfd"}, new string[] {"adsdf", "sfd"}],
    ];
}

public class Q500_KeyboardRowTests
{
    [Theory]
    [ClassData(typeof(Q500_KeyboardRowTestData))]
    public void OfficialTestCases(string[] words, string[] expected)
    {
        var sut = new Q500_KeyboardRow();
        var actual = sut.FindWords(words);
        Assert.Equal(expected, actual);
    }
}
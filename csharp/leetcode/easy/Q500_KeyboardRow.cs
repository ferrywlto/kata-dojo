class Q500_KeyboardRow
{
    private readonly HashSet<char> row1 = new("qwertyuiop");
    private readonly HashSet<char> row2 = new("asdfghjkl");
    private readonly HashSet<char> row3 = new("zxcvbnm");

    private bool InOneRow(string input)
    {
        if (input.Length == 0) return false;

        var firstChar = input[0];

        HashSet<char> row;
        if (row1.Contains(firstChar)) row = row1;
        else if (row2.Contains(firstChar)) row = row2;
        else row = row3;

        for(var i=1; i<input.Length; i++)
        {
            if (!row.Contains(input[i])) return false;
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

class Q500_KeyboardRowTestData : TestData
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
public class Q3707_EqualScoreSubstrings
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used is constant
    public bool ScoreBalance(string s)
    {
        var total = 0;
        foreach (var ch in s) total += ch - 'a' + 1;

        var left = s[0] - 'a' + 1;
        var right = total - left;
        if (left == right) return true;

        for (var i = 1; i < s.Length; i++)
        {
            left += s[i] - 'a' + 1;
            right -= s[i] - 'a' + 1;
            if (left == right) return true;
        }
        return false;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        { "adcb", true },
        { "bace", false },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string s, bool expected)
    {
        var result = ScoreBalance(s);
        Assert.Equal(expected, result);
    }
}

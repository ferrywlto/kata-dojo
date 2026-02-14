public class Q3110_ScoreOfString
{
    // TC: O(n), n scale with length of s
    // SC: O(1), space used does not scale with input
    public int ScoreOfString(string s)
    {
        var result = 0;
        for (var i = 1; i < s.Length; i++)
        {
            result += Math.Abs(s[i - 1] - s[i]);
        }
        return result;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"hello", 13},
        {"zaz", 50},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = ScoreOfString(input);
        Assert.Equal(expected, actual);
    }
}

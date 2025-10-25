public class Q3707_EqualScoreSubstrings
{
    public bool ScoreBalance(string s)
    {
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

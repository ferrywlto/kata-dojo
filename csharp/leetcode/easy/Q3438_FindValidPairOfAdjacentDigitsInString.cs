public class Q3438_FindValidPairOfAdjacentDigitsInString
{
    public string FindValidPair(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"2523533", "23"},
        {"221", "21"},
        {"22", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = FindValidPair(input);
        Assert.Equal(input, expected);
    }
}
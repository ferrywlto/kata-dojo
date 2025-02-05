public class Q3114_LatestTimeYouCanObtainAfterReplacingCharacters
{
    public string FindLatestTime(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"1?:?4", "11:54"},
        {"0?:5?", "09:59"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = FindLatestTime(input);
        Assert.Equal(expected, actual);
    }
}
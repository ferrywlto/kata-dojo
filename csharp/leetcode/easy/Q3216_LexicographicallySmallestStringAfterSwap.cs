public class Q3216_LexicographicallySmallestStringAfterSwap
{
    public string GetSmallestString(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"45320", "43520"},
        {"001", "001"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = GetSmallestString(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2375_ConstructSmallestNumberFromDIString
{
    public string SmallestNumber(string pattern)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"IIIDIDDD", "123549876"},
        {"DDD", "4321"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = SmallestNumber(input);
        Assert.Equal(expected, actual);
    }
}
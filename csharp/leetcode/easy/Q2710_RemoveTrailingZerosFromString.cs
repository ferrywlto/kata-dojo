public class Q2710_RemoveTrailingZerosFromString
{
    public string RemoveTrailingZeros(string num)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"51230100", "512301"},
        {"123", "123"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = RemoveTrailingZeros(input);
        Assert.Equal(expected, actual);
    }
}
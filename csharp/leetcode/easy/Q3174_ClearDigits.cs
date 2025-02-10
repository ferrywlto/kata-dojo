public class Q3174_ClearDigits
{
    public string ClearDigits(string s)
    {
        return string.Empty;
    }
    public static TheoryData<string, string> TestData => new()
    {
        {"abc", "abc"},
        {"cb34", ""},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = ClearDigits(input);
        Assert.Equal(expected, actual);
    }
}
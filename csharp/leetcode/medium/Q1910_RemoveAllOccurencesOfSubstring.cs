public class Q1910_RemoveAllOccurencesOfSubstring
{
    public string RemoveOccurrences(string s, string part)
    {
        return string.Empty;
    }
    public static TheoryData<string, string, string> TestData => new()
    {
        {"daabcbaabcbc", "abc", "dab"},
        {"axxxxyyyyb", "xy", "ab"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string substring, string expected)
    {
        var actual = RemoveOccurrences(input, substring);
        Assert.Equal(expected, actual);
    }
}

public class Q1957_DeleteCharactersToMakeFancyString
{
    public string MakeFancyString(string s)
    {
        return string.Empty;
    }

    public static IEnumerable<object[]> TestData =>
    [
        ["leeetcode", "leetcode"],
        ["aaabaaaa", "aabaa"],
        ["aab", "aab"],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var actual = MakeFancyString(input);
        Assert.Equal(expected, actual);
    }
}
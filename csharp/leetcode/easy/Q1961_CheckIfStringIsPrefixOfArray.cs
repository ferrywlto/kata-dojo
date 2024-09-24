public class Q1961_CheckIfStringIsPrefixOfArray
{
    public bool IsPrefixString(string s, string[] words)
    {
        return false;
    }

    public static List<object[]> TestData =>
    [
        ["iloveleetcode", new string[] {"i","love","leetcode","apples"}],
        ["iloveleetcode", new string[] {"apples","i","love","leetcode"}],
    ];

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string[] words, bool expected)
    {
        var actual = IsPrefixString(input, words);
        Assert.Equal(expected, actual);
    }
}
public class Q2287_RearrangeCharactersToMakeTargetString
{
    public int RearrangeCharacters(string s, string target)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["ilovecodingonleetcode", "code", 2],
        ["abcba", "abc", 1],
        ["abbaccaddaeea", "aaaaa", 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string target, int expected)
    {
        var actual = RearrangeCharacters(input, target);
        Assert.Equal(expected, actual);
    }
}
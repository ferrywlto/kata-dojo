public class Q3992_RearrangeStringToAvoidCharacterPair
{
    public string RearrangeString(string s, char x, char y)
    {
        return string.Empty;
    }

    public static TheoryData<string, char, char, string> TestData => new()
    {
        { "aabc", 'a', 'c', "cbaa" },
        { "dcab", 'd', 'b', "cabd" },
        { "axe", 'o', 'x', "axe" }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char x, char y, string expected)
    {
        var actual = RearrangeString(input, x, y);
        Assert.Equal(expected, actual);
    }
}

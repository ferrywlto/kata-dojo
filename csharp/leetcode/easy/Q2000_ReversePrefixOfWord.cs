public class Q2000_PreversePrefixOfWord
{
    public string ReversePrefix(string word, char ch)
    {
        return string.Empty;
    }
    public static List<object[]> TestData =>
    [
        ["abcdefd", 'd', "dcbaefd"],
        ["xyxzxe", 'z', "zxyxxe"],
        ["abcd", 'z', "abcd"],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, char target, string expected)
    {
        var actual = ReversePrefix(input, target);
        Assert.Equal(expected, actual);
    }
}
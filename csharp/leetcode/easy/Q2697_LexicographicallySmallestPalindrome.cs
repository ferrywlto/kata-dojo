public class Q2697_LexicographicallySmallestPalindrome
{
    public string MakeSmallestPalindrome(string s)
    {
        return string.Empty;
    }

    public static TheoryData<string, string> TestData => new()
    {
        {"egcfe", "efcfe"},
        {"abcd", "abba"},
        {"seven", "neven"},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string expected)
    {
        var actual = MakeSmallestPalindrome(input);
        Assert.Equal(expected, actual);
    }
}
public class Q680_ValidPalindromeII
{
    public bool ValidPalindrome(string s)
    {
        return false;
    }
    public static TheoryData<string, bool> TestData => new()
    {
        {"aba", true},
        {"abca", true},
        {"abc", false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = ValidPalindrome(input);
        Assert.Equal(expected, actual);
    }
}
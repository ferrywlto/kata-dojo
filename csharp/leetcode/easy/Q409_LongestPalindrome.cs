namespace dojo.leetcode;

public class Q409_LongestPalindrome
{
    public int LongestPalindrome(string s)
    {
        return 1;
    }
}

public class Q409_LongestPalindromeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["abccccdd", 7],
        ["a", 1],
        ["bb", 2],
    ];
}

public class Q409_LongestPalindromeTests
{
    [Theory]
    [ClassData(typeof(Q409_LongestPalindromeTestData))]
    public void OfficialTestCases(string input, int expected)
    {
        var sut = new Q409_LongestPalindrome();
        var actual = sut.LongestPalindrome(input);
        Assert.Equal(expected, actual);
    }
}
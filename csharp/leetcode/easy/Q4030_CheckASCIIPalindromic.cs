public class Q4030_CheckASCIIPalindromic
{
    public bool IsPalindromic(string s)
    {
        return false;
    }

    public static TheoryData<string, bool> TestData => new()
    {
        { "ff", true },
        { "leet", false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsPalindromic(input);
        Assert.Equal(expected, actual);
    }
}

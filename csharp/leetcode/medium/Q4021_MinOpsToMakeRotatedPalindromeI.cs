public class Q4021_MinOpsToMakeRotatedPalindromeI
{
    public int MinOperations(string s) {
        return 0;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "abc", 2 },
        { "yb", 3 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

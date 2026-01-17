public class Q1963_MinNumberOfSwapsToMakeStringBalanced
{
    public int MinSwaps(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"][][", 1},
        {"]]][[[", 2},
        {"[]", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinSwaps(input);
        Assert.Equal(expected, actual);
    }
}

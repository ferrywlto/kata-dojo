public class Q3746_MinStringLengthAfterBalancedRemovals
{
    public int MinLengthAfterRemovals(string s)
    {
        return 0;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"aabbab", 0},
        {"aaaa", 4},
        {"aaabb", 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinLengthAfterRemovals(input);
        Assert.Equal(expected, actual);
    }
}

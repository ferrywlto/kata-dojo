public class Q2744_FindMaxStringPairs
{
    public int MaximumNumberOfStringPairs(string[] words)
    {
        return 0;
    }
    public static TheoryData<string[], int> TestData => new()
    {
        {["cd","ac","dc","ca","zz"], 2},
        {["ab","ba","cc"], 1},
        {["aa","ab"], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = MaximumNumberOfStringPairs(input);
        Assert.Equal(expected, actual);
    }
}
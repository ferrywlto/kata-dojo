public class Q3805_CountCaesarCipherPairs
{
    public long CountPairs(string[] words)
    {
        return 0;
    }
    public static TheoryData<string[], long> TestData => new()
    {
        {["fusion","layout"], 1},
        {["ab","aa","za","aa"], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, long expected)
    {
        var actual = CountPairs(input);
        Assert.Equal(expected, actual);
    }
}

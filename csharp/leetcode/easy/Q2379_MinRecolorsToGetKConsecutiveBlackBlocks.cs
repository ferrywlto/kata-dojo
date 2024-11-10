public class Q2379_MinRecolorsToGetKConsecutiveBlackBlocks
{
    public int MinimumRecolors(string blocks, int k)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        ["WBBWWBBWBW", 7, 3],
        ["WBWBBBW", 2, 0],
    ];
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, int expected)
    {
        var actual = MinimumRecolors(input, k);
        Assert.Equal(expected, actual);
    }
}
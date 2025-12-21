public class Q3781_MaxScoreAfterBinarySwaps
{
    public long MaximumScore(int[] nums, string s)
    {
        return 0;
    }
    public static TheoryData<int[], string, long> TestData => new()
    {
        {[2,1,5,2,3], "01010", 7},
        {[4,7,2,9], "0000", 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, string score, long expected)
    {
        var actual = MaximumScore(input, score);
        Assert.Equal(expected, actual);
    }
}

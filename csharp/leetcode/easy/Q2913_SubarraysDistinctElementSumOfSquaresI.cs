public class Q2913_SubarraysDistinctElementSumOfSquaresI
{
    public int SumCounts(IList<int> nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1], 15},
        {[1,1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SumCounts(input);
        Assert.Equal(expected, actual);
    }
}
public class Q3788_MaxScoreOfSplit
{
    public long MaximumScore(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[10,-1,3,-4,-5], 17},
        {[-7,-5,3], -2},
        {[1,1], 0}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumScore(input);
        Assert.Equal(expected, actual);
    }
}

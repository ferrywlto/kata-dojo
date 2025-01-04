public class Q2824_CountPairsWhoseSumIsLessThanTarget
{
    public int CountPairs(IList<int> nums, int target)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[-1,1,2,3,1], 2, 3},
        {[-6,2,5,-2,-7,-1,3], -2, 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int t, int expected)
    {
        var actual = CountPairs(input, t);
        Assert.Equal(expected, actual);
    }
}

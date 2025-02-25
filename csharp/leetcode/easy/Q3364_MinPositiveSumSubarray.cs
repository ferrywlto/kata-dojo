public class Q3364_MinPositiveSumSubarray
{
    public int MinimumSumSubarray(IList<int> nums, int l, int r)
    {
        return 0;
    }
    public static TheoryData<int[], int, int, int> TestData => new()
    {
        {[3, -2, 1, 4], 2, 3, 1},
        {[-2, 2, -3, 1], 2, 3, -1},
        {[1, 2, 3, 4], 2, 4, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int l, int r, int expected)
    {
        var actual = MinimumSumSubarray(input, l, r);
        Assert.Equal(expected, actual);
    }
}
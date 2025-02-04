public class Q3095_ShortestSubarrayWithOrAtLeastKI
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        return 0;
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[1,2,3], 2, 1},
        {[2,1,8], 10, 3},
        {[1,2], 0, 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = MinimumSubarrayLength(input, k);
        Assert.Equal(expected, actual);
    }
}
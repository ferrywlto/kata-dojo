public class Q3487_MaxUniqueSubarraySumAfterDeletion
{
    public int MaxSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5], 15},
        {[1,1,0,1,1], 1},
        {[1,2,-1,-2,1,0,-1], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxSum(input);
        Assert.Equal(expected, actual);
    }
}
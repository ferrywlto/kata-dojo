public class Q3471_FindLargestAlmostMissingInteger
{
    public int LargestInteger(int[] nums, int k)
    {
        return Math.Max(nums[0], nums[^1]);
    }
    public static TheoryData<int[], int, int> TestData => new()
    {
        {[3,9,2,1,7], 3, 7},
        {[3,9,7,2,1,7], 4, 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = LargestInteger(input, k);
        Assert.Equal(expected, actual);
    }
}
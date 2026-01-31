public class Q3810_MinOpsToReachTargetArray
{
    public int MinOperations(int[] nums, int[] target)
    {
        return 0;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[1,2,3], [2,1,3], 2},
        {[4,1,4], [5,1,4], 1},
        {[7,3,7], [5,5,9], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int[] target, int expected)
    {
        var actual = MinOperations(nums, target);
        Assert.Equal(expected, actual);
    }
}

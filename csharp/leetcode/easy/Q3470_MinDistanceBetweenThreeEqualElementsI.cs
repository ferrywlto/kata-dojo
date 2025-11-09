public class Q3470_MinDistanceBetweenThreeEqualElementsI
{
    public int MinimumDistance(int[] nums)
    {
        return -1;
    }
    public static TheoryData<int[], int> TestData => new()
    {
      {[1,2,1,1,3], 6},
      {[1,1,2,3,2,1,2], 8},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void TestMinimumDistance(int[] nums, int expected)
    {
        var result = MinimumDistance(nums);
        Assert.Equal(expected, result);
    }
}

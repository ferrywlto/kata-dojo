public class Q3701_ComputeAlternatingSum
{
    public int AlternatingSum(int[] nums)
    {
        return 0;
    }
    public static TheoryData<int[], int> TestData => new()
    {
      { [1,3,5,7], -4},
      { [100], 100},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int expected)
    {
        var result = AlternatingSum(nums);
        Assert.Equal(expected, result);
    }
}

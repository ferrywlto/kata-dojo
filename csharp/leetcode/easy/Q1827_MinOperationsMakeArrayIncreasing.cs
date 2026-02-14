class Q1827_MinOperationsMakeArrayIncreasing
{
    // TC: O(n), where n is length of nums
    // SC: O(1), space used is fixed
    public int MinOperations(int[] nums)
    {
        var ops = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                ops += nums[i - 1] - nums[i] + 1;
                nums[i] = nums[i - 1] + 1;
            }
        }
        return ops;
    }
}
class Q1827_MinOperationsMakeArrayIncreasingTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,1,1}, 3],
        [new int[] {1,5,2,4,1}, 14],
        [new int[] {8}, 0],
    ];
}
public class Q1827_MinOperationsMakeArrayIncreasingTests
{
    [Theory]
    [ClassData(typeof(Q1827_MinOperationsMakeArrayIncreasingTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1827_MinOperationsMakeArrayIncreasing();
        var actual = sut.MinOperations(input);
        Assert.Equal(expected, actual);
    }
}

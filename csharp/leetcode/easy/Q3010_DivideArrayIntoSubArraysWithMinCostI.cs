public class Q3010_DivideArrayIntoSubArraysWithMinCostI
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input, fixed at 2 elements
    public int MinimumCost(int[] nums)
    {
        var smallest = new int[2] { int.MaxValue, int.MaxValue };
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] < smallest[0])
            {
                smallest[1] = smallest[0];
                smallest[0] = nums[i];
            }
            else if (nums[i] < smallest[1])
            {
                smallest[1] = nums[i];
            }
        }
        return smallest[0] + smallest[1] + nums[0];
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,12], 6},
        {[5,4,3], 12},
        {[10,3,1,1], 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumCost(input);
        Assert.Equal(expected, actual);
    }
}
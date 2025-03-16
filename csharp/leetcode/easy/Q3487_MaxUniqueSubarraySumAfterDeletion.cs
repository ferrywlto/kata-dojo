public class Q3487_MaxUniqueSubarraySumAfterDeletion
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique positive numbers in nums
    public int MaxSum(int[] nums)
    {
        var set = new HashSet<int>();
        var result = 0;
        var largest = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                if (set.Add(nums[i])) result += nums[i];
            }
            if (nums[i] > largest) largest = nums[i];
        }
        if (largest < 0) return largest;
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5], 15},
        {[1,1,0,1,1], 1},
        {[1,2,-1,-2,1,0,-1], 3},
        {[-100], -100},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxSum(input);
        Assert.Equal(expected, actual);
    }
}
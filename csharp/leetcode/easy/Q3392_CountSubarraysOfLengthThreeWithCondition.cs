public class Q3392_CountSubarraysOfLengthThreeWithCondition
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int CountSubarrays(int[] nums)
    {
        var count = 0;
        for (var i = 2; i < nums.Length; i++)
        {
            if ((nums[i] + nums[i - 2]) * 2 == nums[i - 1]) count++;
        }
        return count;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,1,4,1], 1},
        {[1,1,1], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountSubarrays(input);
        Assert.Equal(expected, actual);
    }
}
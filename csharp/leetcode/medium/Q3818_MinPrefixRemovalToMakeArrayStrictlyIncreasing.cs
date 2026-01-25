public class Q3818_MinPrefixRemovalToMakeArrayStrictlyIncreasing
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MinimumPrefixLength(int[] nums)
    {
        for (var i = nums.Length - 1; i >= 1; i--)
        {
            if (nums[i - 1] >= nums[i]) return i;
        }
        return 0;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[1,-1,2,3,3,4,5], 4},
        {[4,3,-2,-5], 3},
        {[1,2,3,4], 0}
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumPrefixLength(input);
        Assert.Equal(expected, actual);
    }
}

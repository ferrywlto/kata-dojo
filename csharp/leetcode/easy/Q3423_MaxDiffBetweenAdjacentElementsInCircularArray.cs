public class Q3423_MaxDiffBetweenAdjacentElementsInCircularArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaxAdjacentDistance(int[] nums)
    {
        var maxDiff = Math.Abs(nums[0] - nums[^1]);
        for (var i = 1; i < nums.Length; i++)
        {
            var diff = Math.Abs(nums[i] - nums[i - 1]);
            if (diff > maxDiff) maxDiff = diff;
        }
        return maxDiff;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,4], 3},
        {[-5,-10,-5], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxAdjacentDistance(input);
        Assert.Equal(expected, actual);
    }
}
public class Q2016_MaxDiffBetweenIncreasingElements
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input 
    public int MaximumDifference(int[] nums)
    {
        var maxDiff = -1;
        var min = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > min)
                maxDiff = Math.Max(maxDiff, nums[i] - min);
            else
                min = nums[i];
        }
        return maxDiff;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {7,1,5,4}, 4],
        [new int[] {9,4,3,2}, -1],
        [new int[] {1,5,2,10}, 9],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumDifference(input);
        Assert.Equal(expected, actual);
    }
}
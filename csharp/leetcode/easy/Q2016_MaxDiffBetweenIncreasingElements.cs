public class Q2016_MaxDiffBetweenIncreasingElements
{
    // TC: O(n^2), n scale with length of nums
    // SC: O(1), space used does not scale with input 
    public int MaximumDifference(int[] nums)
    {
        var maxDiff = -1;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[j] > nums[i])
                {
                    var diff = nums[j] - nums[i];
                    if (diff > maxDiff) maxDiff = diff;
                }
            }
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
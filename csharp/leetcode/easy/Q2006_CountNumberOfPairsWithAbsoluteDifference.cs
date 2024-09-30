public class Q2006_CountNumberOfPairsWithAbsoluteDifference
{
    // TC: O(n), where n sacle with length of nums
    // SC: O(1), space used does not scale with input
    public int CountKDifference(int[] nums, int k)
    {
        if (nums.Length == 1) return 0;
        var result = 0;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) == k) result++;
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,2,1}, 1, 4],
        [new int[] {1,3}, 3, 0],
        [new int[] {3,2,1,5,4}, 2, 3],
        [new int[] {1}, 1, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = CountKDifference(input, k);
        Assert.Equal(expected, actual);
    }
}
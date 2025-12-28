public class Q3788_MaxScoreOfSplit
{
    // TC: O(n), n scale with nums.Length
    // SC: O(n)
    public long MaximumScore(int[] nums)
    {
        var prefixSum = new long[nums.Length];
        var suffixMin = new int[nums.Length];

        prefixSum[0] = nums[0];
        for (var i = 1; i < nums.Length; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + nums[i];
        }

        var min = int.MaxValue;
        for (var j = nums.Length - 1; j >= 1; j--)
        {
            min = Math.Min(min, nums[j]);
            suffixMin[j - 1] = min;
        }

        var maxScore = long.MinValue;
        for (var k = 0; k < nums.Length - 1; k++)
        {
            maxScore = Math.Max(maxScore, prefixSum[k] - suffixMin[k]);
        }
        return maxScore;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[10,-1,3,-4,-5], 17},
        {[-7,-5,3], -2},
        {[1,1], 0}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaximumScore(input);
        Assert.Equal(expected, actual);
    }
}

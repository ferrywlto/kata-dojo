public class Q2574_LeftAndRightSumDifferences
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), same as time for holding result
    public int[] LeftRightDifference(int[] nums)
    {
        var len = nums.Length;
        var result = new int[len];
        var left = 0;
        var right = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            left += nums[i - 1];
            right += nums[^i];

            result[i] += left;
            result[^(i + 1)] -= right;
        }
        for (var j = 0; j < result.Length; j++)
        {
            result[j] = Math.Abs(result[j]);
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {10,4,8,3}, new int[] {15,1,11,22}],
        [new int[] {1}, new int[] {0}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = LeftRightDifference(input);
        Assert.Equal(expected, actual);
    }
}

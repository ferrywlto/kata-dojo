public class Q3432_CountPartitionsWithEvenSumDifference
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int CountPartitions(int[] nums)
    {
        var result = 0;
        var total = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            total += nums[i];
        }
        var right = total;
        var left = 0;
        for (var j = 0; j < nums.Length - 1; j++)
        {
            left += nums[j];
            right -= nums[j];
            var diff = left - right;
            if (diff % 2 == 0) result++;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[10,10,3,7,6], 4},
        {[1,2,2], 0},
        {[2,4,6,8], 3},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountPartitions(input);
        Assert.Equal(expected, actual);
    }
}
public class Q3427_SumOfVariableLengthSubarrays
{
    // TC: O(n), n scale with length of nums
    // SC: O(1), space used does not scale with input
    public int SubarraySum(int[] nums)
    {
        // sum from 0..i
        var sum = new int[nums.Length];
        var result = 0;
        var accumulated = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var start = Math.Max(0, i - nums[i]);
            accumulated += nums[i];
            sum[i] = accumulated;

            result += sum[i];
            if (start != 0)
            {
                result -= sum[start - 1];
            }
        }
        return result;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[2,3,1], 11},
        {[3,1,1,2], 13},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = SubarraySum(input);
        Assert.Equal(expected, actual);
    }
}
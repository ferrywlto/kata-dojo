public class Q3969_ValidSubarraysWithMatchingSumDigitsI
{
    // TC: O(n^2)
    // SC: O(1)
    // Since the interim result is not used after calculation, using rolling sum is faster than triangular prefix sum.
    public int CountValidSubarrays(int[] nums, int x)
    {
        var result = 0;
        var len = nums.Length;
        for (var start = 0; start < len; start++)
        {
            var sum = 0L;
            for (var end = start; end < len; end++)
            {
                sum += nums[end];
                if (IsValidSum(sum, x)) result++;
            }
        }

        return result;
    }

    private bool IsValidSum(long input, int x)
    {
        var lastDigit = input % 10;
        if (lastDigit != x) return false;

        while (input >= 10) input /= 10;
        return x == input;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        { [1, 100, 1], 1, 4 },
        { [1], 2, 0 },
        { [1000000000,1,1000000000,1,1000000000,1,1000000000], 3, 2},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int k, int expected)
    {
        var actual = CountValidSubarrays(input, k);
        Assert.Equal(expected, actual);
    }
}

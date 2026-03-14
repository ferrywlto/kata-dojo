public class Q3867_SumOfGCDOfFormedPairs
{
    // TC: O(n), n scale with length of nums
    // SC: O(n)
    public long GcdSum(int[] nums)
    {
        var max = nums[0];
        var prefixGcd = new long[nums.Length];
        prefixGcd[0] = nums[0];

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > max) max = nums[i];
            prefixGcd[i] = GCD(max, nums[i]);
        }

        Array.Sort(prefixGcd);

        var cache = new Dictionary<string, long>();

        var result = 0L;
        var len = prefixGcd.Length / 2;
        for (var i = 0; i < len; i++)
        {
            var lastIdx = prefixGcd.Length - 1 - i;
            if (cache.TryGetValue($"{lastIdx},{i}", out var value))
            {
                result += value;
            }
            else
            {
                var gcd = GCD(prefixGcd[i], prefixGcd[lastIdx]);
                cache.Add($"{lastIdx},{i}", gcd);
                result += gcd;
            }
        }

        return result;
    }

    private long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    public static TheoryData<int[], long> TestData => new() { { [2, 6, 4], 2 }, { [3, 6, 2, 8], 5 }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, long expected)
    {
        var actual = GcdSum(input);
        Assert.Equal(expected, actual);
    }
}

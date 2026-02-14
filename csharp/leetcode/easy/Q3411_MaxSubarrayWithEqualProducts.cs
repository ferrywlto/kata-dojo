public class Q3411_MaxSubarrayWithEqualProducts
{
    // TC: O(n^2)
    // SC: O(1), space used does not scale with input
    public int MaxLength(int[] nums)
    {
        var maxLen = 2;
        for (var i = 0; i < nums.Length - 1; i++)
        {
            var gcd = GCD(nums[i], nums[i + 1]);
            var product = nums[i] * nums[i + 1];
            var lcm = product / gcd;
            var len = 2;
            for (var j = i + 2; j < nums.Length; j++)
            {
                gcd = GCD(gcd, nums[j]);
                product *= nums[j];
                lcm = lcm * nums[j] / GCD(lcm, nums[j]);
                len++;
                if (product == gcd * lcm && len > maxLen) maxLen = len;
            }
        }
        return maxLen;
    }

    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2], 2},
        {[1,2,1,2,1,1,1], 5},
        {[2,3,4,5,6], 3},
        {[1,2,3,1,4,5,1], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxLength(input);
        Assert.Equal(expected, actual);
    }
}

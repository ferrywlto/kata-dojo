public class Q4010_MaxPairStrengthUsingGCD
{
    // TC: O(n^2)
    // SC: O(1)
    public long MaxPairStrength(int[] nums)
    {
        long max = 0;
        for(var i=0; i<nums.Length-1; i++)
        {
            for(var j=i+1; j<nums.Length; j++)
            {
                var gcd = GCD(nums[i], nums[j]);
                long strength = (long)nums[i] * nums[j] / (gcd * gcd);
                if(strength > max) max = strength;
            }
        }
        return max;
    }

    public static TheoryData<int[], long> TestData => new ()
    {
        {[2,3,5], 15},
        {[4,6,8], 12},
        {[3,3], 1},
        {[7,18,12], 126},
    };

    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, long expected)
    {
        var actual = MaxPairStrength(input);
        Assert.Equal(expected, actual);
    }
}

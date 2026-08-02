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

    // Faster version by AI
    /*
    public long MaxPairStrength(int[] nums)
    {
        Array.Sort(nums);

        long max = 0;

        for (var i = nums.Length - 1; i > 0; i--)
        {
            // nums[i - 1] is the largest remaining partner.
            if ((long)nums[i] * nums[i - 1] <= max)
                break;

            for (var j = i - 1; j >= 0; j--)
            {
                // Products only get smaller as j decreases.
                if ((long)nums[i] * nums[j] <= max)
                    break;

                var gcd = GCD(nums[i], nums[j]);
                var strength = (long)(nums[i] / gcd) * (nums[j] / gcd);

                max = Math.Max(max, strength);
            }
        }

        return max;
    }
    */
    public static TheoryData<int[], long> TestData => new ()
    {
        {[2,3,5], 15},
        {[4,6,8], 12},
        {[3,3], 1},
        {[7,18,12], 126},
    };

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            var remainder = a % b;
            a = b;
            b = remainder;
        }

        return a;
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, long expected)
    {
        var actual = MaxPairStrength(input);
        Assert.Equal(expected, actual);
    }
}

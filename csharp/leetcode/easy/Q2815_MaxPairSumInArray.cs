public class Q2815_MaxPairSumInArray
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with unique max digits in nums
    public int MaxSum(int[] nums)
    {
        var largestSum = -1;
        var buckets = new Dictionary<int, int[]>();
        for (var i = 0; i < nums.Length; i++)
        {
            var current = nums[i];
            var maxDigit = LargestDigit(current);
            if (buckets.TryGetValue(maxDigit, out var val))
            {
                if (current > val[0])
                {
                    val[1] = val[0];
                    val[0] = current;
                }
                else if (current > val[1])
                {
                    val[1] = current;
                }
                var sum = val[0] + val[1];
                if (sum > largestSum) largestSum = sum;
            }
            else
            {
                buckets.Add(maxDigit, [nums[i], 0]);
            }
        }
        return largestSum;
    }
    public int LargestDigit(int input)
    {
        var result = 0;
        while (input > 0)
        {
            var digit = input % 10;
            if (digit == 9) return 9;
            else result = Math.Max(result, digit);

            input /= 10;
        }
        return result;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[112,131,411], -1},
        {[2536,1613,3366,162], 5902},
        {[51,71,17,24,42], 88},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxSum(input);
        Assert.Equal(expected, actual);
    }
}

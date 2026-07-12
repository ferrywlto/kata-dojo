public class Q3982_SumOfIntegersWithMaxDigitRange
{
    public int MaxDigitRange(int[] nums)
    {
        Span<int> buckets = stackalloc int[10];
        // range must be 0 - 9
        var maxDiff = int.MinValue;

        for (var i = 0; i < nums.Length; i++)
        {
            var digitMax = int.MinValue;
            var digitMin = int.MaxValue;

            var num = nums[i];
            while (num > 0)
            {
                var digit = num % 10;
                if (digit > digitMax) digitMax = digit;
                if (digit < digitMin) digitMin = digit;
                num /= 10;
            }

            var diff = digitMax - digitMin;
            buckets[diff] += nums[i];

            if (diff > maxDiff) maxDiff = diff;
        }

        return buckets[maxDiff];
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5724,111,350], 6074},
        {[90,900], 990},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MaxDigitRange(input);
        Assert.Equal(expected, actual);
    }
}

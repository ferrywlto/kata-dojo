public class Q3754_ConcatenateNonZeroDigitsAndMultiplyBySumI
{
    // TC: O(d) where d is the number of digits in n
    // SC: O(1)
    public long SumAndMultiply(int n)
    {
        var x = n;
        var nonZeroConcat = 0L;
        var nonZeroSum = 0;
        var rad = 1;
        while (x > 0)
        {
            var digit = x % 10;
            if (digit != 0)
            {
                var actual = digit * rad;
                nonZeroConcat += actual;
                nonZeroSum += digit;
                rad *= 10;
            }
            x /= 10;
        }
        return nonZeroConcat * nonZeroSum;
    }
    public static TheoryData<int, long> TestData => new()
    {
        { 10203004, 12340 },
        { 1000, 1 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, long expected)
    {
        var result = SumAndMultiply(n);
        Assert.Equal(expected, result);
    }
}

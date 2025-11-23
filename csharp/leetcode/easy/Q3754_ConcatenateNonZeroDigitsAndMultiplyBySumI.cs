public class Q3754_ConcatenateNonZeroDigitsAndMultiplyBySumI
{
    public long SumAndMultiply(int n)
    {
        return 0;
    }
    public static TheoryData<int, long> TestData => new()
    {
        { 10203004, 12340 }, // Non-zero digits: 1,2,3,4,5 -> "12345" = 12345 * (1+2+3+4+5)=15 -> 12345*15=185175
        { 1000, 1 },    // Non-zero digits: 1 -> "1" = 1 * (1)=1 -> 1*1=1
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, long expected)
    {
        var result = SumAndMultiply(n);
        Assert.Equal(expected, result);
    }
}

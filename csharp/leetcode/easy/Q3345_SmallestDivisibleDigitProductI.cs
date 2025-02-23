public class Q3345_SmallestDivisibleDigitProductI
{
    public int SmallestNumber(int n, int t)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {10, 5, 10},
        {15, 3, 16},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int t, int expected)
    {
        var actual = SmallestNumber(input, t);
        Assert.Equal(expected, actual);
    }
}
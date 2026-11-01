public class Q4092_BinaryDigitScore
{
    public int CalculateScore(int a, int b)
    {
        return 0;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        { 14, 6, 6 },
        { 5, 15, 2 },
        { 10, 12, 4 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int a, int b, int expected)
    {
        var actual = CalculateScore(a, b);
        Assert.Equal(expected, actual);
    }
}

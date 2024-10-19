public class Q2180_CountIntegersWithEvenDigitSum
{
    public int CountEven(int num)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [4, 2],
        [30, 14],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountEven(input);
        Assert.Equal(expected, actual);
    }
}
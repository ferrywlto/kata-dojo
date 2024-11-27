public class Q2520_CountDigitsThatDivideNumber
{
    public int CountDigits(int num)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [7, 1],
        [121, 2],
        [1248, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountDigits(input);
        Assert.Equal(expected, actual);
    }
}
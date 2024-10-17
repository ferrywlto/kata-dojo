public class Q2160_MinSumOfFourDigitNumberAfterSplittingDigits
{
    public int MinimumSum(int num)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [2932, 52],
        [4009, 13],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = MinimumSum(input);
        Assert.Equal(expected, actual);
    }
}
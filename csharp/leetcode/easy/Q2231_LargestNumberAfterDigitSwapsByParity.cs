public class Q2231_LargestNumberAfterDigitSwapsByParity
{
    public int LargestInteger(int num)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [1234, 3412],
        [65875, 87655],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = LargestInteger(input);
        Assert.Equal(expected, actual);
    }
}
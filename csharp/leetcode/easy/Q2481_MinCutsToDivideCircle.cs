public class Q2481_MinCutsToDivideCircle
{
    public int NumberOfCuts(int n)
    {
        if (n == 1) return 0;
        if (n % 2 == 0) return n / 2;
        else return n;
    }
    public static List<object[]> TestData =>
    [
        [4, 2],
        [3, 3],
        [1, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = NumberOfCuts(input);
        Assert.Equal(expected, actual);
    }
}

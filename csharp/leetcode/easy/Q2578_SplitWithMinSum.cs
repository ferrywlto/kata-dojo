public class Q2578_SplitWithMinSum
{
    public int SplitNum(int num)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [4325, 59],
        [687, 75],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = SplitNum(input);
        Assert.Equal(expected, actual);
    }
}
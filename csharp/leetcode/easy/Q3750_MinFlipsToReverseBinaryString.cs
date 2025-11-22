public class Q3750_MinFlipsToReverseBinaryString
{
    public int MinimumFlips(int n)
    {
        return 0;
    }
    public static TheoryData<int, int> TestData => new()
    {
        { 7, 0 },
        { 10, 4 },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int expected)
    {
        var result = MinimumFlips(n);
        Assert.Equal(expected, result);
    }
}

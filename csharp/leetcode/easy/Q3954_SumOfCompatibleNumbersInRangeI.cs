public class Q3954_SumOfCompatibleNumbersInRangeI
{
    public int SumOfGoodIntegers(int n, int k)
    {
        return 0;
    }

    public static TheoryData<int, int, int> TestData => new()
    {
        { 2, 3, 10 },
        { 5, 1, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, int expected)
    {
        var actual = SumOfGoodIntegers(n, k);
        Assert.Equal(expected, actual);
    }
}

public class Q3560_MinLogTransportationCost
{
    public long MinCuttingCost(int n, int m, int k)
    {
        return 0;
    }
    public static TheoryData<int, int, int, int> TestData => new()
    {
        {6,5,5,5},
        {4,4,6,0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int m, int k, int expected)
    {
        var actual = MinCuttingCost(n, m, k);
        Assert.Equal(expected, actual);
    }
}
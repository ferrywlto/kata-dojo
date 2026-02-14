public class Q3560_MinLogTransportationCost
{
    // TC: O(1)
    // SC: O(1)
    public long MinCuttingCost(int n, int m, int k)
    {
        if (n <= k && m <= k) return 0;
        return (long)k * (Math.Max(n, m) - k);
    }
    public static TheoryData<int, int, int, long> TestData => new()
    {
        {6,5,5,5},
        {4,4,6,0},
        {49898,109372,62703,2926286307},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int m, int k, long expected)
    {
        var actual = MinCuttingCost(n, m, k);
        Assert.Equal(expected, actual);
    }
}

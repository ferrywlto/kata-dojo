public class Q2928_DistributeCandiesAmongChildrenI
{
    public int DistributeCandies(int n, int limit)
    {
        return 0;
    }
    public static TheoryData<int, int, int> TestData => new()
    {
        {5, 2 ,3},
        {3, 3 ,10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int limit, int expected)
    {
        var actual = DistributeCandies(input, limit);
        Assert.Equal(expected, actual);
    }
}
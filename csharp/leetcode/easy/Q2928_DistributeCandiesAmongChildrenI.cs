public class Q2928_DistributeCandiesAmongChildrenI
{
    // TC: O(n^2), due to triplet calculation
    // SC: O(1), space used does not scale with input
    public int DistributeCandies(int n, int limit)
    {
        var result = 0;
        for (var i = 0; i <= limit; i++)
        {
            for (var j = 0; j <= limit; j++)
            {
                var possibleK = n - i - j;
                if (i + j <= n && possibleK <= limit) result++;
            }
        }
        return result;
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

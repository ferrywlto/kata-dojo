public class Q3882_MinXorPathInGrid
{
    public int MinCost(int[][] grid)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[1,2],[3,4]], 6},
        {[[6,7],[5,8]], 7},
        {[[2,7,5]], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MinCost(input);
        Assert.Equal(expected, actual);
    }
}

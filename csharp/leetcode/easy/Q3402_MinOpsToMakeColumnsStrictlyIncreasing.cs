public class Q3402_MinOpsToMakeColumnsStrictlyIncreasing
{
    public int MinimumOperations(int[][] grid)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[3,2],[1,3],[3,4],[0,1]], 15},
        {[[3,2,1],[2,1,0],[1,2,3]], 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}
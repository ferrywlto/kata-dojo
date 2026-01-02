public class Q3195_FindMinAreaCoverAllOnes
{
    public int MinimumArea(int[][] grid)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[0,1,0],[1,0,1]], 6},
        {[[1,0],[0,0]], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MinimumArea(input);
        Assert.Equal(expected, actual);
    }
}

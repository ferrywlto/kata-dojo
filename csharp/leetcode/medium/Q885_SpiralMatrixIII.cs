public class Q885_SpiralMatrixIII
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        return [];
    }
    public static TheoryData<int, int, int, int, int[][]> TestData => new()
    {
        {1,4,0,0, [[0,0],[0,1],[0,2],[0,3]]},
        {5,6,1,4, [[1,4],[1,5],[2,5],[2,4],[2,3],[1,3],[0,3],[0,4],[0,5],[3,5],[3,4],[3,3],[3,2],[2,2],[1,2],[0,2],[4,5],[4,4],[4,3],[4,2],[4,1],[3,1],[2,1],[1,1],[0,1],[4,0],[3,0],[2,0],[1,0],[0,0]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int row, int col, int rStart, int cStart, int[][] expected)
    {
        var actual = SpiralMatrixIII(row, col, rStart, cStart);
        Assert.Equal(expected, actual);
    }
}
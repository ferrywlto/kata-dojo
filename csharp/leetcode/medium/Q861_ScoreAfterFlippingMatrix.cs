public class Q861_ScoreAfterFlippingMatrix
{
    public int MatrixScore(int[][] grid)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[0,0,1,1],[1,0,1,0],[1,1,0,0]], 39},
        {[[0]], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MatrixScore(input);
        Assert.Equal(expected, actual);
    }
}

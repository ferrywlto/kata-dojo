public class Q3195_FindMinAreaCoverAllOnes
{
    // TC: O(n * m), where n scale with row of grid and m scale with columns of grid
    // SC: O(1), space used does not scale with input
    public int MinimumArea(int[][] grid)
    {
        var minRow = grid.Length;
        var maxRow = 0;
        var minCol = grid[0].Length;
        var maxCol = 0;

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == 1)
                {
                    if (row < minRow) minRow = row;
                    if (row > maxRow) maxRow = row;
                    if (col < minCol) minCol = col;
                    if (col > maxCol) maxCol = col;
                }
            }
        }
        return (maxCol - minCol + 1) * (maxRow - minRow + 1);
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[0,1,0],[1,0,1]], 6},
        {[[1,0],[0,0]], 1},
        {[[0,0],[1,0]], 1},
        {[[0,0,1]], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MinimumArea(input);
        Assert.Equal(expected, actual);
    }
}

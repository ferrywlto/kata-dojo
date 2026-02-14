public class Q3142_CheckIfGridSatisfiesConditions
{
    // TC: O(n), n scale with rows x columns in grid
    // SC: O(1), space used does not scale with input
    public bool SatisfiesConditions(int[][] grid)
    {
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (row != grid.Length - 1 &&
                    grid[row][col] != grid[row + 1][col]) return false;

                if (col != grid[row].Length - 1 &&
                    grid[row][col] == grid[row][col + 1]) return false;
            }
        }
        return true;
    }
    public static TheoryData<int[][], bool> TestData => new()
    {
        {[[1,0,2],[1,0,2]], true},
        {[[1,1,1],[0,0,0]], false},
        {[[1],[2],[3]], false},
        {[[1],[1],[1]], true},
        {[[1,2,3]], true},
        {[[1,1,3]], false},

    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, bool expected)
    {
        var actual = SatisfiesConditions(input);
        Assert.Equal(expected, actual);
    }
}

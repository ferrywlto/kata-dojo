public class Q3402_MinOpsToMakeColumnsStrictlyIncreasing
{
    // TC: O(n^2), it have to iterate all rows except the first
    // SC: O(1), space used does not scale with input
    public int MinimumOperations(int[][] grid)
    {
        var result = 0;
        for (var row = 1; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] <= grid[row - 1][col])
                {
                    var diff = grid[row - 1][col] - grid[row][col] + 1;
                    grid[row][col] += diff;
                    result += diff;
                }
            }
        }
        return result;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[3,2],[1,3],[3,4],[0,1]], 15},
        {[[3,2,1],[2,1,0],[1,2,3]], 12},
        {[[0,0],[0,0]], 2},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MinimumOperations(input);
        Assert.Equal(expected, actual);
    }
}

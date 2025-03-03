public class Q3417_ZigzagGridTraversalWithSkip
{
    // TC: O(n * m), as each element in grid has to be interated
    // SC: O(n * m), if counting the result, O(1) otherwise 
    public IList<int> ZigzagTraversal(int[][] grid)
    {
        var result = new List<int>();
        for (var i = 0; i < grid.Length; i++)
        {
            var rowLen = grid[i].Length;
            if (i % 2 == 0)
            {
                for (var j = 0; j < rowLen; j += 2)
                {
                    if (j <= rowLen - 1) result.Add(grid[i][j]);
                }
            }
            else
            {
                var start = rowLen % 2 == 0 ? rowLen - 1 : rowLen - 2;
                for (var j = start; j >= 0; j -= 2)
                {
                    if (j >= 0) result.Add(grid[i][j]);
                }
            }
        }
        return result;
    }
    public static TheoryData<int[][], List<int>> TestData => new()
    {
        {[[1,2],[3,4]], [1,4]},
        {[[2,1],[2,1],[2,1]], [2,1,2]},
        {[[1,2,3],[4,5,6],[7,8,9]], [1,3,5,7,9]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, List<int> expected)
    {
        var actual = ZigzagTraversal(input);
        Assert.Equal(expected, actual);
    }
}
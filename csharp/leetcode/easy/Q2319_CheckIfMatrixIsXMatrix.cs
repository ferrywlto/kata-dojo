public class Q2319_CheckIfMatrixIsXMatrix
{
    // TC: O(n^2), n scale with length of grid as n x n matrix
    // SC: O(1), space used does not scale with input
    public bool CheckXMatrix(int[][] grid)
    {
        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                // inverse diagonal
                var inverseCell = grid[i].Length - (i + 1);
                if (i == j || j == inverseCell)
                {
                    if (grid[i][j] == 0) return false;
                }
                else if (grid[i][j] != 0) return false;
            }
        }
        return true;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][]
            {
                [2,0,0,1],
                [0,3,1,0],
                [0,5,2,0],
                [4,0,0,2],
            }, true
        ],
        [
            new int[][]
            {
                [5,7,0],
                [0,3,1],
                [0,5,0],
            }, false
        ],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, bool expected)
    {
        var actual = CheckXMatrix(input);
        Assert.Equal(expected, actual);
    }
}

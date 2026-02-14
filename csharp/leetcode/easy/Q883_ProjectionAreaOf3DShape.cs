class Q883_ProjectionAreaOf3DShape
{
    /*
        [1,2]
        [3,4]
        1. top -> sum of non-zero
        2. x -> keep largest across rows
        3. y -> keep largest across cols
    */
    // TC: O(n), n is the total cells in grid
    // SC: O(n), n is the length the edge of the grid * 2
    public int ProjectionArea(int[][] grid)
    {
        var nonZero = 0;
        var largestAcrossRow = new int[grid.Length];
        var largestAcrossCol = new int[grid.Length];

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] > 0) nonZero++;
                if (grid[i][j] > largestAcrossRow[i]) largestAcrossRow[i] = grid[i][j];
                if (grid[i][j] > largestAcrossCol[j]) largestAcrossCol[j] = grid[i][j];
            }

        }
        return nonZero + largestAcrossRow.Sum() + largestAcrossCol.Sum();
    }
}

class Q883_ProjectionAreaOf3DShapeTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,2],[3,4]}, 17],
        [new int[][] {[2]}, 5],
        [new int[][] {[1,0],[0,2]}, 8],
    ];
}

public class Q883_ProjectionAreaOf3DShapeTests
{
    [Theory]
    [ClassData(typeof(Q883_ProjectionAreaOf3DShapeTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q883_ProjectionAreaOf3DShape();
        var actual = sut.ProjectionArea(input);
        Assert.Equal(expected, actual);
    }
}

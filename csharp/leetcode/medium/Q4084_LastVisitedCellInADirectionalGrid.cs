public class Q4084_LastVisitedCellInADirectionalGrid
{
    // TC: O(m * n), worst case all cells are not seen
    // SC: O(1)
    public int[] LastVisitedCell(char[][] grid)
    {
        var m = grid.Length - 1;
        var n = grid[0].Length - 1;
        var prevRowIdx = 0;
        var prevColIdx = 0;
        var currRowIdx = 0;
        var currColIdx = 0;

        while (true)
        {
            var direction = grid[currRowIdx][currColIdx];
            grid[currRowIdx][currColIdx] = 'X';
            prevRowIdx = currRowIdx;
            prevColIdx = currColIdx;

            if (direction == 'R' && currColIdx++ == n) break;

            if (direction == 'L' && currColIdx-- == 0) break;

            if (direction == 'U' && currRowIdx-- == 0) break;

            if (direction == 'D' && currRowIdx++ == m) break;

            if (grid[currRowIdx][currColIdx] == 'X') break;
        }

        return [prevRowIdx, prevColIdx];
    }

    public static TheoryData<char[][], int[]> TestData => new()
    {
        { [['R', 'D'], ['U', 'L']], [1, 0] },
        { [['R', 'R', 'R']], [0, 2] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(char[][] input, int[] expected)
    {
        var actual = LastVisitedCell(input);
        Assert.Equal(expected, actual);
    }
}

public class Q4084_LastVisitedCellInADirectionalGrid
{
    public int[] LastVisitedCell(char[][] grid)
    {
        var lastVisit = new int[2];
        var rowIdx = 0;
        var colIdx = 0;

        var seen = new HashSet<(int, int)>();

        while (true)
        {
            if (!seen.Add((rowIdx, colIdx))) return lastVisit;

            var direction = grid[rowIdx][colIdx];
            lastVisit[0] = rowIdx;
            lastVisit[1] = colIdx;

            if (direction == 'R')
            {
                if (colIdx == grid[rowIdx].Length - 1)
                {
                    return lastVisit;
                }

                colIdx++;
            }
            else if (direction == 'L')
            {
                if (colIdx == 0)
                {
                    return lastVisit;
                }

                colIdx--;
            }
            else if (direction == 'U')
            {
                if (rowIdx == 0)
                {
                    return lastVisit;
                }

                rowIdx--;
            }
            else if (direction == 'D')
            {
                if (rowIdx == grid.Length - 1)
                {
                    return lastVisit;
                }

                rowIdx++;
            }
        }
    }

    public static TheoryData<char[][], int[]> TestData => new()
    {
        { [['R', 'D'], ['U', 'L']], [1, 0] },
        { [['R', 'R', 'R']], [0,2]},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(char[][] input, int[] expected)
    {
        var actual = LastVisitedCell(input);
        Assert.Equal(expected, actual);
    }
}

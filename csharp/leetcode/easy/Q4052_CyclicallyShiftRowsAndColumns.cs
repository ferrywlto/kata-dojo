public class Q4052_CyclicallyShiftRowsAndColumns
{
    // TC: O(n^2)
    // SC: O(n), because the grid is always a square, the temp space used is either row length or col length
    public int[][] CyclicShift(int n, int[][] grid, int[] rowShift, int[] colShift)
    {
        for (var r = 0; r < rowShift.Length; r++)
        {
            RowShiftLeft(grid, r, rowShift[r]);
        }

        for (var c = 0; c < colShift.Length; c++)
        {
            ColShiftUp(grid, c, colShift[c]);
        }

        return grid;
    }

    private void RowShiftLeft(int[][] grid, int rowIdx, int n)
    {
        var row = grid[rowIdx];
        var result = new int[row.Length];
        for (var i = 0; i < row.Length; i++)
        {
            var newColIdx = (i - n + row.Length) % row.Length;
            result[newColIdx] = row[i];
        }

        grid[rowIdx] = result;
    }

    private void ColShiftUp(int[][] grid, int colIdx, int n)
    {
        var rowCount = grid.Length;
        // clone the column
        var cloned = new int[rowCount];
        for (var rowIdx = 0; rowIdx < rowCount; rowIdx++)
        {
            cloned[rowIdx] = grid[rowIdx][colIdx];
        }

        // replace by shifted idx
        for (var rowIdx = 0; rowIdx < rowCount; rowIdx++)
        {
            var newRowIdx = (rowIdx - n + rowCount) % rowCount;

            grid[newRowIdx][colIdx] = cloned[rowIdx];
        }
    }

    [Fact]
    public void TestColShiftUp()
    {
        int[][] arr = [[1], [2], [3], [4], [5]];

        ColShiftUp(arr, 0, 3);

        Assert.Equal([[4], [5], [1], [2], [3]], arr);
    }

    [Fact]
    public void TestRowShiftLeft()
    {
        int[][] arr = [[1, 2, 3, 4, 5]];

        RowShiftLeft(arr, 0, 3);

        Assert.Equal([4, 5, 1, 2, 3], arr[0]);
    }

    public static TheoryData<int, int[][], int[], int[], int[][]> TestData => new()
    {
        {
            2, [[1, 2], [3, 4]], [1, 0], [0, 1], [[2, 4], [3, 1]]
        },
        {
            3, [[1, 2, 3], [4, 5, 6], [7, 8, 9]], [1, 2, 0], [2, 2, 1], [[7, 8, 5], [2, 3, 9], [6, 4, 1]]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] input, int[] rowShift, int[] colShift, int[][] expected)
    {
        var actual = CyclicShift(n, input, rowShift, colShift);
        Assert.Equal(expected, actual);
    }
}

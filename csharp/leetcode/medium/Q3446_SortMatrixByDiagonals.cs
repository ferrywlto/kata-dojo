public class Q3446_SortMatrixByDiagonals
{
    // TC: O(row + col) of grid
    // SC: O(1)
    public int[][] SortMatrix(int[][] grid)
    {
        var size = grid.Length;
        for (var row = 0; row < size; row++)
            ReadDiagonal(grid, row, 0, 'd');

        for (var col = 1; col < size; col++)
            ReadDiagonal(grid, 0, col, 'a');

        return grid;
    }
    // TC: O(m), m scale with input.length
    // SC: O(m)
    private void ReadDiagonal(int[][] input, int rowStart, int colStart, char sortOrder)
    {
        var size = input.Length;
        var row = rowStart;
        var col = colStart;
        var sorted = new List<int>();
        var sortIdx = 0;

        while (row < size && col < size)
            sorted.Add(input[row++][col++]);

        if (sortOrder == 'a')
            sorted.Sort();
        else if (sortOrder == 'd')
            sorted.Sort((a, b) => b - a);

        row = rowStart;
        col = colStart;

        while (row < size && col < size)
            input[row++][col++] = sorted[sortIdx++];
    }
    public static TheoryData<int[][], int[][]> TestData => new()
    {
        {
            [[1,7,3],[9,8,2],[4,5,6]],
            [[8,2,3],[9,6,7],[4,5,1]]
        },
        {
            [[0,1],[1,2]],[[2,1],[1,0]]
        },
        {
            [[1]], [[1]]
        },
        {
            [[-3,0],[-5,4]],
            [[4,0],[-5,-3]]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int[][] expected)
    {
        var actual = SortMatrix(input);
        Assert.Equal(expected, actual);
    }
}

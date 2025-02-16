public class NeighborSum
{
    private readonly Dictionary<int, int[]> _coords = [];
    private readonly int[][] _grid;

    // TC: O(n^2), as it have to iterate all items to get the position
    // SC: O(n^2), same as time
    public NeighborSum(int[][] grid)
    {
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                _coords.Add(grid[row][col], [row, col]);
            }
        }
        _grid = grid;
    }
    // TC: O(1)
    // SC: O(1)
    public int AdjacentSum(int value)
    {
        var coord = _coords[value];
        var (row, col) = (coord[0], coord[1]);
        var sum = 0;

        if (row > 0) sum += _grid[row - 1][col];
        if (row < _grid.Length - 1) sum += _grid[row + 1][col];
        if (col > 0) sum += _grid[row][col - 1];
        if (col < _grid[row].Length - 1) sum += _grid[row][col + 1];

        return sum;
    }
    // TC: O(1)
    // SC: O(1)
    public int DiagonalSum(int value)
    {
        var coord = _coords[value];
        var (row, col) = (coord[0], coord[1]);
        var sum = 0;

        if (row > 0 && col > 0) sum += _grid[row - 1][col - 1];
        if (row > 0 && col < _grid[row].Length - 1) sum += _grid[row - 1][col + 1];
        if (row < _grid.Length - 1 && col > 0) sum += _grid[row + 1][col - 1];
        if (row < _grid.Length - 1 && col < _grid[row].Length - 1) sum += _grid[row + 1][col + 1];

        return sum;
    }
}

public class Q3242_DesignNeighborSumService
{
    public static TheoryData<string[], int[][], int[], int[]> TestData => new()
    {
        {
            ["adjacentSum", "adjacentSum", "diagonalSum", "diagonalSum"],
            [[0, 1, 2], [3, 4, 5], [6, 7, 8]],
            [1, 4, 4, 8],
            [6, 16, 16, 4]
        },
        {
            ["adjacentSum", "diagonalSum"],
            [[1, 2, 0, 3], [4, 7, 15, 6], [8, 9, 10, 11], [12, 13, 14, 5]],
            [15, 9],
            [23, 45]
        }
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] commands, int[][] init, int[] input, int[] expected)
    {
        var sut = new NeighborSum(init);
        for (var i = 0; i < commands.Length; i++)
        {
            var cmd = commands[i];
            switch (cmd)
            {
                case "adjacentSum":
                    Assert.Equal(expected[i], sut.AdjacentSum(input[i]));
                    break;
                case "diagonalSum":
                    Assert.Equal(expected[i], sut.DiagonalSum(input[i]));
                    break;
            }
        }
    }
}
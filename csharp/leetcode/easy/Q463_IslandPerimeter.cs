namespace dojo.leetcode;

public class Q463_IslandPerimeter
{
    private const int top = 0;
    private const int left = 0;
    private int bottom;
    private int right;

    // TC: O(n), SC: O(1)
    public int IslandPerimeter(int[][] grid)
    {
        bottom = grid.Length - 1;
        right = grid[0].Length - 1;
        var result = 0;
        for (var row = 0; row < grid.Length; row++)
        {
            // Console.WriteLine($"row: {grid.Length}, col: {grid[row].Length}");
            for (var col = 0; col < grid[row].Length; col++)
            {
                if (grid[row][col] == 0) continue;
                var temp = GetGridPerimeter(grid, row, col);
                // Console.WriteLine($"row: {row}, col: {col}, p: {temp}");
                result += temp;
            }
        }
        return result;
    }

    public int GetGridPerimeter(int[][] grid, int row, int col) =>
        CheckNorth(grid, row, col) +
        CheckEast(grid, row, col) +
        CheckSouth(grid, row, col) +
        CheckWest(grid, row, col);

    public int CheckNorth(int[][] grid, int row, int col) => row == top ? 1 : CheckIsLand(grid, row - 1, col);

    public int CheckSouth(int[][] grid, int row, int col) => row == bottom ? 1 : CheckIsLand(grid, row + 1, col);

    public int CheckEast(int[][] grid, int row, int col) => col == right ? 1 : CheckIsLand(grid, row, col + 1);

    public int CheckWest(int[][] grid, int row, int col) => col == left ? 1 : CheckIsLand(grid, row, col - 1);

    public int CheckIsLand(int[][] grid, int row, int col) => grid[row][col] == 1 ? 0 : 1;
}

public class Q463_IslandPerimeterTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1]}, 4],
        [new int[][] {[1, 0]}, 4],
        [new int[][] {[0, 1, 0, 0], [1, 1, 1, 0], [0, 1, 0, 0], [1, 1, 0, 0]}, 16],
    ];
}

public class Q463_IslandPerimeterTests
{
    [Theory]
    [ClassData(typeof(Q463_IslandPerimeterTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q463_IslandPerimeter();
        var actual = sut.IslandPerimeter(input);
        Assert.Equal(expected, actual);
    }
}
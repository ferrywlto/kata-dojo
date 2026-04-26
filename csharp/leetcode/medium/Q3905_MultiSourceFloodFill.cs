public class Q3905_MultiSourceFloodFill//(ITestOutputHelper output)
{
    public int[][] ColorGrid(int n, int m, int[][] sources)
    {
        // initialize result
        var result = new int[n][];
        for (var row = 0; row<n; row++)
            result[row] = new int[m];

        var processList = new HashSet<(int row, int col)>();

        foreach (var input in sources)
            result[input[0]][input[1]] = input[2];

        // Get the surrounding cells
        foreach (var input in sources)
            AddSurroundingZeros(input[0], input[1], result, processList);

        while (processList.Count > 0)
        {
            var toBeUpdated = new List<(int row, int col, int val)>();

            var newProcessList = new HashSet<(int row, int col)>();
            foreach (var (row, col) in processList)
            {
                // calculate max for surroundings
                var max = GetSurroundingMax(row, col, result);
                toBeUpdated.Add((row, col, max));
            }

            foreach (var (row, col, val) in toBeUpdated)
                result[row][col] = val;

            foreach (var (row, col, _) in toBeUpdated)
                AddSurroundingZeros(row, col, result, newProcessList);

            processList = newProcessList;
        }

        return result;
    }

    private int GetSurroundingMax(int row, int col, int[][] source)
    {
        var max = 0;
        if (row > 0) max = Math.Max(max, source[row - 1][col]);
        if (row < source.Length - 1) max = Math.Max(max, source[row + 1][col]);
        if (col > 0) max = Math.Max(max, source[row][col - 1]);
        if (col < source[row].Length - 1) max = Math.Max(max, source[row][col + 1]);
        return max;
    }
    private void AddSurroundingZeros(int row, int col, int[][] source, HashSet<(int row, int col)> processList)
    {
        if (row > 0 && source[row - 1][col] == 0) processList.Add((row - 1, col));
        if (row < source.Length - 1 && source[row + 1][col] == 0) processList.Add((row + 1, col));
        if (col > 0 && source[row][col - 1] == 0) processList.Add((row, col - 1));
        if (col < source[row].Length - 1 && source[row][col + 1] == 0) processList.Add((row, col + 1));
    }

    public static TheoryData<int, int, int[][], int[][]> TestData => new()
    {
        {
            3, 3,
            [[0, 0, 1], [2, 2, 2]],
            [[1, 1, 2], [1, 2, 2], [2, 2, 2]]
        },
        {
            3,3,
            [[0,1,3],[1,1,5]],
            [[3,3,3],[5,5,5],[5,5,5]]
        },
        {
            2,2,
            [[1,1,5]],
            [[5,5],[5,5]]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int m, int n, int[][] input, int[][] expected)
    {
        var actual = ColorGrid(m, n, input);
        Assert.Equal(expected, actual);
    }
}

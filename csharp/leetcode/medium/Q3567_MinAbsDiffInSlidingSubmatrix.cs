public class Q3567_MinAbsDiffInSlidingSubmatrix
{
    // TC: O(n^2), each possible grid run through each cell in the cell
    // SC: O((m - k) * (n - k))
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        var m = grid.Length - k + 1;
        var n = grid[0].Length - k + 1;

        var result = new int[m][];

        for (var row = 0; row < m; row++)
        {
            result[row] = new int[n];
            for (var col = 0; col < n; col++)
            {
                result[row][col] = SubMatrix(grid, row, col, k);
            }
        }
        return result;
    }

    private int SubMatrix(int[][] input, int startX, int startY, int size)
    {
        Span<int> arr = stackalloc int[size * size];

        int minDiff = int.MaxValue;
        for (var row = startX; row < startX + size; row++)
        {
            for (var col = startY; col < startY + size; col++)
            {
                var cell = input[row][col];
                arr[(size * (row - startX)) + (col - startY)] = cell;
            }
        }
        arr.Sort();

        for (var i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i + 1] == arr[i]) continue;

            var diff = Math.Abs(arr[i + 1] - arr[i]);
            if (diff < minDiff) minDiff = diff;
        }

        if (minDiff == int.MaxValue) return 0;
        return minDiff;
    }

    public static TheoryData<int[][], int, int[][]> TestData => new()
    {
        { [[1, 8], [3, -2]], 2, [[2]] },
        { [[3, -1]], 1, [[0, 0]] },
        { [[1, -2, 3], [2, 3, 5]], 2, [[1, 2]] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, int[][] expected)
    {
        var actual = MinAbsDiff(input, k);
        Assert.Equal(expected, actual);
    }
}

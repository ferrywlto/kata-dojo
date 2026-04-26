public class Q3905_MultiSourceFloodFill
{
    // TC: O(n * m)
    // SC: O(n * m)
    public int[][] ColorGrid(int n, int m, int[][] sources)
    {
        // initialize result
        var result = new int[n][];
        for (var row = 0; row < n; row++)
            result[row] = new int[m];

        var q = new Queue<int>();

        void Enqueue(int row, int col)
        {
            if (row < 0 || row >= n || col < 0 || col >= m) return;
            if (result[row][col] != 0) return;  // already colored

            result[row][col] = -1;            // already scheduled

            var idx = ToIdx(row, col);
            q.Enqueue(idx);
        }
        void EnqueueNeighbors(int row, int col)
        {
            Enqueue(row - 1, col);
            Enqueue(row + 1, col);
            Enqueue(row, col - 1);
            Enqueue(row, col + 1);
        }
        int ToIdx(int row, int col) => row * m + col;
        (int row, int col) ToRowCol(int idx) => (idx / m, idx % m);

        foreach (var input in sources)
            result[input[0]][input[1]] = input[2];

        // Get the surrounding cells
        foreach (var input in sources)
            EnqueueNeighbors(input[0], input[1]);

        var cellIdxList = new List<(int row, int col)>();
        var cellValList = new List<int>();

        while (q.Count > 0)
        {
            // clear the current queue
            while (q.Count > 0)
            {
                var (row, col) = ToRowCol(q.Dequeue());
                // calculate max for surroundings
                cellValList.Add(GetSurroundingMax(row, col, result));
                cellIdxList.Add((row, col));
            }

            for (var i = 0; i < cellIdxList.Count; i++)
            {
                var (row, col) = cellIdxList[i];
                result[row][col] = cellValList[i];
            }

            for (var i = 0; i < cellIdxList.Count; i++)
            {
                var (row, col) = cellIdxList[i];
                EnqueueNeighbors(row, col);
            }

            cellIdxList.Clear();
            cellValList.Clear();
        }

        return result;
    }
    private int GetSurroundingMax(int row, int col, int[][] source)
    {
        var max = 0;

        if (row > 0 && source[row - 1][col] > max) max = source[row - 1][col];
        if (row < source.Length - 1 && source[row + 1][col] > max) max = source[row + 1][col];
        if (col > 0 && source[row][col - 1] > max) max = source[row][col - 1];
        if (col < source[row].Length - 1 && source[row][col + 1] > max) max = source[row][col + 1];

        return max;
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

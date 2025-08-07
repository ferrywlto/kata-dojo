public class Q861_ScoreAfterFlippingMatrix
{
    // TC: O(row + col)
    // SC: O(1)
    public int MatrixScore(int[][] grid)
    {
        var rowCount = grid.Length;
        var colCount = grid[0].Length;

        // var result = 0;
        for (var row = 0; row < rowCount; row++)
        {
            // only need to check first col
            if (grid[row][0] == 0)
            {
                // flip row
                for (var col = 0; col < grid[row].Length; col++)
                {
                    grid[row][col] = grid[row][col] == 0 ? 1 : 0;
                }
            }
        }

        for (var col = 1; col < colCount; col++)
        {
            var zeroCount = 0;
            var oneCount = 0;

            for (var row = 0; row < grid.Length; row++)
            {
                if (grid[row][col] == 0) zeroCount++;
                else oneCount++;
            }

            if (zeroCount > oneCount)
            {
                // flip col
                for (var row = 0; row < grid.Length; row++)
                {
                    grid[row][col] = grid[row][col] == 0 ? 1 : 0;
                }
            }
        }

        return Sum(grid);
    }
    private int Sum(int[][] input)
    {
        var result = 0;
        for (var i = 0; i < input.Length; i++)
        {
            result += FromBinary(input[i]);
        }
        return result;
    }
    private int FromBinary(int[] input)
    {
        var result = input[0];
        for (var i = 1; i < input.Length; i++)
        {
            result <<= 1;
            result += input[i];
        }
        return result;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[0]], 1},
        {[
            [0,0,1,1],
            [1,0,1,0],
            [1,1,0,0]
        ], 39},
        {[
            [0,1,1],
            [1,1,1],
            [0,1,0]
        ], 18},
        {[
            [1,1,1],
            [0,1,0],
            [1,0,0],
            [1,0,1]
        ], 25}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MatrixScore(input);
        Assert.Equal(expected, actual);
    }
}

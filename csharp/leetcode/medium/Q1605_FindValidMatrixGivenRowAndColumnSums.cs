public class Q1605_FindValidMatrixGivenRowAndColumnSums
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        var result = new int[rowSum.Length][];
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = new int[colSum.Length];
        }

        // using two-pointers with while loop will be fastest, but not push for that now.
        for(var row = 0; row < rowSum.Length; row++)
        {
            for(var col = 0; col < colSum.Length; col++)
            {
                if (rowSum[row] == 0 || colSum[col] == 0) continue;

                // From the hints
                var smaller = Math.Min(rowSum[row], colSum[col]);
                result[row][col] = smaller;
                rowSum[row] -= smaller;
                colSum[col] -= smaller;
            }
        }

        return result;
    }

    public static TheoryData<int[], int[], int[][]> TestData => new()
    {
        { [3, 8], [4, 7], [[3, 0], [1, 7]] },
        { [5, 7, 10], [8, 6, 8], [[5, 0, 0], [3, 4, 0], [0, 2, 8]] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] rowSum, int[] colSum, int[][] expected)
    {
        var actual = RestoreMatrix(rowSum, colSum);
        Assert.Equal(expected, actual);
    }
}

class Q1582_SpecialPositionsInBinaryMatrix
{
    // TC: O(n), where n is the number of cells in total + m number of 1s to check, in worst case m is the length of mat (rows) (all 1 lies on diagnoal)
    // SC: O(n+m), where n is number of rows and m is number of columns
    public int NumSpecial(int[][] mat)
    {
        if (mat.Length == 1 && mat[0].Length == 1) return mat[0][0];

        var result = 0;
        var oneInRow = new int[mat.Length];
        var oneInCol = new int[mat[0].Length];

        for (var row = 0; row < mat.Length; row++)
        {
            for (var col = 0; col < mat[row].Length; col++)
            {
                if (mat[row][col] == 1)
                {
                    if (
                        oneInRow[row] == 0 &&
                        oneInCol[col] == 0 &&
                        !HasAnotherOne(mat, row, col)
                    ) result++;

                    oneInRow[row]++;
                    oneInCol[col]++;
                }
            }
        }
        return result;
    }
    public bool HasAnotherOne(int[][] input, int startRow, int startCol)
    {
        var row = input[startRow];
        for (var i = startCol + 1; i < row.Length; i++)
            if (row[i] == 1) return true;
        for (var j = startRow + 1; j < input.Length; j++)
            if (input[j][startCol] == 1) return true;
        return false;
    }
}

class Q1582_SpecialPositionsInBinaryMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1,0,0],
                [0,0,1],
                [1,0,0]
            }, 1
        ],
        [
            new int[][]
            {
                [1,0,0],
                [0,1,0],
                [0,0,1]
            }, 3
        ],
        [
            new int[][]
            {
                [0,0,0,0,0,0,0,0],
                [0,1,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0],
                [0,0,0,0,0,0,0,0],
                [1,0,0,0,0,0,0,1],
                [0,0,0,0,0,0,1,0],
                [0,0,0,0,0,0,0,1]
            }, 2
        ]
    ];
}
public class Q1582_SpecialPositionsInBinaryMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1582_SpecialPositionsInBinaryMatrixTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1582_SpecialPositionsInBinaryMatrix();
        var actual = sut.NumSpecial(input);
        Assert.Equal(expected, actual);
    }
}

public class Q1277_CountSquareSubmatricesWithAllOnes
{
    // private readonly int[][] _matrix;
    public int CountSquares(int[][] matrix)
    {
        var count = Check(matrix, [0], [0], 0, 0);
        return 0;
    }
    private int Check(int[][] matrix, List<int> rowList, List<int> colList, int rowIdx, int colIdx)
    {
        var rowCount = matrix.Length;
        var colCount = matrix[0].Length;

        if (rowIdx >= rowCount || colIdx >= colCount) return 0;


        var newRow = new List<int>();
        var newCol = new List<int>();
        // var allColOne = true;


        foreach (var row in rowList)
        {
            if (matrix[row][colIdx] == 0) return 0;
            newRow.Add(row);
        }

        foreach (var col in colList)
        {
            if (matrix[rowIdx][col] == 0) return 0;
            newCol.Add(col);
        }
        for (var row = 0; row < rowList.Count; row++)
        {
            if (matrix[row][colIdx] == 0) return 0;
        }
        for (var i = 0; i < colList.Count; i++)
        {
            if (matrix[i][colIdx] == 0) return 0;
        }

        if (matrix[rowIdx][colIdx] == 1)
        {
            // newRow.Add()
            //     return 1 + Check()
        }
        for (var i = 0; i < rowList.Count; i++)
        {
            // if ()
        }
        return 0;
    }

    public static TheoryData<int[][], int> TestData => new()
    {
        {
            [
                [0, 1, 1, 1],
                [1, 1, 1, 1],
                [0, 1, 1, 1]
            ],
            15
        },
        {
            [
                [1, 0, 1],
                [1, 1, 1],
                [1, 0, 1]
            ],
            7
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] matrix, int expected)
    {
        var result = CountSquares(matrix);
        Assert.Equal(expected, result);
    }
}

public class Q1277_CountSquareSubmatricesWithAllOnes(ITestOutputHelper output)
{
    // private readonly int[][] _matrix;
    public int CountSquares(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var result = 0;

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (matrix[row][col] == 1)
                {
                    // greedy get one of this row to get how many columns is one
                    result += 1 + ExpansionSum(matrix, row, col);
                    // then shrink the row to column
                    // then the min col size is number of squares inside
                    // e.g if col is 2 at last, that means 1x1 and 2x2 possible 
                }
                //do sth
            }
        }

        return 0;
    }

    // do a recursive expansion add
    private int ExpansionSum(int[][] input, int startRow, int startCol)
    {
        var rowDepth = input.Length;

        for (var row = startRow; row < rowDepth; row++)
        {
            var colDepth = 0;
            for (var col = startCol; col < colDepth; col++)
            {
                if (input[row][col] == 1)
                {
                    colDepth++;
                }
                else
                {
                    break;
                }
            }
            // shrink the square search on 0
            rowDepth = Math.Min(rowDepth, startRow + colDepth);
        }
        output.WriteLine($"Depth of [{startRow},{startCol}]: {rowDepth}");
        return rowDepth;
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

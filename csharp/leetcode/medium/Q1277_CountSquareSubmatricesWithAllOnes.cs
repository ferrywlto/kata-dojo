public class Q1277_CountSquareSubmatricesWithAllOnes
{
    public int CountSquares(int[][] matrix)
    {
        var rows = matrix.Length;
        var cols = matrix[0].Length;
        var result = 0;
        var dp = new int[rows, cols];

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                if (matrix[row][col] == 1)
                {
                    if (row == 0 || col == 0)
                    {
                        dp[row, col] = 1;
                    }
                    else
                    {
                        // The main technique is this line
                        // count[row, col] = 1 + Min(top, left, topLeft);
                        // Explanation
                        /*
                        Input grid:                 DP grid:
                        1 1 1                       1 1 1
                        1 1 1          becomes      1 2 2
                        1 1 1                       1 2 3
                        */
                        // The the position [1,1] is included twice thus 2, it deduce by looking backward while storing the current cell was included in how many squares

                        dp[row, col] = 1 + Math.Min(
                            dp[row - 1, col], // top: already calculated
                            Math.Min(
                                dp[row, col - 1], // left: already calculated
                                dp[row - 1, col - 1] // top-left: already calculated
                            )
                        );
                    }

                    result += dp[row, col];
                }
            }
        }

        return result;
    }


    // First trick
    // counting how many squares in N*M all ones:
    // Sum(N*M, N-1*M-1, ... 1,M)
    // Proof
    // [1,1]
    // 2x1 * 1x1

    // [1]
    // [1]
    // 1*2 * 1x1

    // [1,1,1]
    // [1,1,1]
    // 3x2 * 1x1
    // 2x1 * 2x2

    // [1,1]
    // [1,1]
    // [1,1]
    // 2*3 * 1x1
    // 1x2 * 2x2

    // [1,1,1,1]
    // [1,1,1,1]
    // [1,1,1,1]
    // 4x3 * 1x1
    // 3x2 * 2x2
    // 2x1 * 3x3

    // [1,1,1]
    // [1,1,1]
    // [1,1,1]
    // [1,1,1]
    // 3x4 * 1x1
    // 2x3 * 2x2
    // 1x2 * 3x3

    // 1 * 1x1 = 1x1

    // 4 * 1x1 = 2x2
    // 1 * 2x2 = 1x1

    // 9 * 1x1 = 3x3
    // 4 * 2x2 = 2x2
    // 1 * 3x3 = 1x1

    // 16 * 1x1 = 4x4
    // 9 * 2x2 = 3x3
    // 4 * 3x3 = 2x2
    // 1 x 4x4 = 1x1
    public int SquareCount(int numRows, int numCols)
    {
        var tmp = numRows * numCols;

        if (numRows == 1 || numCols == 1)
            return tmp;

        return tmp + SquareCount(numRows - 1, numCols - 1);
    }

    [Fact]
    public void TestSquareCount()
    {
        var actual = SquareCount(1, 1);
        Assert.Equal(1, actual);

        actual = SquareCount(2, 2);
        Assert.Equal(5, actual);

        actual = SquareCount(3, 3);
        Assert.Equal(14, actual);

        actual = SquareCount(1, 2);
        Assert.Equal(2, actual);

        actual = SquareCount(2, 1);
        Assert.Equal(2, actual);

        actual = SquareCount(1, 3);
        Assert.Equal(3, actual);

        actual = SquareCount(3, 1);
        Assert.Equal(3, actual);

        actual = SquareCount(2, 3);
        Assert.Equal(8, actual);

        actual = SquareCount(3, 2);
        Assert.Equal(8, actual);

        actual = SquareCount(4, 3);
        Assert.Equal(20, actual);

        actual = SquareCount(3, 4);
        Assert.Equal(20, actual);

        actual = SquareCount(4, 4);
        Assert.Equal(30, actual);
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

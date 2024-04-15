public class Q867_TransposeMatrix
{
    // TC: O(n), n is total elements in matrix
    // SC: O(n) if count resulting matrix, O(1) else
    public int[][] Transpose(int[][] matrix) 
    {
        var numCols = matrix[0].Length;
        var numRows = matrix.Length;
        var result = new int[numCols][];
        for (var row = 0; row < result.Length; row++)
        {
            result[row] = new int[numRows];
        }  

        for(var row = 0; row < numCols; row++)
        {
            for(var col=0; col< numRows; col++)
            {
                result[row][col] = matrix[col][row];
            }
        }
        return result;    
    }
}

public class Q867_TransposeMatrixTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [
            new int[][] {
                [1,2,3],
                [4,5,6],
                [7,8,9],
            }, 
            new int[][] {
                [1,4,7],
                [2,5,8],
                [3,6,9],
            }, 
        ],
        [
            new int[][] {
                [1,2,3],
                [4,5,6],
            },
            new int[][] {
                [1,4],
                [2,5],
                [3,6],
            },
        ],
        [
            new int[][] {
                [1,4],
                [2,5],
                [3,6],
            },
            new int[][] {
                [1,2,3],
                [4,5,6],
            },
        ],
    ];
}

public class Q867_TransposeMatrixTests
{
    [Theory]
    [ClassData(typeof(Q867_TransposeMatrixTestData))]
    public void OfficialTestCases(int[][] input, int[][] expected)
    {
        var sut = new Q867_TransposeMatrix();
        var actual = sut.Transpose(input);
        Assert.Equal(expected, actual);
    }
}
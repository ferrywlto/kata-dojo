using System.Data;

class Q566_ReshapeTheMatrix
{
    // check r * c == mat.length * mat[0].length
    // transform to linear first 1*n vector
    // resharpe to r * c
    // consider 3x3, target 5 -> row 2, col 2 -> 1,1
    // new row = target / c,  new col = target % c
    // TC: O(n)
    // SC: O(n)
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        if (r * c != mat.Length * mat[0].Length) return mat;
        var targetMatrix = new int[r][];
        for(var z=0; z<targetMatrix.Length; z++)
        {
            targetMatrix[z] = new int[c];
        }
        for(var i=0; i<mat.Length; i++)
        {
            for(var j=0; j<mat[i].Length; j++)
            {
                var linearIdx = i * mat[i].Length + j;
                // Console.WriteLine($"i:{i}, j:{j}, val:{mat[i][j]}, r:{linearIdx / c}, c:{linearIdx % c}");
                targetMatrix[linearIdx / c][linearIdx % c] = mat[i][j]; 
            }
        }
        return targetMatrix;
    }
}

class Q566_ReshapeTheMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1, 2], [3, 4]}, 1, 4, new int[][] {[1, 2, 3, 4]}],
        [new int[][] {[1, 2], [3, 4]}, 2, 4, new int[][] {[1, 2], [3, 4]}],
    ];
}

public class Q566_ReshapeTheMatrixTests
{
    [Theory]
    [ClassData(typeof(Q566_ReshapeTheMatrixTestData))]
    public void OfficialTestCases(int[][] mat, int r, int c, int[][] expected)
    {
        var sut = new Q566_ReshapeTheMatrix();
        var actual = sut.MatrixReshape(mat, r, c);
        Assert.Equal(expected, actual);
    }
}
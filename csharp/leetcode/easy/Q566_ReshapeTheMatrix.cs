namespace dojo.leetcode;

public class Q566_ReshapeTheMatrix
{
    // check r * c == mat.length * mat[0].length
    // transform to linear first 1*n vector
    // resharpe to r * c    
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        return [];
    }
}

public class Q566_ReshapeTheMatrixTestData : TestData
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
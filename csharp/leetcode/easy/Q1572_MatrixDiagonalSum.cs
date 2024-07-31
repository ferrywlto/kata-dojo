class Q1572_MatrixDiagonalSum
{
    // TC: O(n), where n is number of rows in mat
    // SC: O(1), space used is fixed to two integer variables
    public int DiagonalSum(int[][] mat)
    {
        var result = 0;
        var last = mat[0].Length - 1;
        for (var i = 0; i < mat.Length; i++)
        {
            result += mat[i][i];
            if (i != last) result += mat[i][last];
            last--;
        }
        return result;
    }
}
class Q1572_MatrixDiagonalSumTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [1,2,3],
                [4,5,6],
                [7,8,9]
            }, 25
        ],
        [
            new int[][]
            {
                [1,1,1,1],
                [1,1,1,1],
                [1,1,1,1],
                [1,1,1,1]
            }, 8
        ],
        [new int[][] {[5]}, 5]
    ];
}
public class Q1572_MatrixDiagonalSumTests
{
    [Theory]
    [ClassData(typeof(Q1572_MatrixDiagonalSumTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1572_MatrixDiagonalSum();
        var actual = sut.DiagonalSum(input);
        Assert.Equal(expected, actual);
    }
}
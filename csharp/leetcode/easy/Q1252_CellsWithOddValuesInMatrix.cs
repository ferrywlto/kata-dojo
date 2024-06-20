class Q1252_CellsWithOddValuesInMatrix
{
    public int OddCells(int m, int n, int[][] indices)
    {
        var matrix = new int[m, n];
        for(var i=0; i<indices.Length; i++)
        {
            (int opRow, int opCol) = (indices[i][0], indices[i][1]);
            for(var j=0; j<matrix.GetLength(1); j++) matrix[opRow, j]++;
            for(var k=0; k<matrix.GetLength(0); k++) matrix[k, opCol]++;
        }
        return CountOdd(matrix);
    }
    int CountOdd(int[,] input)
    {
        var oddCount = 0;
        for (int i = 0; i < input.GetLength(0); i++)
        {
            for (int j = 0; j < input.GetLength(1); j++)
            {
                if (input[i, j] % 2 != 0) oddCount++;
            }
        }
        return oddCount;
    }
}
class Q1252_CellsWithOddValuesInMatrixTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [2, 3, new int[][]{[0,1],[1,1]}, 6],
        [2, 2, new int[][]{[1,1],[0,0]}, 0],
    ];
}
public class Q1252_CellsWithOddValuesInMatrixTests
{
    [Theory]
    [ClassData(typeof(Q1252_CellsWithOddValuesInMatrixTestData))]
    public void OfficialTestCases(int m, int n, int[][] input, int expected)
    {
        var sut = new Q1252_CellsWithOddValuesInMatrix();
        var actual = sut.OddCells(m, n, input);
        Assert.Equal(expected, actual);
    }
}
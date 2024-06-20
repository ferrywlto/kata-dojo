class Q1252_CellsWithOddValuesInMatrix
{
    public int OddCells(int m, int n, int[][] indices)
    {
        return 0;
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
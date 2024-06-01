
class Q1030_MatrixCellsInDistanceOrder
{
    public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter) {
        return [];   
    }    
}

class Q1030_MatrixCellsInDistanceOrderTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [1,2,0,0, new int[][]{[0,0],[0,1]}],
        [2,2,0,1, new int[][]{[0,1],[0,0],[1,1],[1,0]}],
        [2,3,1,2, new int[][]{[1,2],[0,2],[1,1],[0,1],[1,0],[0,0]}],
    ];
}

public class Q1030_MatrixCellsInDistanceOrderTests
{
    [Theory]
    [ClassData(typeof(Q1030_MatrixCellsInDistanceOrderTestData))]
    public void OfficialTestCases(int rows, int cols, int rCenter, int cCenter, int[][] expected)
    {
        var sut = new Q1030_MatrixCellsInDistanceOrder();
        var actual = sut.AllCellsDistOrder(rows, cols, rCenter, cCenter);
        Assert.Equal(expected, actual);
    }
}
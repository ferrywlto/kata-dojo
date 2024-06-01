class Q1030_MatrixCellsInDistanceOrder
{
    // TC: O(n), where n is rows*cols
    // SC: O(n), where n is also rows*cols as the answer need to list all cells
    public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
    {
        var set = new List<(int distance, int[] coord)>();
        for (var row = 0; row < rows; row++)
        {
            var rowDistance = Math.Abs(row - rCenter);
            for (var col = 0; col < cols; col++)
            {
                var colDistance = Math.Abs(col - cCenter);
                set.Add((rowDistance + colDistance, new int[2] { row, col }));
            }
        }
        set.Sort(new CoordComparer());
        return set.Select(x => x.coord).ToArray();
    }
    class CoordComparer : IComparer<(int distance, int[] coord)>
    {
        public int Compare((int distance, int[] coord) x, (int distance, int[] coord) y)
        {
            int result = x.distance.CompareTo(y.distance);
            if (result != 0)
            {
                return result;
            }
            return x.coord[0].CompareTo(y.coord[0]);
        }
    }

}

class Q1030_MatrixCellsInDistanceOrderTestData : TestData
{
    protected override List<object[]> Data =>
    [
        // [1,2,0,0, new int[][]{[0,0],[0,1]}],
        // [2,2,0,1, new int[][]{[0,1],[0,0],[1,1],[1,0]}],
        // [2,3,1,2, new int[][]{[1,2],[0,2],[1,1],[0,1],[1,0],[0,0]}],
        [3,4,0,1, new int[][]{[0,1],[0,0],[0,2],[1,1],[0,3],[1,0],[1,2],[2,1],[1,3],[2,0],[2,2],[2,3]}],
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
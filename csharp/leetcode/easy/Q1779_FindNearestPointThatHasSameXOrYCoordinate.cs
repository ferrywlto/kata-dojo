class Q1779_FindNearestPointThatHasSameXOrYCoordinate
{
    // TC: O(n), where n is length of points
    // SC: O(1), space used is fixed
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        var min = int.MaxValue;
        var minIdx = -1;
        for (var i = 0; i < points.Length; i++)
        {
            var p = points[i];
            if (p[0] == x || p[1] == y)
            {
                var temp = Math.Abs(p[0] - x) + Math.Abs(p[1] - y);
                if (temp < min)
                {
                    min = temp;
                    minIdx = i;
                }
            }
        }
        return minIdx;
    }
}
class Q1779_FindNearestPointThatHasSameXOrYCoordinateTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3,4, new int[][] {[1,2],[3,1],[2,4],[2,3],[4,4]}, 2],
        [3,4, new int[][] {[3,4]}, 0],
        [3,4, new int[][] {[2,3]}, -1],
    ];
}
public class Q1779_FindNearestPointThatHasSameXOrYCoordinateTests
{
    [Theory]
    [ClassData(typeof(Q1779_FindNearestPointThatHasSameXOrYCoordinateTestData))]
    public void OfficialTestCases(int x, int y, int[][] input, int expected)
    {
        var sut = new Q1779_FindNearestPointThatHasSameXOrYCoordinate();
        var actual = sut.NearestValidPoint(x, y, input);
        Assert.Equal(expected, actual);
    }
}

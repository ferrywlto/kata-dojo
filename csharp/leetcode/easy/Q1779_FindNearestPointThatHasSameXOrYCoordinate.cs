class Q1779_FindNearestPointThatHasSameXOrYCoordinate
{
    public int NearestValidPoint(int x, int y, int[][] points)
    {
        return 0;
    }
}
class Q1779_FindNearestPointThatHasSameXOrYCoordinateTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3,4, new int[][] {[1,2],[3,1],[2,4],[2,3],[4,4]}, 2],
        [3,4, new int[][] {[3,4]}, 1],
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
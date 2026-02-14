class Q1266_MinimumTimeVisitingAllPoints
{
    // TC: O(n), n is size of points
    // SC: O(1), no space used in operation
    public int MinTimeToVisitAllPoints(int[][] points)
    {
        if (points.Length == 1) return 0;
        var result = 0;
        for (var i = 0; i < points.Length - 1; i++)
        {
            var pointA = points[i];
            var pointB = points[i + 1];
            var xDiff = Math.Abs(pointA[0] - pointB[0]);
            var yDiff = Math.Abs(pointA[1] - pointB[1]);
            var dDiff = Math.Min(xDiff, yDiff);
            result += dDiff + Math.Abs(xDiff - yDiff);
        }
        return result;
    }
}
class Q1266_MinimumTimeVisitingAllPointsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,1],[3,4],[-1,0]}, 7],
        [new int[][] {[3,2],[-2,2]}, 5],
    ];
}
public class Q1266_MinimumTimeVisitingAllPointsTests
{
    [Theory]
    [ClassData(typeof(Q1266_MinimumTimeVisitingAllPointsTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1266_MinimumTimeVisitingAllPoints();
        var actual = sut.MinTimeToVisitAllPoints(input);
        Assert.Equal(expected, actual);
    }
}

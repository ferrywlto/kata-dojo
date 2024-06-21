
class Q1266_MinimumTimeVisitingAllPoints
{
        public int MinTimeToVisitAllPoints(int[][] points) {
        return 0;   
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
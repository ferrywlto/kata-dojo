
class Q883_ProjectionAreaOf3DShape
{
    public int ProjectionArea(int[][] grid) 
    {
        return 0;
    }
}

class Q883_ProjectionAreaOf3DShapeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[][] {[1,2],[3,4]}, 17],
        [new int[][] {[2]}, 5],
        [new int[][] {[1,0],[0,2]}, 8],
    ];
}

public class Q883_ProjectionAreaOf3DShapeTests
{
    [Theory]
    [ClassData(typeof(Q883_ProjectionAreaOf3DShapeTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q883_ProjectionAreaOf3DShape();
        var actual = sut.ProjectionArea(input);
        Assert.Equal(expected, actual);
    }
}
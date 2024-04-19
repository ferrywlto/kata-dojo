
class Q892_SurfaceAreaOf3DShape
{
    public int SurfaceArea(int[][] grid)
    {
        return 0;

    }
}

class Q892_SurfaceAreaOf3DShapeTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[][]{[1,2],[3,4]}, 34],
        [new int[][]{[1,1,1],[1,0,1],[1,1,1]}, 32],
        [new int[][]{[2,2,2],[2,1,2],[2,2,2]}, 46],
    ];
}

public class Q892_SurfaceAreaOf3DShapeTests
{
    [Theory]
    [ClassData(typeof(Q892_SurfaceAreaOf3DShapeTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q892_SurfaceAreaOf3DShape();
        var actual = sut.SurfaceArea(input);
        Assert.Equal(expected, actual);
    }
}
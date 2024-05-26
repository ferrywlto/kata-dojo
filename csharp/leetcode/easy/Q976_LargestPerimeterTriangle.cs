
class Q976_LargestPerimeterTriangle
{
    public int LargestPerimeter(int[] nums) {
        return 0;
    }
}

class Q976_LargestPerimeterTriangleTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {2,1,2}, 5],
        [new int[] {1,2,1,10}, 0],
    ];
}

public class Q976_LargestPerimeterTriangleTests
{
    [Theory]
    [ClassData(typeof(Q976_LargestPerimeterTriangleTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q976_LargestPerimeterTriangle();
        var actual = sut.LargestPerimeter(input);
        Assert.Equal(expected, actual);
    }
}

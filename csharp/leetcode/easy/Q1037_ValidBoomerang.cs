class Q1037_ValidBoomerang
{
    // TC: O(1)
    // SC: O(1)
    // This cannot use Pythagorean theorem to find the lenghts and then use 
    // the a + b > c triganle properties to solve due to precision lost issue 
    public bool IsBoomerang(int[][] points)
    {
        // double slope1 = (points[1][1] - points[0][1]) / (double)(points[1][0] - points[0][0]);
        // double slope2 = (points[2][1] - points[1][1]) / (double)(points[2][0] - points[1][0]);
        double slopeCheck1 = (points[1][1] - points[0][1]) * (points[2][0] - points[1][0]);
        double slopeCheck2 = (points[1][0] - points[0][0]) * (points[2][1] - points[1][1]);
        /*
        (y2 - y1) / (x2 - x1) == (y4 - y3) / (x4 - x3), change to below by throwing the divisor to opposite side
        (y2 - y1) * (x4 - x3) == (y4 - y3) * (x2 - x1) 
        This can avoid precision loss from very big/small number, also prevent division by zero issue
        */
        return slopeCheck1 != slopeCheck2;
    }
}
class Q1037_ValidBoomerangTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][]{[1,1],[2,3],[3,2]}, true],
        [new int[][]{[1,1],[2,2],[3,3]}, false],
        [new int[][]{[1,1],[2,2],[7,7]}, false],
        [new int[][]{[0,0],[11,22],[18,36]}, false],
        [new int[][]{[0,0],[1,0],[2,2]}, true],
        [new int[][]{[0,0],[1,1],[1,1]}, false],
    ];
}
public class Q1037_ValidBoomerangTests
{
    [Theory]
    [ClassData(typeof(Q1037_ValidBoomerangTestData))]
    public void OfficialTestCases(int[][] input, bool expected)
    {
        var sut = new Q1037_ValidBoomerang();
        var actual = sut.IsBoomerang(input);
        Assert.Equal(expected, actual);
    }
}

class Q812_LargestTriangleArea
{
    // This can be achieved O(n log n) + O(m) time with Convex Hull algorithm.
    // However this is not the purpose of kata dojo thus not implementing it. 
    // TC: O(n^3)
    // SC: O(1)
    public double LargestTriangleArea(int[][] points)
    {
        var largestArea = double.MinValue;

        for (var i = 0; i < points.Length - 2; i++)
        {
            for (var j = i + 1; j < points.Length - 1; j++)
            {
                for (var k = j + 1; k < points.Length; k++)
                {
                    var area = 0.5 * Math.Abs
                    (
                        points[i][0] * (points[j][1] - points[k][1]) +
                        points[j][0] * (points[k][1] - points[i][1]) +
                        points[k][0] * (points[i][1] - points[j][1])
                    );
                    if (area > largestArea) largestArea = area;
                }
            }
        }

        return largestArea;
    }
}

class Q812_LargestTriangleAreaTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][] { [0,0],[0,1],[1,0],[0,2],[2,0] }, 2.00000
        ],
        [
            new int[][] { [1,0],[0,0],[0,1] }, 0.50000
        ]
    ];
}

public class Q812_LargestTriangleAreaTests
{
    [Theory]
    [ClassData(typeof(Q812_LargestTriangleAreaTestData))]
    public void OfficialTestCases(int[][] input, double expected)
    {
        var sut = new Q812_LargestTriangleArea();
        var actual = sut.LargestTriangleArea(input);
        Assert.Equal(expected, actual);
    }
}
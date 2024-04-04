
namespace dojo.leetcode;

public class Q812_LargestTriangleArea
{
    public double LargestTriangleArea(int[][] points) 
    {
        return 0;    
    }
}

public class Q812_LargestTriangleAreaTestData : TestData
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
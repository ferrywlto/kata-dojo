
class Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints
{
    public int MaxWidthOfVerticalArea(int[][] points)
    {
        return 0;
    }
}
class Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPointsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [
            new int[][]
            {
                [8,7],[9,9],[7,4],[9,7]
            }, 1
        ],
        [
            new int[][] 
            {
                [3,1],[9,0],[1,0],[1,4],[5,3],[8,8]
            }, 3
        ]
    ];
}
public class Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPointsTests
{
    [Theory]
    [ClassData(typeof(Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPointsTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1637_WidestVerticalAreaBetweenTwoPointsContainingNoPoints();
        var actual = sut.MaxWidthOfVerticalArea(input);
        Assert.Equal(expected, actual);
    }
}
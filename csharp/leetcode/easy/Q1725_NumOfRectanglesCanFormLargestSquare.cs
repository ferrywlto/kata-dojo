class Q1725_NumOfRectanglesCanFormLargestSquare
{
    public int CountGoodRectangles(int[][] rectangles)
    {
        return 0;
    }
}
class Q1725_NumOfRectanglesCanFormLargestSquareTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[5,8],[3,9],[5,12],[16,5]}, 3],
        [new int[][] {[2,3],[3,7],[4,3],[3,7]}, 3],
    ];
}
public class Q1725_NumOfRectanglesCanFormLargestSquareTests
{
    [Theory]
    [ClassData(typeof(Q1725_NumOfRectanglesCanFormLargestSquareTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1725_NumOfRectanglesCanFormLargestSquare();
        var actual = sut.CountGoodRectangles(input);
        Assert.Equal(expected, actual);
    }
}
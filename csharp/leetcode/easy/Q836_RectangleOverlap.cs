
class Q836_RectangleOverlap
{
        public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        return false;   
    }
}
class Q836_RectangleOverlapTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{0,0,2,2}, new int[]{1,1,3,3}, true],
        [new int[]{0,0,1,1}, new int[]{1,0,2,1}, false],
        [new int[]{0,0,1,1}, new int[]{2,2,3,3}, false],
    ];
}
public class Q836_RectangleOverlapTests
{
    [Theory]
    [ClassData(typeof(Q836_RectangleOverlapTestData))]
    public void OfficialTestCases(int[] rect1, int[] rect2, bool expected)
    {
        var sut = new Q836_RectangleOverlap();
        var actual = sut.IsRectangleOverlap(rect1, rect2);
        Assert.Equal(expected, actual);
    }
}
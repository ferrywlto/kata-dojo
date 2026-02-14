
class Q836_RectangleOverlap
{
    // TC: O(1), constant calculate everytime
    // SC: O(1), no data structure used
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        var rec1MinX = Math.Min(rec1[0], rec1[2]);
        var rec1MaxX = Math.Max(rec1[0], rec1[2]);
        var rec1MinY = Math.Min(rec1[1], rec1[3]);
        var rec1MaxY = Math.Max(rec1[1], rec1[3]);

        var rec2MinX = Math.Min(rec2[0], rec2[2]);
        var rec2MaxX = Math.Max(rec2[0], rec2[2]);
        var rec2MinY = Math.Min(rec2[1], rec2[3]);
        var rec2MaxY = Math.Max(rec2[1], rec2[3]);

        if (rec2MinX >= rec1MaxX || rec2MaxX <= rec1MinX || rec2MinY >= rec1MaxY || rec2MaxY <= rec1MinY)
            return false;

        return true;
    }
}
class Q836_RectangleOverlapTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{0,0,1,1}, new int[]{0,0,1,1}, true],
        [new int[]{0,0,2,2}, new int[]{1,1,3,3}, true],
        [new int[]{0,0,1,1}, new int[]{1,0,2,1}, false],
        [new int[]{0,0,1,1}, new int[]{2,2,3,3}, false],
        [new int[]{5,15,8,18}, new int[]{0,3,7,9}, false],
        [new int[]{7,8,13,15}, new int[]{10,8,12,20}, true],
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

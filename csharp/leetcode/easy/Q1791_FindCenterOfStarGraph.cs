class Q1791_FindCenterOfStartGraph
{
    public int FindCenter(int[][] edges)
    {
        return 0;
    }
}
class Q1791_FindCenterOfStartGraphTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,2],[2,3],[4,2]},2],
        [new int[][] {[1,2],[5,1],[1,3],[1,4]},1],
    ];
}
public class Q1791_FindCenterOfStartGraphTests
{
    [Theory]
    [ClassData(typeof(Q1791_FindCenterOfStartGraphTestData))]
    public void OfficialTestCases(int[][] input, int expected)
    {
        var sut = new Q1791_FindCenterOfStartGraph();
        var actual = sut.FindCenter(input);
        Assert.Equal(expected, actual);
    }
}
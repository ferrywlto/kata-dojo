class Q1791_FindCenterOfStartGraph
{
    // TC: O(n), where n is length of edges
    // SC: O(m), where m is number of nodes, which is n+1
    public int FindCenter(int[][] edges)
    {
        var dict = new Dictionary<int, int>();
        foreach (var e in edges)
        {
            if (dict.TryGetValue(e[0], out var first))
            {
                dict[e[0]] = ++first;
                if (dict[e[0]] >= edges.Length - 1) return e[0];
            }
            else dict.Add(e[0], 1);

            if (dict.TryGetValue(e[1], out var second))
            {
                dict[e[1]] = ++second;
                if (dict[e[1]] >= edges.Length - 1) return e[1];
            }
            else dict.Add(e[1], 1);
        }
        return 0;
    }
}
class Q1791_FindCenterOfStartGraphTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[][] {[1,2],[2,3],[4,2]},2],
        [new int[][] {[1,2],[5,1],[1,3],[1,4]},1],
        [new int[][] {[1,3],[2,3]},3],
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
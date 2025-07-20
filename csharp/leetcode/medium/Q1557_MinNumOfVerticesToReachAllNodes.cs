
public class Q1557_MinNumOfVerticesToReachAllNodes
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        return [];
    }
    public static TheoryData<int, IList<IList<int>>, List<int>> TestData => new()
    {
        {6, [[0,1],[0,2],[2,5],[3,4],[4,2]], [0,3]},
        {5, [[0,1],[2,1],[3,1],[1,4],[2,4]], [0,2,3]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, IList<IList<int>> edges, List<int> expected)
    {
        var actual = FindSmallestSetOfVertices(n, edges);
        Assert.Equal(expected, actual);
    }
}

public class Q1557_MinNumOfVerticesToReachAllNodes
{

    // TC: O(edges + n)
    // SC: O(edges)
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        var fromSet = new HashSet<int>();
        var toSet = new HashSet<int>();

        foreach (var edge in edges)
        {
            fromSet.Add(edge[0]);
            toSet.Add(edge[1]);
        }

        var result = new List<int>();
        for (var i = 0; i < n; i++)
        {
            // The technique here is that if a vertex that no one can reach, they are the top vertexes in a directed graph, which means they can reach the rest of the graph from their destinations.
            if (fromSet.Contains(i) && !toSet.Contains(i))
            {
                result.Add(i);
            }
        }
        return result;
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
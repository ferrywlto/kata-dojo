public class Q3965_FinishTimeOfTaskI
{
    // TC: O(n), n scales with number of edges for generating the graph. Then another n for DFS calculation for each node.
    // SC: O(n)
    public long FinishTime(int n, int[][] edges, int[] baseTime)
    {
        Dictionary<int, HashSet<int>> graph = [];

        // generate graph
        for (var i = 0; i < edges.Length; i++)
        {
            if (graph.TryGetValue(edges[i][0], out var children))
                children.Add(edges[i][1]);
            else
                graph.Add(edges[i][0], [edges[i][1]]);
        }

        return Calc(0, graph, baseTime);
    }

    private long Calc(int node, Dictionary<int, HashSet<int>> graph, int[] baseTime)
    {
        if (!graph.TryGetValue(node, out HashSet<int>? children))
            return baseTime[node];

        long min = long.MaxValue;
        long max = long.MinValue;
        foreach (var child in children)
        {
            var t = Calc(child, graph, baseTime);
            if (t > max) max = t;
            if (t < min) min = t;
        }

        return max + max - min + baseTime[node];
    }

    public static TheoryData<int, int[][], int[], long> TestData => new()
    {
        { 3, [[0, 1], [1, 2]], [9, 5, 3], 17 },
        { 3, [[0,1],[0,2]], [4,7,6], 12 },
        { 4, [[0,1],[0,2],[2,3]], [5,8,2,1], 18 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, int[] baseTime, long expected)
    {
        var actual = FinishTime(n, edges, baseTime);
        Assert.Equal(expected, actual);
    }
}

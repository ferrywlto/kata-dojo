public class Q3820_PythagoreanDistanceNodesInTree
{
    public int SpecialNodes(int n, int[][] edges, int x, int y, int z)
    {
        var graph = new Dictionary<int, HashSet<int>>();

        // build graph
        for (var i = 0; i < edges.Length; i++)
        {
            var start = edges[i][0];
            var end = edges[i][1];

            if(graph.TryGetValue(start, out var valStart))
            {
                valStart.Add(end);
            }
            else
            {
                graph.Add(start, [end]);
            }

            // two way graph
            if (graph.TryGetValue(end, out var valEnd))
            {
                valEnd.Add(start);
            }
            else
            {
                graph.Add(end, [start]);
            }
        }

        // build distance map
        var distances = new Dictionary<int, Dictionary<int, int>>();
        for (var start = 0; start < n - 1; start++)
        {
            for (var end = start + 1; end < edges.Length; end++)
            {
                if (!graph.ContainsKey(start)) continue;

                var distance = 1;
                var candidates = graph[start];
                if (candidates.Contains(end))
                {
                    var tmp = new Dictionary<int, int>();
                    tmp.TryAdd(end, distance);
                    distances.TryAdd(start, tmp);
                }
                else
                {
                    foreach (var VARIABLE in COLLECTION)
                    {

                    }
                }
            }
        }

        for (var i = 0; i < n; i++)
        {

        }

        return 0;
    }

    private
    public static TheoryData<int, int[][], int, int, int, int> TestData => new()
    {
        {4, [[0,1], [0,2], [0,3]], 1, 2, 3, 3},
        {4, [[0,1], [1,2], [2,3]], 0, 3, 2, 0},
        {4, [[0,1], [1,2], [1,3]], 1, 3, 0, 1},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, int x, int y, int z, int expected)
    {
        var actual = SpecialNodes(n, edges, x, y, z);
        Assert.Equal(expected, actual);
    }
}

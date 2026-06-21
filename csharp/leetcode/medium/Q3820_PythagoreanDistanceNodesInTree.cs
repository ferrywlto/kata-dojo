public class Q3820_PythagoreanDistanceNodesInTree
{
    // We can use List<int>[] as the keys are 0..n - 1
    private List<int>[] BuildGraph(int n, int[][] edges)
    {
        var graph = new List<int>[n];

        // initialize with empty set to avoid missing key
        for (var i = 0; i < n; i++)
            graph[i] = [];

        // build graph
        foreach (var edge in edges)
        {
            var start = edge[0];
            var end = edge[1];

            graph[start].Add(end);
            graph[end].Add(start);
        }

        return graph;
    }

    private int[] GetDistances(List<int>[] graph, int start, int n)
    {
        // Create a distance array where dist[i] means:
        // "the number of edges from start node to node i".
        // Initialize every node as -1, meaning "not visited yet".
        var dist = Enumerable.Repeat(-1, n).ToArray();

        // Queue is used for BFS.
        // BFS visits nodes level by level, so the first time we reach a node,
        // we have found the shortest distance to that node.
        var queue = new Queue<int>();

        // The distance from the start node to itself is 0.
        dist[start] = 0;

        // Start BFS from the start node.
        queue.Enqueue(start);

        // Continue while there are still nodes waiting to be explored.
        while (queue.Count > 0)
        {
            // Take the next node from the queue.
            var node = queue.Dequeue();

            // Visit every neighbor connected to this node.
            foreach (var next in graph[node])
            {
                // If dist[next] is not -1, this node was already visited.
                // We skip it to avoid going backward or processing the same node again.
                if (dist[next] != -1)
                    continue;

                // The neighbor is one edge farther than the current node.
                dist[next] = dist[node] + 1;

                // Add the neighbor to the queue so we can explore its neighbors later.
                queue.Enqueue(next);
            }
        }

        // Return the distance from start to every node.
        return dist;
    }

    public int SpecialNodes(int n, int[][] edges, int x, int y, int z)
    {
        var graph = BuildGraph(n, edges);

        var result = 0;
        var dx = GetDistances(graph, x, n);
        var dy = GetDistances(graph, y, n);
        var dz = GetDistances(graph, z, n);
        for (var i = 0; i < n; i++)
        {
            var a = (long)dx[i] * dx[i];
            var b = (long)dy[i] * dy[i];
            var c = (long)dz[i] * dz[i];

            if (a + b == c || a + c == b || b + c == a)
                result++;
        }

        return result;
    }

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

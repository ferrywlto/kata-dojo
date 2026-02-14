public class Q1971_FindIfPathExistsInGraph
{
    // TC: O(n), n scale with number of edges + length of path
    // SC: O(n), n scale with 2 * number of edges + length of path m + height of stack k
    public bool ValidPath(int _, int[][] edges, int source, int destination)
    {
        var dictEdges = new Dictionary<int, HashSet<int>>();
        foreach (var e in edges)
        {
            if (dictEdges.TryGetValue(e[0], out var value)) value.Add(e[1]);
            else dictEdges.Add(e[0], [e[1]]);

            if (dictEdges.TryGetValue(e[1], out var value2)) value2.Add(e[0]);
            else dictEdges.Add(e[1], [e[0]]);
        }

        if (source == destination) return true;
        if (!dictEdges.ContainsKey(source) || !dictEdges.ContainsKey(destination)) return false;
        // depth-first search
        var path = new HashSet<int>() { source };
        var stack = new Stack<int>();
        stack.Push(source);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            foreach (var choice in dictEdges[node])
            {
                if (choice == destination) return true;
                if (path.Contains(choice)) continue;

                path.Add(choice);
                stack.Push(choice);
            }
        }
        return false;
    }
    public static List<object[]> TestData =>
    [
        [1, new int[][] {}, 0, 0, true],
        [2, new int[][] {[0,1]}, 0, 0, true],
        [2, new int[][] {[0,1]}, 1, 0, true],
        [2, new int[][] {[0,1]}, 0, 1, true],
        [2, new int[][] {[0,1]}, 1, 1, true],
        [3, new int[][] {[0,1],[1,2],[2,0]}, 0, 2, true],
        [6, new int[][] {[0,1],[0,2],[3,5],[5,4],[4,3]}, 0, 5, false],
        [10, new int[][] {[0,7],[0,8],[6,1],[2,0],[0,4],[5,8],[4,7],[1,3],[3,5],[6,5]}, 7, 5, true],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, int source, int destination, bool expected)
    {
        var actual = ValidPath(n, edges, source, destination);
        Assert.Equal(expected, actual);
    }
}

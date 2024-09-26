public class Q1971_FindIfPathExistsInGraph(ITestOutputHelper output)
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        var dictSource = new Dictionary<int, HashSet<int>>();
        foreach (var e in edges)
        {
            if (dictSource.TryGetValue(e[0], out var value)) value.Add(e[1]);
            else dictSource.Add(e[0], [e[1]]);

            if (dictSource.TryGetValue(e[1], out var value2)) value2.Add(e[0]);
            else dictSource.Add(e[1], [e[0]]);
        }

        if (dictSource.Count == 0) return true;

        // depth search
        var path = new HashSet<int>() { source };
        var stack = new Stack<HashSet<int>>();
        stack.Push(dictSource[source]);
        while (stack.Count > 0 && path.Count <= n)
        {
            var choices = stack.Pop();
            output.WriteLine(string.Join(','), choices);
            foreach (var choice in choices)
            {
                if (choice == destination) return true;
                else if (!path.Contains(choice))
                {
                    path.Add(choice);
                    stack.Push(dictSource[choice]);
                }
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
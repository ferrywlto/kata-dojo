using System.Text;

public class Q3970_ShortestPathWithAtMostKConsecutiveIdenticalCharacters(ITestOutputHelper output)
{
    private class State
    {
        public List<int> Path = [];
        public StringBuilder Labels = new();
        public int CurrentCons = 0;
        public int MaxCons = 0;
        public int Cost = 0;
    }
    public int ShortestPath(int n, int[][] edges, string labels, int k)
    {
        if (edges.Length == 0) return n == 1 ? 0 : -1;
        // for each edge
        // if edge[0] starts with 0, create new state
        // else loop through all states, if path end with edge[0], append edge[1] to path, then add edge[2] to cost, append labels[edge[1]], if sb[^1] == labels[edge[1]],
        // update consecutive += 1, if consecutive > maxConsecutive, set maxConsecutive = consecutive.
        // maxConsecutive > k, remove state as it is invalid path
        var validPaths = new List<State>();

        var minCost = int.MaxValue;

        for (var i = 0; i < edges.Length; i++)
        {
            var edge = edges[i];
            var from = edge[0];
            var to = edge[1];
            var weight = edge[2];
            var pruneList = new List<int>();

            if (from == 0)
            {
                var path = new State();

                if (labels[from] == labels[to])
                {
                    path.CurrentCons = 2;
                    path.MaxCons = 2;
                }
                else
                {
                    path.CurrentCons = 1;
                    path.MaxCons = 1;
                }

                if (path.MaxCons > k) continue;
                path.Cost = weight;
                path.Path.AddRange([from, to]);
                path.Labels.Append(labels[from]);
                path.Labels.Append(labels[to]);

                // if to equals to n, that's a complete path
                if (path.Path[^1] == n - 1)
                {
                    if (path.Cost < minCost) { minCost = path.Cost; }
                }
                validPaths.Add(path);
            }
            else
            {
                foreach (var path in validPaths)
                {
                    if (path.Path[^1] == from)
                    {
                        path.Path.Add(to);
                        path.Cost += weight;
                        if (path.Labels[^1] == labels[to])
                        {
                            path.CurrentCons += 1;
                            output.WriteLine($"l-1: {path.Labels[^1]}, l: {labels[to]}, cc: {path.CurrentCons}");
                            if (path.CurrentCons > path.MaxCons)
                            {
                                path.MaxCons = path.CurrentCons;
                                if (path.MaxCons > k)
                                {
                                    pruneList.Add(i);
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            path.CurrentCons = 1;
                        }
                        path.Labels.Append(labels[to]);

                        // if to equals to n, that's a complete path
                        if (path.Path[^1] == n - 1)
                        {
                            if (path.Cost < minCost) { minCost = path.Cost; }
                        }
                    }
                }

                foreach (var index in pruneList
                .Where(x => x >= 0 && x < validPaths.Count)
                .Distinct()
                .OrderByDescending(x => x))
                {
                    validPaths.RemoveAt(index);
                }
            }
        }

        if (validPaths.Count == 0) return -1;

        output.WriteLine($"{string.Join(Environment.NewLine, validPaths.Select(
            p => $"path: {string.Join(',', p.Path)}, cost: {p.Cost}, label: {p.Labels}"))}");
        return minCost == int.MaxValue ? -1 : minCost;
    }
    // Two bugs
    // 1. 0,9 still appends, it should terminate
    // 2. 0,1,2,3 and 0,1,3 should both exists but no branches created

    public static TheoryData<int, int[][], string, int, int> TestData => new()
    {
        { 3, [[0, 1, 1], [1, 2, 1], [0, 2, 3]], "aab", 1, 3 },
        { 3, [[0, 1, 1], [1, 2, 1], [0, 2, 3]], "aab", 2, 2 },
        { 3, [[0, 1, 1], [1, 2, 1]], "aaa", 2, -1 },
        { 1, [], "k", 1, 0 },
        { 3, [], "bdd", 1, -1 },
        {
            10,
            [
                [0, 5, 28], [0, 1, 5052], [0, 5, 5849], [8, 9, 6454], [1, 3, 3715], [0, 9, 1328], [5, 1, 688],
                [6, 5, 9937], [9, 3, 8164], [0, 1, 3], [1, 2, 3], [2, 3, 10], [3, 4, 7], [4, 5, 6], [5, 6, 4],
                [6, 7, 1], [7, 8, 10], [8, 9, 5]
            ],
            "ababababab", 3, 48
        },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, string labels, int k, int expected)
    {
        var actual = ShortestPath(n, edges, labels, k);
        Assert.Equal(expected, actual);
    }
}

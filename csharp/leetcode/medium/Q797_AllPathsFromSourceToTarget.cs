public class Q797_AllPathsFromSourceToTarget
{
    private Dictionary<int, int[]> _paths = [];
    private List<IList<int>> _result = [];
    private int n = -1;
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        n = graph.Length - 1;
        for (var i = 0; i < n; i++)
        {
            _paths.Add(i, graph[i]);
        }
        foreach (var r in _paths[0])
        {
            Route([0], r);
        }
        return _result;
    }
    private void Route(List<int> list, int option)
    {
        list.Add(option);
        if (option == n)
        {
            _result.Add(list);
            return;
        }

        var options = _paths[option];
        foreach (var opt in options)
        {
            Route([.. list], opt);
        }
    }
    public static TheoryData<int[][], List<IList<int>>> TestData => new()
    {
        {[[1,2],[3],[3],[]], [[0,1,3],[0,2,3]]},
        {[[4,3,1],[3,2,4],[3],[4],[]], [[0,4],[0,3,4],[0,1,3,4],[0,1,2,3,4],[0,1,4]]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, List<IList<int>> expected)
    {
        var actual = AllPathsSourceTarget(input);
        Assert.Equal(expected, actual);
    }
}
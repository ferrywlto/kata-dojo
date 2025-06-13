public class Q797_AllPathsFromSourceToTarget
{
    public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
    {
        return [];
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
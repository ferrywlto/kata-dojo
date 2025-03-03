public class Q3417_ZigzagGridTraversalWithSkip
{
    public IList<int> ZigzagTraversal(int[][] grid)
    {
        return [];
    }
    public static TheoryData<int[][], List<int>> TestData => new()
    {
        {[[1,2],[3,4]], [1,4]},
        {[[2,1],[2,1],[2,1]], [2,1,2]},
        {[[1,2,3],[4,5,6],[7,8,9]], [1,3,5,7,9]}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, List<int> expected)
    {
        var actual = ZigzagTraversal(input);
        Assert.Equal(expected, actual);
    }
}
public class Q1971_FindIfPathExistsInGraph
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        return false;
    }
    public static List<object[]> TestData =>
    [
        [3, new int[][] {[0,1],[1,2],[2,0]}, 0, 2, true],
        [6, new int[][] {[0,1],[0,2],[3,5],[5,4],[4,3]}, 0, 5, false],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, int source, int destination, bool expected)
    {
        var actual = ValidPath(n, edges, source, destination);
        Assert.Equal(expected, actual);
    }
}

public class Q3820_PythagoreanDistanceNodesInTree
{
    public int SpecialNodes(int n, int[][] edges, int x, int y, int z)
    {
        return 0;
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

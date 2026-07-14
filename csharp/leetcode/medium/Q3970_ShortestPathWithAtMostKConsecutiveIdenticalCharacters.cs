public class Q3970_ShortestPathWithAtMostKConsecutiveIdenticalCharacters
{
    public int ShortestPath(int n, int[][] edges, string labels, int k)
    {
        return 0;
    }

    public static TheoryData<int, int[][], string, int, int> TestData => new()
    {
        { 3, [[0, 1, 1], [1, 2, 1], [0, 2, 3]], "aab", 1, 3 },
        { 3, [[0, 1, 1], [1, 2, 1], [0, 2, 3]], "aab", 2, 2 },
        { 3, [[0, 1, 1], [1, 2, 1]], "aaa", 2, -1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, string labels, int k, int expected)
    {
        var actual = ShortestPath(n, edges, labels, k);
        Assert.Equal(expected, actual);
    }
}

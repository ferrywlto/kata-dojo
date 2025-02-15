public class Q3238_FindNumberOfWinningPlayer
{
    public int WinningPlayerCount(int n, int[][] pick)
    {
        return 0;
    }
    public static TheoryData<int, int[][], int> TestData => new()
    {
        {4, [[0,0],[1,0],[1,0],[2,1],[2,1],[2,0]], 2},
        {5, [[1,1],[1,2],[1,3],[1,4]], 0},
        {5, [[1,1],[2,4],[2,4],[2,4]], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int[][] input2, int expected)
    {
        var actual = WinningPlayerCount(input1, input2);
        Assert.Equal(expected, actual);
    }
}

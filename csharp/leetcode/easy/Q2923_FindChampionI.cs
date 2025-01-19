public class Q2923_FindChampionI
{
    public int FindChampion(int[][] grid)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[0,1],[0,0]], 0},
        {[[0,0,1],[1,0,1],[0,0,0]], 1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = FindChampion(input);
        Assert.Equal(expected, actual);
    }
}

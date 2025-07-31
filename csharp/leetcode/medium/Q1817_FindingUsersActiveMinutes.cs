public class Q1817_FindingUsersActiveMinutes
{
    public int[] FindingUsersActiveMinutes(int[][] logs, int k)
    {
        return [];
    }
    public static TheoryData<int[][], int, int[]> TestData => new()
    {
        {[[0,5],[1,2],[0,2],[0,5],[1,3]], 5, [0,2,0,0,0]},
        {[[1,1],[2,2],[2,3]], 4, [1,1,0,0]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int k, int[] expected)
    {
        var actual = FindingUsersActiveMinutes(input, k);
        Assert.Equal(expected, actual);
    }
}

public class Q807_MaxIncreaseToKeepCitySkyline
{
    public int MaxIncreaseKeepingSkyline(int[][] grid)
    {
        return 0;
    }
    public static TheoryData<int[][], int> TestData => new()
    {
        {[[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]], 35},
        {[[0,0,0],[0,0,0],[0,0,0]], 0}
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int expected)
    {
        var actual = MaxIncreaseKeepingSkyline(input);
        Assert.Equal(expected, actual);
    }
}
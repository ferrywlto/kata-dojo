public class Q3965_FinishTimeOfTaskI
{
    public long FinishTime(int n, int[][] edges, int[] baseTime)
    {
        return 0;
    }

    public static TheoryData<int, int[][], int[], long> TestData => new()
    {
        { 3, [[0, 1], [1, 2]], [9, 5, 3], 17 },
        { 3, [[0,1],[0,2]], [4,7,6], 12 },
        { 4, [[0,1],[0,2],[2,3]], [5,8,2,1], 18 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] edges, int[] baseTime, long expected)
    {
        var actual = FinishTime(n, edges, baseTime);
        Assert.Equal(expected, actual);
    }
}

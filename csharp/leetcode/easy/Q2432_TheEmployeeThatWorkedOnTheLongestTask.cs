public class Q2432_TheEmployeeThatWorkedOnTheLongestTask
{
    public int HardestWorker(int n, int[][] logs)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [10, new int[][]{[0,3],[2,5],[0,9],[1,15]},1],
        [26, new int[][]{[1,1],[3,7],[2,12],[7,17]},3],
        [2, new int[][]{[0,10],[1,20]},0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int[][] input, int expected)
    {
        var actual = HardestWorker(n, input);
        Assert.Equal(expected, actual);
    }
}
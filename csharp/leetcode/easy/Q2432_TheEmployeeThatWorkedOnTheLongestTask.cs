public class Q2432_TheEmployeeThatWorkedOnTheLongestTask
{
    // TC: O(n), n scale with length of logs
    // SC: O(1), space used does not scale with input
    public int HardestWorker(int _, int[][] logs)
    {
        var maxTime = logs[0][1];
        var minId = logs[0][0];
        for (var i = 1; i < logs.Length; i++)
        {
            var timeDiff = logs[i][1] - logs[i - 1][1];
            if (timeDiff > maxTime)
            {
                maxTime = timeDiff;
                minId = logs[i][0];
            }
            else if (timeDiff == maxTime && logs[i][0] < minId)
            {
                minId = logs[i][0];
            }
        }
        return minId;
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